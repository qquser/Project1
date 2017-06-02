using Microsoft.EntityFrameworkCore;
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

    static class ModelBuilderHelper
    {
        public static IModelConfiguration<T> CastToConfigurationType<T>(IModelConfiguration<T> hackToInferNeededType, object givenObject) where T : BaseModel
        {
            return givenObject as IModelConfiguration<T>;
        }
    }

    [TestFixture]
    public class ContextConfigurationTests
    {
        public object CastHelper { get; private set; }

        [Test]
        public void ContextConfiguration_Test()
        {
            //Type type = typeof(ProjectModel);
            //Type[] typeArgs = { type };
            //var generic = typeof(ContextConfiguration<>).MakeGenericType(type);


            var contextConfig = new ContextConfiguration();//generic.GetMethod("Instance");//Activator.CreateInstance(generic);
            var catalog = new AssemblyCatalog(Assembly.GetAssembly(typeof(UpdateService)));
            var container = new CompositionContainer(catalog);
            container.ComposeParts(contextConfig);

            //var qweqwe = typeof(ContextConfigurationTests).GetMethod("Configs", BindingFlags.NonPublic |
            //             BindingFlags.Static);
            //var t = qweqwe.MakeGenericMethod(typeof(ProjectModel));
            //var qwe= t.Invoke(null, null);
            

            foreach (var configuration in contextConfig.Configurations)
            {
                Type modelType = configuration.GetType().BaseType.GetGenericArguments().Single();
                Type shellType = typeof(IModelConfiguration<>);
                Type configModelType = shellType.MakeGenericType(modelType);

                // object predicate = predicateProperty.GetValue(invocation.InvocationTarget, null);
                //var item = ((dynamic)configModelType).Get((dynamic)configuration);
                //Activator.CreateInstance(modelType)
                var qwe = ModelBuilderHelper.CastToConfigurationType((dynamic)configuration, configuration);
                Assert.IsTrue(qwe is IModelConfiguration);
                //var bar = Convert.ChangeType(configuration, specificShellPropertyType);

                //var test = (IEnumerable<typeof(modelType)>)configuration;
            }


            //Assert.AreEqual(1,0);
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
