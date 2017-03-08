using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence;
using CommonDomain.Persistence.EventStore;
using NEventStore;
using NEventStore.Persistence.Sql.SqlDialects;
using Ninject;
using NUnit.Framework;
using Project1.Common;
using Project1.Domain.Project.ValueObjects;
using Project1.Domain;
using Project1.Domain.Project;
using Project1.Domain.Project.Service;
using Project1.WriteSide;

namespace Project1.Test.DomainTests
{
    [TestFixture]
    public class ProjectAggregateTests
    {
        public static IStoreEvents CreateMemoryConnection()
        {
            return Wireup.Init()
                        .UsingInMemoryPersistence()
                        .InitializeStorageEngine()
                        .Build();
        }

        public static IStoreEvents CreateLocalDbConnection()
        {
            return Wireup.Init()
                        .LogToOutputWindow()
                        .UsingInMemoryPersistence()
                        .UsingSqlPersistence("LocalDb")
                        .WithDialect(new MsSqlDialect())
                        .EnlistInAmbientTransaction()
                        .InitializeStorageEngine()
                        .UsingJsonSerialization()
                        //.UsingSynchronousDispatchScheduler()
                        .Build();
        }

        [Test]
        public void AddProject_Test()
        {
            var projectGuid = Guid.NewGuid();
            var name = new ProjectName("name1");

            using (var store = CreateMemoryConnection())
            {
                var service = new ProjectService(new EventStoreRepository(store, new AggregateFactory(), new ConflictDetector()));

                service.AddProject(projectGuid, name);

                using (var stream = store.OpenStream(projectGuid, 0))
                {
                    Assert.AreEqual(stream.CommittedEvents.Count, 1);
                }
            }
        }
    }
}
