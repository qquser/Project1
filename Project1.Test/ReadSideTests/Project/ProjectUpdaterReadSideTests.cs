using MassTransit;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Project1.Common.Commands.Project;
using Project1.Common.Events.Project;
using Project1.ReadSide;
using Project1.ReadSide.Interfaces;
using Project1.ReadSide.Updaters.Project;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project1.ReadSide.Helpers;

namespace Project1.Test.ReadSideTests.Project
{
    [TestFixture]
    public class ProjectUpdaterReadSideTests
    {
        [Test]
        public void AddProjectReadSide_Test()
        {
            var newGuid = Guid.NewGuid();
            //string connectionString = ConfigurationManager.ConnectionStrings["LocalDbReadStore"].ConnectionString;
            var options = new DbContextOptionsBuilder<ModelContext>()
                //.UseSqlServer(connectionString)
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;
            var projectContext = Mock.Of<ConsumeContext<IProjectAdded>>(x=> 
                                    x.Message.Id == newGuid && 
                                    x.Message.Name == "TName1");


            using (IModelUpdater context = new ModelContext(options))
            {
                var projectUpdater = new ProjectUpdater(context);        
                Task.Run(() => projectUpdater.Consume(projectContext)).Wait();
            }

            using (IModelReader context = new ModelContext(options))
            {
                Assert.AreEqual(1, context.Projects.Where(x => x.AggregateId == newGuid).Count());
            }
        }

        [Test]
        public void AddProjectReadSide_Name_Test()
        {
            var newGuid = Guid.NewGuid();
            var name = "TName2";
            var options = new DbContextOptionsBuilder<ModelContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;
            var projectContext = Mock.Of<ConsumeContext<IProjectAdded>>(x =>
                                    x.Message.Id == newGuid &&
                                    x.Message.Name == name);

            using (IModelUpdater context = new ModelContext(options))
            {
                var projectUpdater = new ProjectUpdater(context);
                Task.Run(() => projectUpdater.Consume(projectContext)).Wait();
            }

            using (IModelReader context = new ModelContext(options))
            {
                Assert.AreEqual(name, context.Projects.Single(x => x.AggregateId == newGuid).Name);
            }
        }

        [Test]
        public void AddProjectReadSide_Id_Test()
        {
            var newGuid = Guid.NewGuid();
            var name = "TName2";
            var options = new DbContextOptionsBuilder<ModelContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;
            var projectContext = Mock.Of<ConsumeContext<IProjectAdded>>(x =>
                                    x.Message.Id == newGuid &&
                                    x.Message.Name == name);

            using (IModelUpdater context = new ModelContext(options))
            {
                var projectUpdater = new ProjectUpdater(context);
                Task.Run(() => projectUpdater.Consume(projectContext)).Wait();
            }

            using (IModelReader context = new ModelContext(options))
            {
                Assert.AreEqual("ProjectModel-"+ newGuid.ToString(), context.Projects.Single(x => x.AggregateId == newGuid).Id);
            }
        }
    }
}
