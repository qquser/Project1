﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Project1.ReadSide;
using Project1.Common.Enums;

namespace Project1.ReadSide.Migrations
{
    [DbContext(typeof(ModelContext))]
    [Migration("20170602112044_SimpleJobTable")]
    partial class SimpleJobTable
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

            modelBuilder.Entity("Project1.ReadSide.Models.JobModel", b =>
                {
                    b.Property<string>("Id");

                    b.Property<Guid>("AggregateId");

                    b.Property<string>("CityId")
                        .IsRequired();

                    b.Property<string>("Description");

                    b.Property<long>("Identity")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.Property<string>("WorkshopId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("AggregateId")
                        .IsUnique();

                    b.HasIndex("CityId");

                    b.HasIndex("Identity")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.HasIndex("WorkshopId");

                    b.ToTable("JobModel");
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

            modelBuilder.Entity("Project1.ReadSide.Models.WorkshopModel", b =>
                {
                    b.Property<string>("Id");

                    b.Property<Guid>("AggregateId");

                    b.Property<string>("CityId");

                    b.Property<long>("Identity")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("AggregateId")
                        .IsUnique();

                    b.HasIndex("CityId");

                    b.HasIndex("Identity")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("WorkshopModel");
                });

            modelBuilder.Entity("Project1.ReadSide.Models.JobModel", b =>
                {
                    b.HasOne("Project1.ReadSide.Models.CityModel", "CityModel")
                        .WithMany("Jobs")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Project1.ReadSide.Models.UserModel", "UserModel")
                        .WithMany("Jobs")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Project1.ReadSide.Models.WorkshopModel", "WorkshopModel")
                        .WithMany("Jobs")
                        .HasForeignKey("WorkshopId")
                        .OnDelete(DeleteBehavior.Cascade);
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

            modelBuilder.Entity("Project1.ReadSide.Models.WorkshopModel", b =>
                {
                    b.HasOne("Project1.ReadSide.Models.CityModel", "CityModel")
                        .WithMany("Workshops")
                        .HasForeignKey("CityId");
                });
        }
    }
}
