using Microsoft.EntityFrameworkCore;

namespace inherit
{
    public class InheritDbContext : DbContext
    {
        public InheritDbContext()
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder ob)
        {
            if (ob.IsConfigured == false)
            {
                ob.UseSqlite("DataSource=inherit.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            var entity = mb.Entity<Vehicle>();

            entity.HasDiscriminator(x => x.Name)
                  .HasValue<Car>(nameof(Car))
                  .HasValue<Vessel>(nameof(Vessel))
                  .HasValue<Airplane>(nameof(Airplane));

            entity.Property(x => x.Name).HasMaxLength(50).IsRequired();
        }
    }
}