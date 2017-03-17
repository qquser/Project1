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
            var generic = typeof(ContextConfiguration<>);
            Type[] typeArgs = { typeof(ProjectModel), typeof(CustomerModel), typeof(UserModel) };
            var makeme = generic.MakeGenericType(typeArgs);

            //var contextConfiguration = Activator.CreateInstance(makeme);//new ContextConfiguration<BaseModel>();
            //var catalog = new AssemblyCatalog(Assembly.GetAssembly(typeof(UpdateService)));
            //var container = new CompositionContainer(catalog);
            //container.ComposeParts(contextConfiguration);

            //foreach (var configuration in contextConfiguration.Configurations)
            //{
            //    var test = configuration;
            //}
            

            Assert.AreEqual(1,0);
        }


    }
}
