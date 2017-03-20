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
using Project1.ReadSide.Updaters;
using Project1.ReadSide.Readers;
using Project1.ReadSide.Updaters.Customer;

namespace Project1.Test.WriteSideTests
{
    [TestFixture]
    public class NinjectTests
    {
        [Test]
        public void Ninject_Get_ProjectReader_InternalClasses_Test()
        {
            //TODO ProjectHandler по идее должен быть internal, но если это так, то все сообщения из command идут в skipped
            StandardKernel kernel = new StandardKernel();
            kernel.Bind(x => x
                //.FromThisAssembly()
                .FromAssemblyContaining<MessagePublisher>()
                .IncludingNonePublicTypes() // 
                .SelectAllClasses()
                .InheritedFrom(typeof(IConsumer))
                .BindToSelf());
            //var service = Mock.Of<IProjectService>(); 

            var bindings = kernel.GetBindings(typeof(ProjectReader)); //new ConstructorArgument("service", service));

            Assert.True(bindings.Any());
        }

        [Test]
        public void Ninject_Get_CustomerUpdater_InternalClasses_Test()
        {
            //TODO ProjectHandler по идее должен быть internal, но если это так, то все сообщения из command идут в skipped
            StandardKernel kernel = new StandardKernel();
            kernel.Bind(x => x
                //.FromThisAssembly()
                .FromAssemblyContaining<MessagePublisher>()
                .IncludingNonePublicTypes() // 
                .SelectAllClasses()
                .InheritedFrom(typeof(IConsumer))
                .BindToSelf());
            //var service = Mock.Of<IProjectService>(); 

            var bindings = kernel.GetBindings(typeof(CustomerUpdater)); //new ConstructorArgument("service", service));

            Assert.True(bindings.Any());
        }

    }
}
