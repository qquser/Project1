using Ninject;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonDomain.Persistence;
using Ninject.Activation.Providers;
using Ninject.Extensions.Conventions;
using MassTransit;
using Moq;
using Ninject.Parameters;
using Project1.Domain.Project.Service;
using Project1.WriteSide;
using Project1.WriteSide.Handlers.Project;

namespace Project1.Test.WriteSideTests
{
    [TestFixture]
    public class NinjectTests
    {
        [Test]
        public void GetInternalClasses_Test()
        {
            //TODO ProjectHandler по идее должен быть internal, но если это так, то все сообщения из command идут в skipped
            StandardKernel kernel = new StandardKernel();
            kernel.Bind(x => x
                .FromThisAssembly()
                //.FromAssemblyContaining<EventPublisher>()
                .IncludingNonePublicTypes() // 
                .SelectAllClasses()
                .InheritedFrom(typeof(IConsumer))
                .BindToSelf());
            //var service = Mock.Of<IProjectService>(); 

            var bindings = kernel.GetBindings(typeof(ProjectHandler)); //new ConstructorArgument("service", service));

            Assert.True(bindings.Any());
        }

    }
}
