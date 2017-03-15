using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using Project1.ReadSide.Helpers;
using Project1.ReadSide.Interfaces;
using Project1.ReadSide.Models;
using Microsoft.EntityFrameworkCore;
using Project1.ReadSide.Mappings;
using System;
using System.Threading.Tasks;
using System.Configuration;

namespace Project1.ReadSide
{
    public class ModelContext : DbContext, IModelUpdater, IModelReader
    {
        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ProjectModel> Projects { get; set; }

        IQueryable<ProjectModel> IModelReader.Projects => Projects.AsNoTracking();

        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString;
            options.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.RemovePluralizingTableNameConvention();

            modelBuilder.AddConfiguration(new ProjectModelConfiguration());
        }
    }
}