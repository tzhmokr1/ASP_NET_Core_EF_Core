using System;
using chapter6.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace chapter6.DataAccess
{
    public class LeanTrainingDbContext : DbContext
    {
        public LeanTrainingDbContext()
        { }

        public DbSet<Round> Rounds { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<AssemblyStep> AssemblySteps { get; set; }
        public DbSet<PartDefinition> PartDefinitions { get; set; }
        public DbSet<StationsAssemblySteps> StationAssemblySteps { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connection = "server=localhost;port=3310;database=lean_training;uid=root;pwd=root";
                optionsBuilder.UseMySql(connection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var stationBuilder = Build<Station>(modelBuilder);
            stationBuilder.Property(x => x.Position)
                          .HasMaxLength(50)
                          .IsRequired();
            stationBuilder.HasOne(x => x.Round)
                          .WithMany(x => x.Stations);
            

            var assemblyBuilder = Build<AssemblyStep>(modelBuilder);
            assemblyBuilder.Property(x => x.Cost)
                           .IsRequired();
            assemblyBuilder.Property(x => x.Name)
                           .HasMaxLength(50)
                           .IsRequired();
            assemblyBuilder.Property(x => x.Mandatory).HasDefaultValue(false);

            var stationAssemblyLink = Build<StationsAssemblySteps>(modelBuilder);
            stationAssemblyLink.HasOne(x => x.Station)
                               .WithMany(x => x.StationAssemblySteps);
            stationAssemblyLink.HasOne(x => x.AssemblyStep)
                               .WithMany(x => x.StationAssemblySteps);

            var roundBuilder = Build<Round>(modelBuilder);
            roundBuilder.Property(x => x.Start)
                        .IsRequired();
            roundBuilder.Property(x => x.End);
            roundBuilder.HasMany(x => x.Stations)
                        .WithOne(x => x.Round);

            var part = Build<Part>(modelBuilder);
            part.HasOne(x => x.Product)
                .WithMany(x => x.Parts);
            part.HasOne(x => x.PartDefinition).WithMany(x => x.Parts);

            var partDef = Build<PartDefinition>(modelBuilder);
            partDef.Property(x => x.Name)
                   .HasMaxLength(50)
                   .IsRequired();
            partDef.Property(x => x.Cost)
                   .IsRequired();

            var product = Build<Product>(modelBuilder);
            product.Property(x => x.Start)
                   .IsRequired();
            product.Property(x => x.End);
            product.HasOne(x => x.Round).WithMany(x => x.Products);
            product.HasOne(x => x.Station).WithMany(x => x.Products).HasForeignKey(x => x.StationId);

            modelBuilder.Entity<QueryResult>().HasNoKey().ToView("simple_view");

            base.OnModelCreating(modelBuilder);
        }

        private EntityTypeBuilder<T> Build<T>(ModelBuilder mb)
            where T : Entity
        {
            var entity = mb.Entity<T>();
            entity.ToTable(typeof(T).Name + "s");
            entity.HasKey(x => x.Id);

            entity.Property<DateTime>("CreatedAt").IsRequired().HasDefaultValueSql("CURDATE()");
            entity.Property<DateTime>("UpdatedAt").IsRequired().HasDefaultValueSql("CURDATE()");
            entity.Property<string>("LatestUser").IsRequired().HasDefaultValueSql("'Admin'");

            return entity;
        }
    }
}