using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using Project1.ReadSide.Helpers;
using Project1.ReadSide.Interfaces;
using Project1.ReadSide.Models;

namespace Project1.ReadSide
{
    public class ModelContext : DbContext, IModelUpdater, IModelReader
    {
        public ModelContext()
            : base("name=LocalDb")
        {
            Database.SetInitializer<ModelContext>(null);
        }

        public virtual DbSet<ProjectModel> Projects { get; set; }

        IQueryable<ProjectModel> IModelReader.Projects => Projects.AsNoTracking();

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            var contextConfiguration = new ContextConfiguration();
            var catalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            var container = new CompositionContainer(catalog);
            container.ComposeParts(contextConfiguration);

            foreach (var configuration in contextConfiguration.Configurations)
            {
                configuration.AddConfiguration(modelBuilder.Configurations);
            }
        }
    }
}