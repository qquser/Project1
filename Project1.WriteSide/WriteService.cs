using System;
using System.Configuration;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence;
using CommonDomain.Persistence.EventStore;
using Project1.Domain;
using MassTransit;
using MassTransit.Util;
using Topshelf;
using Topshelf.Logging;
using NEventStore;
using Ninject;
using Ninject.Activation.Providers;
using Ninject.Extensions.Conventions;
using Project1.Domain.Project.Service;
using System.Threading.Tasks;
using AutoMapper;

namespace Project1.WriteSide
{
    internal class WriteSide : ServiceControl
    {
        private readonly LogWriter _logger = HostLogger.Get<WriteSide>();
        private readonly StandardKernel _kernel = new StandardKernel();

        private IBusControl _busControl;
        private BusHandle _busHandle;

        public bool Start(HostControl hostControl)
        {
            _logger.Info("Creating bus...");
            ConfigureContainer();
            _busControl = _kernel.Get<IBusControl>();
            _logger.Info("Starting bus...");

            //_busHandle = await  _busControl.StartAsync();
            StartBus().Wait();
            TaskUtil.Await(() => _busHandle.Ready);
            return true;

        }

        private async Task StartBus()
        {
            _busHandle = await _busControl.StartAsync();
        }


        public bool Stop(HostControl hostControl)
        {
            _logger.Info("Stopping bus...");
            TaskUtil.Await(() => _busControl.StopAsync(TimeSpan.FromSeconds(30)));
            return true;
        }

        private void ConfigureContainer()
        {
            _kernel.Bind(x => x
                .FromAssemblyContaining<ProjectService>()
                .SelectAllClasses()
                .InheritedFrom(typeof(IDomainService))
                .BindDefaultInterface());

            _kernel.Bind(x => x
                .FromThisAssembly()
                .IncludingNonePublicTypes()
                .SelectAllClasses()
                .InheritedFrom(typeof(IConsumer))
                .BindToSelf());

            var busControl = Bus.Factory.CreateUsingRabbitMq(x =>
            {
                var host = x.Host(GetHostAddress(), h =>
                {
                    h.Username(ConfigurationManager.AppSettings["RabbitMQUsername"]);
                    h.Password(ConfigurationManager.AppSettings["RabbitMQPassword"]);
                });

                x.ReceiveEndpoint(host, "commands", e =>
                {
                    e.LoadFrom(_kernel);
                });
            });

            _kernel.Bind<IBusControl>()
                .ToConstant(busControl)
                .InSingletonScope();

            _kernel.Bind<IBus>()
                .ToProvider(new CallbackProvider<IBus>(x => x.Kernel.Get<IBusControl>()));

            var bus = _kernel.Get<IBusControl>();
            _kernel.Bind<IStoreEvents>()
                .ToMethod(context => EventStoreConfig.Create(bus))
                .InSingletonScope();

            _kernel.Bind<IMapper>().ToConstant(MapConfig.CreateMapper()).InSingletonScope();

            _kernel.Bind<IDetectConflicts>().To<ConflictDetector>();
            _kernel.Bind<IRepository>().To<EventStoreRepository>();
            _kernel.Bind<IConstructAggregates>().To<AggregateFactory>();
        }

        static Uri GetHostAddress()
        {
            var uriBuilder = new UriBuilder
            {
                Scheme = "rabbitmq",
                Host = ConfigurationManager.AppSettings["RabbitMQHost"]
            };

            return uriBuilder.Uri;
        }
    }
}