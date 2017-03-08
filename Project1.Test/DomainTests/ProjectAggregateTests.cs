using System;
using CommonDomain.Core;
using CommonDomain.Persistence.EventStore;
using NEventStore;
using NEventStore.Persistence.Sql.SqlDialects;
using NUnit.Framework;
using Project1.Domain.Project.ValueObjects;
using Project1.Domain;
using Project1.Domain.Project.Service;

namespace Project1.Test.DomainTests
{
    [TestFixture]
    public class ProjectAggregateTests
    {
        [Test]
        public void AddProject_Test()
        {
            var projectGuid = Guid.NewGuid();
            var name = new ProjectName("name1");

            using (var store = StoreConnections.CreateMemoryConnection())
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
