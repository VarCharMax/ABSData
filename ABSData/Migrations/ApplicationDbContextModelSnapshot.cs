﻿// <auto-generated />
using System;
using ABSDataFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ABSData.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ABSDataFramework.Models.Age", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ABSAgeId")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("DimAge");
                });

            modelBuilder.Entity("ABSDataFramework.Models.DimState", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ABSStateId")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("DimState");
                });

            modelBuilder.Entity("ABSDataFramework.Models.FactPopulation", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("AgeCodeid")
                        .HasColumnType("bigint");

                    b.Property<int>("CensusYear")
                        .HasColumnType("int");

                    b.Property<string>("GeographyLevel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegionType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("Regionid")
                        .HasColumnType("bigint");

                    b.Property<long?>("Sexid")
                        .HasColumnType("bigint");

                    b.Property<long?>("Stateid")
                        .HasColumnType("bigint");

                    b.Property<int>("Time")
                        .HasColumnType("int");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("AgeCodeid");

                    b.HasIndex("Regionid");

                    b.HasIndex("Sexid");

                    b.HasIndex("Stateid");

                    b.ToTable("FactPopulation");
                });

            modelBuilder.Entity("ABSDataFramework.Models.Region", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ABSRegionId")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("DimRegion");
                });

            modelBuilder.Entity("ABSDataFramework.Models.Sex", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ABSSexId")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("DimSex");
                });

            modelBuilder.Entity("ABSDataFramework.Models.FactPopulation", b =>
                {
                    b.HasOne("ABSDataFramework.Models.Age", "AgeCode")
                        .WithMany()
                        .HasForeignKey("AgeCodeid");

                    b.HasOne("ABSDataFramework.Models.Region", "Region")
                        .WithMany()
                        .HasForeignKey("Regionid");

                    b.HasOne("ABSDataFramework.Models.Sex", "Sex")
                        .WithMany()
                        .HasForeignKey("Sexid");

                    b.HasOne("ABSDataFramework.Models.DimState", "State")
                        .WithMany()
                        .HasForeignKey("Stateid");
                });
#pragma warning restore 612, 618
        }
    }
}
