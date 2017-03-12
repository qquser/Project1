using NUnit.Framework;
using Project1.Application.API;
using Project1.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NEventStore;

namespace Project1.Test.ApplicationAPI
{
    [TestFixture]
    public class APICommonTests
    {
        [Test]
        public void Api_Test()
        {
            
            Assert.Throws<ArgumentException>(() => new NonEmptyIdentity(Guid.Empty));
        }

        //[Test]
        //public void RabbitUri_Test()
        //{
        //    var nEventStoreConfig = new Startup();


        //}
    }
}
