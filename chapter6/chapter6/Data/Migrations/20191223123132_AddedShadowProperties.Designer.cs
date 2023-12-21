﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using chapter6.DataAccess;

namespace chapter6.Data.Migrations
{
    [DbContext(typeof(LeanTrainingDbContext))]
    [Migration("20191223123132_AddedShadowProperties")]
    partial class AddedShadowProperties
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("chapter6.Models.AssemblyStep", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Cost")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("LatestUser")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasDefaultValueSql("Admin");

                    b.Property<bool>("Mandatory")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("Id");

                    b.ToTable("AssemblySteps");
                });

            modelBuilder.Entity("chapter6.Models.Part", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("LatestUser")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasDefaultValueSql("Admin");

                    b.Property<int?>("PartDefinitionId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("Id");

                    b.HasIndex("PartDefinitionId");

                    b.HasIndex("ProductId");

                    b.ToTable("Parts");
                });

            modelBuilder.Entity("chapter6.Models.PartDefinition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Cost")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("LatestUser")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasDefaultValueSql("Admin");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("Id");

                    b.ToTable("PartDefinitions");
                });

            modelBuilder.Entity("chapter6.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<DateTime?>("End")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("LatestUser")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasDefaultValueSql("Admin");

                    b.Property<int?>("RoundId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("StationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("Id");

                    b.HasIndex("RoundId");

                    b.HasIndex("StationId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("chapter6.Models.Round", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<DateTime?>("End")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("LatestUser")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasDefaultValueSql("Admin");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("Id");

                    b.ToTable("Rounds");
                });

            modelBuilder.Entity("chapter6.Models.Station", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("LatestUser")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasDefaultValueSql("Admin");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<int?>("RoundId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("Id");

                    b.HasIndex("RoundId");

                    b.ToTable("Stations");
                });

            modelBuilder.Entity("chapter6.Models.StationsAssemblySteps", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("AssemblyStepId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("LatestUser")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasDefaultValueSql("Admin");

                    b.Property<int?>("StationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("Id");

                    b.HasIndex("AssemblyStepId");

                    b.HasIndex("StationId");

                    b.ToTable("StationsAssemblyStepss");
                });

            modelBuilder.Entity("chapter6.Models.Part", b =>
                {
                    b.HasOne("chapter6.Models.PartDefinition", "PartDefinition")
                        .WithMany("Parts")
                        .HasForeignKey("PartDefinitionId");

                    b.HasOne("chapter6.Models.Product", "Product")
                        .WithMany("Parts")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("chapter6.Models.Product", b =>
                {
                    b.HasOne("chapter6.Models.Round", "Round")
                        .WithMany("Products")
                        .HasForeignKey("RoundId");

                    b.HasOne("chapter6.Models.Station", "Station")
                        .WithMany("Products")
                        .HasForeignKey("StationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("chapter6.Models.Station", b =>
                {
                    b.HasOne("chapter6.Models.Round", "Round")
                        .WithMany("Stations")
                        .HasForeignKey("RoundId");
                });

            modelBuilder.Entity("chapter6.Models.StationsAssemblySteps", b =>
                {
                    b.HasOne("chapter6.Models.AssemblyStep", "AssemblyStep")
                        .WithMany("StationAssemblySteps")
                        .HasForeignKey("AssemblyStepId");

                    b.HasOne("chapter6.Models.Station", "Station")
                        .WithMany("StationAssemblySteps")
                        .HasForeignKey("StationId");
                });
#pragma warning restore 612, 618
        }
    }
}
