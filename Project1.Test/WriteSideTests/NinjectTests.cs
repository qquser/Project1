using Ninject;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Activation.Providers;
using Ninject.Extensions.Conventions;
using MassTransit;
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
            StandardKernel kernel = new StandardKernel();
            kernel.Bind(x => x
                .FromAssemblyContaining<EventPublisher>()
                //.IncludingNonePublicTypes() // 
                .SelectAllClasses()
                .InheritedFrom(typeof(IConsumer))
                .BindToSelf());

            var expectedClass = kernel.Get<ProjectHandler>();// <EventPublisher>();//Moq

            Assert.IsInstanceOf<ProjectHandler>(expectedClass);
        }

    }
}
