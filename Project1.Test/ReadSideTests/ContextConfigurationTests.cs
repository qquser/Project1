using NUnit.Framework;
using Project1.ReadSide;
using Project1.ReadSide.Helpers;
using Project1.ReadSide.Interfaces;
using Project1.ReadSide.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Project1.Test.ReadSideTests
{
    [TestFixture]
    public class ContextConfigurationTests
    {
        [Test]
        public void ContextConfiguration_Test()
        {
            //Type type = typeof(ProjectModel);
            //Type[] typeArgs = { type };
            //var generic = typeof(ContextConfiguration<>).MakeGenericType(type);


            var contextConfig = new ContextConfiguration();//generic.GetMethod("Instance");//Activator.CreateInstance(generic);
            var catalog = new AssemblyCatalog(Assembly.GetAssembly(typeof(UpdateService)));
            var container = new CompositionContainer(catalog);

            //var qweqwe = typeof(ContextConfigurationTests).GetMethod("Configs", BindingFlags.NonPublic |
            //             BindingFlags.Static);
            //var t = qweqwe.MakeGenericMethod(typeof(ProjectModel));
            //var qwe= t.Invoke(null, null);
            container.ComposeParts(contextConfig);

            foreach (var configuration in contextConfig.Configurations)
            {
                var test = configuration;
            }


            Assert.AreEqual(1,0);
        }


        //static ContextConfiguration<T> Evil<T>(ContextConfiguration<T> contextConfiguration) where T : BaseModel
        //{   // in here, life is simple; no more reflection
        //    return contextConfiguration;
        //}

        //static ContextConfiguration<TEntity> Configs<TEntity>(object contextConfiguration) where TEntity : BaseModel
        //{
        //    if (contextConfiguration is ContextConfiguration<TEntity>)
        //    {
        //        return (ContextConfiguration<TEntity>)contextConfiguration;
        //    }

        //    try
        //    {
        //        return (ContextConfiguration<TEntity>)Convert.ChangeType(contextConfiguration, typeof(ContextConfiguration<TEntity>));
        //    }
        //    catch (InvalidCastException)
        //    {
        //        return default(ContextConfiguration<TEntity>);
        //    }           

        //}


    }
}
