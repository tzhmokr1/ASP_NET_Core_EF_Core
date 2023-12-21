using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using basics.models;

namespace basics.dataaccess
{
    public partial class BasicsContext : DbContext
    {
        public BasicsContext()
        {
        }

        public BasicsContext(DbContextOptions<BasicsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Entity> Entity { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("DataSource=data/basics.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entity>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnType("INT")
                    .ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
