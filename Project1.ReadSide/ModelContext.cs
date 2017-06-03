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
        : base(options)
        {
        }


        public virtual DbSet<CustomerModel> Customers { get; set; }
        public virtual DbSet<ProjectModel> Projects { get; set; }
        public virtual DbSet<UserModel> Users { get; set; }
        public virtual DbSet<RoleModel> Roles { get; set; }
        public virtual DbSet<CityModel> Cities { get; set; }
        public virtual DbSet<WorkshopModel> Workshops { get; set; }
        public virtual DbSet<JobModel> Jobs { get; set; }


        IQueryable<ProjectModel> IModelReader.Projects => Projects.AsNoTracking();
        IQueryable<CustomerModel> IModelReader.Customers => Customers.AsNoTracking();
        IQueryable<UserModel> IModelReader.Users => Users.AsNoTracking();
        IQueryable<RoleModel> IModelReader.Roles => Roles.AsNoTracking();
        IQueryable<CityModel> IModelReader.Cities => Cities.AsNoTracking();
        IQueryable<WorkshopModel> IModelReader.Workshops => Workshops.AsNoTracking();
        IQueryable<JobModel> IModelReader.Jobs => Jobs.AsNoTracking();

        async Task<int> IModelUpdater.SaveChangesAsync()
        {
            return await SaveChangesAsync(); 
        }

        //TODO при накатывании миграций лучше бы, конечно, раскоментить
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString;
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.RemovePluralizingTableNameConvention();

            //Добавление конфигураций для всех моделей 
            var contextConfig = new ContextConfiguration();
            var catalog = new AssemblyCatalog(Assembly.GetAssembly(typeof(UpdateService)));
            var container = new CompositionContainer(catalog);
            container.ComposeParts(contextConfig);

            foreach (var configuration in contextConfig.Configurations)
            {
                AddConfigurationWithCast((dynamic)configuration, configuration, modelBuilder);
            }

        }

        //грязный хак
        void AddConfigurationWithCast<T>(IModelConfiguration<T> hackToInferNeededType, object givenObject, ModelBuilder modelBuilder)
            where T : BaseModel
        {
            var config = givenObject as IModelConfiguration<T>;
            modelBuilder.AddConfiguration(config);
        }

    }


}