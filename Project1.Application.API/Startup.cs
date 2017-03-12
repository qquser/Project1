using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MassTransit;
using MassTransit.Util;

namespace Project1.Application.API
{
    public class Startup
    {
        static IBusControl _bus;
        //static BusHandle _busHandle;
        public IConfigurationRoot Configuration { get; }

        public static IBus Bus => _bus;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

            CreateBus();
        }



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
            //services.AddSingleton<IConfiguration>(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
        }

        public Uri GetHostAddress()
        {
            var uriBuilder = new UriBuilder();
            Configuration.GetSection("RabbitMQHost").Bind(uriBuilder);
   
            return uriBuilder.Uri;
        }

        private void CreateBus()
        {
            var userName = Configuration.GetValue<string>("RabbitMQ:UserName");
            var password = Configuration.GetValue<string>("RabbitMQ:Password");
            _bus = MassTransit.Bus.Factory.CreateUsingRabbitMq(x =>
            {
                x.Host(GetHostAddress(), h =>
                {
                    h.Username(userName);
                    h.Password(password);
                });
            });

            TaskUtil.Await(() => _bus.StartAsync());
        }
    }
}
