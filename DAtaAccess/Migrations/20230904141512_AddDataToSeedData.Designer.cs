﻿// <auto-generated />
using System;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(GarageDbContext))]
    [Migration("20230904141512_AddDataToSeedData")]
    partial class AddDataToSeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("CarVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataAccess.Entities.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Color = "Test",
                            ImagePath = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/91/Mercedes-Benz_CLS_C218_63_AMG_China_2012-04-15.jpg/1024px-Mercedes-Benz_CLS_C218_63_AMG_China_2012-04-15.jpg",
                            Name = "Merdedes CLS 63",
                            Price = 1000
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            Color = "Test1",
                            ImagePath = "https://upload.wikimedia.org/wikipedia/commons/thumb/e/e2/Porsche_Carrera_4S_front_20080519.jpg/1024px-Porsche_Carrera_4S_front_20080519.jpg",
                            Name = "Porsche 997",
                            Price = 1001
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 3,
                            Color = "Test2",
                            ImagePath = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/65/Audi_RS7_C8_at_IAA_2019_IMG_0307.jpg/1024px-Audi_RS7_C8_at_IAA_2019_IMG_0307.jpg",
                            Name = "Audi RS7",
                            Price = 1002
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 3,
                            Color = "Test",
                            ImagePath = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/4d/Kunmadaras_Motorsport_2021._szeptember_19._JM_%28157%29.jpg/1024px-Kunmadaras_Motorsport_2021._szeptember_19._JM_%28157%29.jpg",
                            Name = "BMW M5",
                            Price = 1003
                        });
                });

            modelBuilder.Entity("DataAccess.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "test",
                            Name = "test"
                        },
                        new
                        {
                            Id = 2,
                            Description = "test1",
                            Name = "test1"
                        },
                        new
                        {
                            Id = 3,
                            Description = "test2",
                            Name = "test2"
                        });
                });

            modelBuilder.Entity("DataAccess.Entities.Car", b =>
                {
                    b.HasOne("DataAccess.Entities.Category", "Category")
                        .WithMany("Cars")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("DataAccess.Entities.Category", b =>
                {
                    b.Navigation("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}
