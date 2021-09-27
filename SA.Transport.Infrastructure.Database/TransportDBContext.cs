using Microsoft.EntityFrameworkCore;
using SA.Transport.Core.Domain.Model;
using SA.Transport.Infrastructure.Database.Configurations;

namespace SA.Transport.Infrastructure.Database
{
    public partial class TransportDBContext : DbContext
    {
        public TransportDBContext(DbContextOptions<TransportDBContext> options) : base(options) { }

        public virtual DbSet<Core.Domain.Model.Transport> Transports { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<FuelType> FuelTypes { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<TransportOwner> TransportOwners { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ColorConfiguration());
            modelBuilder.ApplyConfiguration(new FuelTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new TransportConfiguration());

            modelBuilder.ApplyConfiguration(new TransportFuelTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TransportOwnerConfiguration());
        }




    }
}
