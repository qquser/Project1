using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Application.API.Composition_root
{
    internal static class Bootstrapper
    {
        private static Container _container;

        public static Container Container
        {
            get { return _container;}
        }

        public static object GetInstance(Type serviceType)
        {
            return _container.GetInstance(serviceType);
        }

        public static T GetInstance<T>() where T : class
        {
            return _container.GetInstance<T>();
        }

        public static void Bootstrap()
        {
            _container = new Container();

            BusinessLayerBootstrapper.Bootstrap(_container);

            _container.Verify();
        }
    }
}
