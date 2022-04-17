﻿// <auto-generated />
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.4");

            modelBuilder.Entity("Data.DataModels.DemoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("DemoModel");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "DemoModel 1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "DemoModel 2"
                        },
                        new
                        {
                            Id = 3,
                            Name = "DemoModel 3"
                        },
                        new
                        {
                            Id = 4,
                            Name = "DemoModel 4"
                        },
                        new
                        {
                            Id = 5,
                            Name = "DemoModel 6"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}