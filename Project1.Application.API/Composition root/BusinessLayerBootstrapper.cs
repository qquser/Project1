﻿using Project1.Application.API.Commands;
using Project1.Application.API.Commands.User.ValidationDecorators;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

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

            container.Register(typeof(BaseCommand<>), new[] { Assembly.GetExecutingAssembly() });

            container.RegisterDecorator(typeof(BaseCommand<>), typeof(ConfirmPasswordCheckDecorator<>));
            container.RegisterDecorator(typeof(BaseCommand<>), typeof(EmailShouldNotExistDecorator<>));
            container.RegisterDecorator(typeof(BaseCommand<>), typeof(AuthorizationCommandDecorator<>));


            //container.Register(typeof(BaseQuery<,>), new[] { Assembly.GetExecutingAssembly() });


        }
    }
}
