using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NEventStore;
using NEventStore.Persistence.Sql.SqlDialects;
using Ninject;
using NUnit.Framework;
using Project1.Domain.Project.ValueObjects;
using Project1.Domain.Project;
using Project1.Domain.Project.Events;

namespace Project1.Test.WriteSideTests
{
    [TestFixture]
    public class ConnectionsTests
    {
        [Test]
        public void EventStoreConnectionLocalDB_Test()
        {
            var nEventStoreConfig = StoreConnections.CreateLocalDbConnection();

            Assert.IsInstanceOf<IStoreEvents>(nEventStoreConfig);
        }
        [Test]
        public void EventStoreMemoryConnection_Test()
        {
            var nEventStoreConfig = StoreConnections.CreateMemoryConnection();

            Assert.IsInstanceOf<IStoreEvents>(nEventStoreConfig);
        }
    }
}
