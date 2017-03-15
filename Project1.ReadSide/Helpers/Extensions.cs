using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Project1.ReadSide.Interfaces;
using System;


namespace Project1.ReadSide.Helpers
{
    internal static class Extensions
    {
        public static T FindAggregate<T>(this DbSet<T> set, Guid id) where T : class
        {
            var key = string.Concat(typeof(T).Name, "-", id);
            return set.Find(key);
        }

        public static void RemovePluralizingTableNameConvention(this ModelBuilder modelBuilder)
        {
            foreach (IMutableEntityType entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.Relational().TableName = entity.DisplayName();
            }
        }

        public static void AddConfiguration<TEntity>(this ModelBuilder modelBuilder, IModelConfiguration<TEntity> entityConfiguration)
            where TEntity : BaseModel
        {
            modelBuilder.Entity<TEntity>(entityConfiguration.Configure);
        }
    }
}