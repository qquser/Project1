using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Project1.ReadSide;
using Project1.Common.Enums;

namespace Project1.ReadSide.Migrations
{
    [DbContext(typeof(ModelContext))]
    partial class ModelContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Project1.ReadSide.Models.ProjectModel", b =>
                {
                    b.Property<string>("Id");

                    b.Property<Guid>("AggregateId");

                    b.Property<long>("Identity")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("AggregateId")
                        .IsUnique();

                    b.HasIndex("Identity")
                        .IsUnique();

                    b.ToTable("ProjectModel");
                });
        }
    }
}
