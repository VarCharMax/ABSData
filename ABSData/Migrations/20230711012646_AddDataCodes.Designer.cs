﻿// <auto-generated />
using System;
using ABSDataFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ABSData.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230711012646_AddDataCodes")]
    partial class AddDataCodes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ABSDataFramework.Models.abs_data", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ASGS_2016")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Age")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AgeCode")
                        .HasColumnType("nvarchar(max)");

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

                    b.HasIndex("Regionid");

                    b.HasIndex("Sexid");

                    b.HasIndex("Stateid");

                    b.ToTable("AbsData");
                });

            modelBuilder.Entity("ABSDataFramework.Models.region", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("ABSDataFramework.Models.sex_abs", b =>
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

                    b.ToTable("Sexes");
                });

            modelBuilder.Entity("ABSDataFramework.Models.state", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("States");
                });

            modelBuilder.Entity("ABSDataFramework.Models.abs_data", b =>
                {
                    b.HasOne("ABSDataFramework.Models.region", "Region")
                        .WithMany()
                        .HasForeignKey("Regionid");

                    b.HasOne("ABSDataFramework.Models.sex_abs", "Sex")
                        .WithMany()
                        .HasForeignKey("Sexid");

                    b.HasOne("ABSDataFramework.Models.state", "State")
                        .WithMany()
                        .HasForeignKey("Stateid");
                });
#pragma warning restore 612, 618
        }
    }
}
