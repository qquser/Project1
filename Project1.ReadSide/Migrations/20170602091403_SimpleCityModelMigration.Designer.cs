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
    [Migration("20170602091403_SimpleCityModelMigration")]
    partial class SimpleCityModelMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Project1.ReadSide.Models.CityModel", b =>
                {
                    b.Property<string>("Id");

                    b.Property<Guid>("AggregateId");

                    b.Property<long>("Identity")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("AggregateId")
                        .IsUnique();

                    b.HasIndex("Identity")
                        .IsUnique();

                    b.ToTable("CityModel");
                });

            modelBuilder.Entity("Project1.ReadSide.Models.CustomerModel", b =>
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

                    b.ToTable("CustomerModel");
                });

            modelBuilder.Entity("Project1.ReadSide.Models.ProjectModel", b =>
                {
                    b.Property<string>("Id");

                    b.Property<Guid>("AggregateId");

                    b.Property<string>("CustomerId");

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

                    b.HasIndex("CustomerId");

                    b.HasIndex("Identity")
                        .IsUnique();

                    b.ToTable("ProjectModel");
                });

            modelBuilder.Entity("Project1.ReadSide.Models.RoleModel", b =>
                {
                    b.Property<string>("Id");

                    b.Property<Guid>("AggregateId");

                    b.Property<long>("Identity")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("RolePermission");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("AggregateId")
                        .IsUnique();

                    b.HasIndex("Identity")
                        .IsUnique();

                    b.ToTable("RoleModel");
                });

            modelBuilder.Entity("Project1.ReadSide.Models.UserModel", b =>
                {
                    b.Property<string>("Id");

                    b.Property<Guid>("AggregateId");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<long>("Identity")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LastName");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("RoleId");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("AggregateId")
                        .IsUnique();

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Identity")
                        .IsUnique();

                    b.HasIndex("RoleId");

                    b.ToTable("UserModel");
                });

            modelBuilder.Entity("Project1.ReadSide.Models.ProjectModel", b =>
                {
                    b.HasOne("Project1.ReadSide.Models.CustomerModel", "CustomerModel")
                        .WithMany("Projects")
                        .HasForeignKey("CustomerId");
                });

            modelBuilder.Entity("Project1.ReadSide.Models.UserModel", b =>
                {
                    b.HasOne("Project1.ReadSide.Models.RoleModel", "RoleModel")
                        .WithMany("Users")
                        .HasForeignKey("RoleId");
                });
        }
    }
}
