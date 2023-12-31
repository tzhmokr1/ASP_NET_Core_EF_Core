﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using chapter3.DataAccess;

namespace chapter3.Data.Migrations
{
    [DbContext(typeof(LeanTrainingDbContext))]
    [Migration("20191215101015_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0");

            modelBuilder.Entity("chapter3.Models.AssemblyStep", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cost")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("AssemblySteps");
                });

            modelBuilder.Entity("chapter3.Models.Part", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PartDefinitionId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ProductId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PartDefinitionId");

                    b.HasIndex("ProductId");

                    b.ToTable("Parts");
                });

            modelBuilder.Entity("chapter3.Models.PartDefinition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cost")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("PartDefinitions");
                });

            modelBuilder.Entity("chapter3.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("End")
                        .HasColumnType("TEXT");

                    b.Property<int?>("RoundId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Start")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("datetime('now')");

                    b.HasKey("Id");

                    b.HasIndex("RoundId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("chapter3.Models.Round", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("End")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Start")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("datetime('now')");

                    b.HasKey("Id");

                    b.ToTable("Rounds");
                });

            modelBuilder.Entity("chapter3.Models.Station", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<int?>("RoundId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RoundId");

                    b.ToTable("Stations");
                });

            modelBuilder.Entity("chapter3.Models.StationsAssemblySteps", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AssemblyStepId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("StationId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AssemblyStepId");

                    b.HasIndex("StationId");

                    b.ToTable("StationsAssemblyStepss");
                });

            modelBuilder.Entity("chapter3.Models.Part", b =>
                {
                    b.HasOne("chapter3.Models.PartDefinition", "PartDefinition")
                        .WithMany("Parts")
                        .HasForeignKey("PartDefinitionId");

                    b.HasOne("chapter3.Models.Product", "Product")
                        .WithMany("Parts")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("chapter3.Models.Product", b =>
                {
                    b.HasOne("chapter3.Models.Round", "Round")
                        .WithMany("Products")
                        .HasForeignKey("RoundId");
                });

            modelBuilder.Entity("chapter3.Models.Station", b =>
                {
                    b.HasOne("chapter3.Models.Round", "Round")
                        .WithMany("Stations")
                        .HasForeignKey("RoundId");
                });

            modelBuilder.Entity("chapter3.Models.StationsAssemblySteps", b =>
                {
                    b.HasOne("chapter3.Models.AssemblyStep", "AssemblyStep")
                        .WithMany("StationAssemblySteps")
                        .HasForeignKey("AssemblyStepId");

                    b.HasOne("chapter3.Models.Station", "Station")
                        .WithMany("StationAssemblySteps")
                        .HasForeignKey("StationId");
                });
#pragma warning restore 612, 618
        }
    }
}
