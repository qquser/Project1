using System;
using System.Configuration;
using AutoMapper;
using Project1.ReadSide.Interfaces;
using MassTransit;
using MassTransit.Util;
using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Extensions.NamedScope;
using Topshelf;
using Topshelf.Logging;
using Microsoft.EntityFrameworkCore;
using Project1.Common.Messages;
using Project1.ReadSide.Updaters;
using Ninject.Activation.Providers;

namespace Project1.ReadSide
{
    internal class UpdateService : ServiceControl
    {
        private readonly LogWriter _logger = HostLogger.Get<UpdateService>();
        private readonly StandardKernel _kernel = new StandardKernel();

        private IBusControl _busControl;
        //private BusHandle _busHandle;

        public bool Start(HostControl hostControl)
        {
            _logger.Info("Creating bus...");


            ConfigureContainer();

            var observer = _kernel.Get<ScopeObserver>();
            _busControl.ConnectReceiveObserver(observer);
            _logger.Info("Starting bus...");

            TaskUtil.Await(() => _busControl.StartAsync());

            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            _logger.Info("Stopping bus...");

            _busControl?.Stop(TimeSpan.FromSeconds(30));

            return true;
        }

        private void ConfigureContainer()
        {
            _kernel.Bind(x => x
                .FromThisAssembly()
                .IncludingNonePublicTypes()
                .SelectAllClasses()
                .InheritedFrom(typeof(IConsumer))
                .BindToSelf());


            _busControl = Bus.Factory.CreateUsingRabbitMq(x =>
            {
                var host = x.Host(GetHostAddress(), h =>
                {
                    h.Username(ConfigurationManager.AppSettings["RabbitMQUsername"]);
                    h.Password(ConfigurationManager.AppSettings["RabbitMQPassword"]);
                });

                x.ReceiveEndpoint(host, "events", e =>
                {
                    e.LoadFrom(_kernel);
                });

                x.ReceiveEndpoint(host, "requests", e =>
                {
                    e.LoadFrom(_kernel);
                });
            });
            _kernel.Bind<IMessagePublisher>().To<MessagePublisher>();

            _kernel.Bind<StandardKernel>().ToConstant(_kernel).InSingletonScope();
            _kernel.Bind<ScopeObserver>().ToSelf().InThreadScope();
            _kernel.Bind<IMapper>().ToConstant(MapConfig.CreateMapper()).InSingletonScope();

            string connectionString = ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString;
            var optionsBuilder = new DbContextOptionsBuilder<ModelContext>().UseSqlServer(connectionString);

            _kernel.Bind<IModelUpdater>().To<ModelContext>().InScope(context =>
            {
                var scopeObserver = context.Kernel.Get<ScopeObserver>();
                return scopeObserver.Current;
            }).WithConstructorArgument("options", optionsBuilder.Options);

            _kernel.Bind<IModelReader>().To<ModelContext>().InScope(context =>
            {
                var scopeObserver = context.Kernel.Get<ScopeObserver>();
                return scopeObserver.Current;
            }).WithConstructorArgument("options", optionsBuilder.Options);

            _kernel.Bind<IBusControl>()
          .ToConstant(_busControl)
          .InSingletonScope();

            _kernel.Bind<IBus>()
                .ToProvider(new CallbackProvider<IBus>(x => x.Kernel.Get<IBusControl>()));




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