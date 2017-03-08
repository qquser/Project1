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
            var nEventStoreConfig= Wireup.Init()
               .LogToOutputWindow()
               .UsingInMemoryPersistence()
               .UsingSqlPersistence("LocalDb")
               .WithDialect(new MsSqlDialect())
               .EnlistInAmbientTransaction()
               .InitializeStorageEngine()
               .UsingJsonSerialization()
               //.UsingSynchronousDispatchScheduler()
               .Build();

            Assert.IsInstanceOf<IStoreEvents>(nEventStoreConfig);
        }
    }
}
