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
        public ModelContext() { }

        public ModelContext(DbContextOptions<ModelContext> options)
        : base(options)   { }


        public virtual DbSet<ProjectModel> Projects { get; set; }

        IQueryable<ProjectModel> IModelReader.Projects => Projects.AsNoTracking();

        async Task<int> IModelUpdater.SaveChangesAsync()
        {
            return await SaveChangesAsync(); 
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    string connectionString = ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString;
        //    optionsBuilder.UseSqlServer(connectionString);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.RemovePluralizingTableNameConvention();
            modelBuilder.AddConfiguration(new ProjectModelConfiguration());
        }
    }
}