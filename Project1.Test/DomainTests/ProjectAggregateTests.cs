using System;
using CommonDomain.Core;
using CommonDomain.Persistence.EventStore;
using NEventStore;
using NEventStore.Persistence.Sql.SqlDialects;
using NUnit.Framework;
using Project1.Domain.Project.ValueObjects;
using Project1.Domain;
using Project1.Domain.Project.Service;
using Project1.Domain.Project.Events;
using System.Collections.Generic;
using System.Linq;

namespace Project1.Test.DomainTests
{
    [TestFixture]
    public class ProjectAggregateTests
    {
        [Test]
        public void AddProjectWriteSide_Test()
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

        [Test]
        public void AddProjectWriteSide_Name_Test()
        {
            var projectGuid = Guid.NewGuid();
            var name = new ProjectName("name123");

            using (var store = StoreConnections.CreateMemoryConnection())
            {
                var service = new ProjectService(new EventStoreRepository(store, new AggregateFactory(), new ConflictDetector()));
                service.AddProject(projectGuid, name);

                using (var stream = store.OpenStream(projectGuid, 0))
                {
                    var exeptedResult = stream.CommittedEvents.Select(x => x.Body).OfType<ProjectAdded>().Select(x => x.Name); 
                    Assert.AreEqual(exeptedResult, new[] { "name123" });
                }
            }
        } 
        [Test]
        public void RenameProjectWriteSide_Test()
        {
            var projectGuid = Guid.NewGuid();
            var name = new ProjectName("name123");

            using (var store = StoreConnections.CreateMemoryConnection())
            {
                var service = new ProjectService(new EventStoreRepository(store, new AggregateFactory(), new ConflictDetector()));
                service.AddProject(projectGuid, name);
                service.Rename(projectGuid, "newName");

                using (var stream = store.OpenStream(projectGuid, 0))
                {
                    var exeptedResult = stream.CommittedEvents.Select(x => x.Body).OfType<ProjectRenamed>().Select(x => x.NewName);
                    Assert.AreEqual(exeptedResult, new[] { "newName" });
                }
            }
        }


        //[Test]
        //public void ConcurrentConnections_Test()
        //{
        //    var projectGuid = Guid.NewGuid();

        //    using (var store = StoreConnections.CreateLocalDbConnection())
        //    {
        //        var service = new ProjectService(new EventStoreRepository(store, new AggregateFactory(), new ConflictDetector()));
        //        service.AddProject(projectGuid, "qwe1");
        //    }

        //    using (var connection1 = StoreConnections.CreateLocalDbConnection())
        //    {
        //        using (var connection2 = StoreConnections.CreateLocalDbConnection())
        //        {
        //            var service1 = new ProjectService(new EventStoreRepository(connection1, new AggregateFactory(), new ConflictDetector()));
        //            var service2 = new ProjectService(new EventStoreRepository(connection2, new AggregateFactory(), new ConflictDetector()));
        //            service1.Rename(projectGuid, "qwe2");    
        //            service2.Rename(projectGuid, "qwe3");
        //        }
        //    }

        //    using (var connection3 = StoreConnections.CreateLocalDbConnection())
        //    {
        //        using (var stream = connection3.OpenStream(projectGuid, 0))
        //        {
        //            var exeptedResult = stream.CommittedEvents.Select(x => x.Body).OfType<ProjectRenamed>().Select(x => x.NewName);
        //            Assert.AreEqual(exeptedResult, new[] {"qwe2", "qwe3" });
        //        }
        //    }
        //}
    }
}
