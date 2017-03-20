using MassTransit;
using MassTransit.Util;
using Ninject;
using Ninject.Activation.Providers;
using Ninject.Extensions.Conventions;
using Project1.Informer.MessegeServices;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;
using Topshelf.Logging;

namespace Project1.Informer
{
    public class InformerService : ServiceControl
    {
        private readonly LogWriter _logger = HostLogger.Get<InformerService>();
        private readonly StandardKernel _kernel = new StandardKernel();

        private IBusControl _busControl;

        public bool Start(HostControl hostControl)
        {
            _logger.Info("Creating bus...");
            ConfigureContainer();

            _busControl = _kernel.Get<IBusControl>();
            _logger.Info("Starting bus...");


            TaskUtil.Await(() => _busControl.StartAsync());

            return true;
        }

        private void ConfigureContainer()
        {
            _kernel.Bind(x => x
                 .FromThisAssembly()
                 .SelectAllClasses()
                 .InheritedFrom(typeof(IMessageService))
                 .BindDefaultInterface());

            _kernel.Bind(x => x
               .FromThisAssembly()
               .IncludingNonePublicTypes()
               .SelectAllClasses()
               .InheritedFrom(typeof(IConsumer))
               .BindToSelf());

            var userName = ConfigurationManager.AppSettings["RabbitMQUsername"];
            var password = ConfigurationManager.AppSettings["RabbitMQPassword"];
            var busControl = Bus.Factory.CreateUsingRabbitMq(x =>
            {
                var host = x.Host(GetHostAddress(), h =>
                {
                    h.Username(userName);
                    h.Password(password);
                });

                x.ReceiveEndpoint(host, "messages", e =>
                {
                    e.LoadFrom(_kernel);
                });
            });

            _kernel.Bind<IBusControl>()
                .ToConstant(busControl)
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

        public bool Stop(HostControl hostControl)
        {
            _logger.Info("Stopping bus...");
            TaskUtil.Await(() => _busControl.StopAsync(TimeSpan.FromSeconds(30)));
            return true;
        }
    }
}
