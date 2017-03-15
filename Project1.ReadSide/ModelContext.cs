using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using Project1.ReadSide.Helpers;
using Project1.ReadSide.Interfaces;
using Project1.ReadSide.Models;
using Microsoft.EntityFrameworkCore;
using Project1.ReadSide.Mappings;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.RemovePluralizingTableNameConvention();

            modelBuilder.AddConfiguration(new ProjectModelConfiguration());
        }
    }
}