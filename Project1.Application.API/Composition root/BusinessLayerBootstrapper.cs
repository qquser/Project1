using Microsoft.AspNetCore.Http;
using Project1.Application.API.Commands;
using Project1.Application.API.Commands.User.ValidationDecorators;
using Project1.Application.API.CrossCuttingConcerns;
using Project1.Application.API.Exceptions;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;


using SimpleInjector.Lifestyles;
using SimpleInjector.Integration.AspNetCore;
using SimpleInjector.Integration.Web;

namespace Project1.Application.API.Composition_root
{
    internal static class BusinessLayerBootstrapper
    {
        private static Container _container;

        public static object GetInstance(Type serviceType)
        {
            return _container.GetInstance(serviceType);
        }

        public static void Bootstrap(Container container)
        {
            _container = container;

            if (container == null)
            {
                throw new ArgumentNullException(nameof(container));
            }
            //container.RegisterSingleton<IPrincipal>(new HttpContextPrinciple());
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            container.RegisterSingleton<IHttpContextAccessor, HttpContextAccessor>();

            container.Register(typeof(IBaseCommand<>), new[] { Assembly.GetExecutingAssembly() }, Lifestyle.Scoped);

            container.RegisterDecorator(typeof(IBaseCommand<>), typeof(ConfirmPasswordCheckDecorator<>), Lifestyle.Scoped);
            container.RegisterDecorator(typeof(IBaseCommand<>), typeof(EmailShouldNotExistDecorator<>), Lifestyle.Scoped);
            container.RegisterDecorator(typeof(IBaseCommand<>), typeof(AuthorizationCommandDecorator<>), Lifestyle.Scoped);


            //container.Register(typeof(BaseQuery<,>), new[] { Assembly.GetExecutingAssembly() }); 

            container.RegisterInitializer<IBaseHandler>(handler =>
            {
                try
                {
                    var accesor = container.GetInstance<IHttpContextAccessor>();
                    var userName = accesor.HttpContext?.User?.Identity?.Name;
                    if (string.IsNullOrEmpty(userName))
                        return;

                    handler.User = UserExtensions.GetUser(userName).User;
                }
                catch
                {

                }
            });

        }
    }
}