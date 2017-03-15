using System.ComponentModel.Composition;
using System.ComponentModel.DataAnnotations.Schema;
using Project1.ReadSide.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Project1.ReadSide.Helpers
{
    //[InheritedExport(typeof(IModelConfiguration))]
    internal abstract class BaseModelConfiguration<TEntity> : IModelConfiguration<TEntity>
        where TEntity : BaseModel
    {

        public void Configure(EntityTypeBuilder<TEntity> entity)
        {
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Id).ValueGeneratedNever();
            entity.Property(p => p.Identity).ValueGeneratedOnAdd();
                //.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            //entity.Property(p => p.Identity)
            //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
            //    .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_Identity") { IsUnique = true }));
            //entity.Property(p => p.AggregateId)
            //    .HasColumnAnnotation("Index",
            //        new IndexAnnotation(new IndexAttribute("IX_AggregateId") { IsUnique = true }));
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