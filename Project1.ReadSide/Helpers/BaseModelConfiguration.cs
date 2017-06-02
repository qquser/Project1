using System.ComponentModel.Composition;
using System.ComponentModel.DataAnnotations.Schema;
using Project1.ReadSide.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Project1.ReadSide.Helpers
{
    [InheritedExport(typeof(IModelConfiguration))]
    internal abstract class BaseModelConfiguration<TEntity> : IModelConfiguration<TEntity>, IModelConfiguration
        where TEntity : BaseModel
    {
        public void Configure(EntityTypeBuilder<TEntity> entity)
        {
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Id).ValueGeneratedNever();
            entity.Property(p => p.Identity).ValueGeneratedOnAdd();
            entity.HasIndex(p => p.Identity).IsUnique();
            entity.HasIndex(p => p.AggregateId).IsUnique();
            entity.Property(p => p.RowVersion)
                .IsConcurrencyToken()
                .IsRowVersion();

            ConfigureModel(entity);
        }

        protected abstract void ConfigureModel(EntityTypeBuilder<TEntity> entity);

    }
}