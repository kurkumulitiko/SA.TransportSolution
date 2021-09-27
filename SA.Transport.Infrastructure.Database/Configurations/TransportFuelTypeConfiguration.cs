using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SA.Transport.Core.Domain.Model;
using SA.Transport.Infrastructure.Database.Configurations.DataSeed;

namespace SA.Transport.Infrastructure.Database.Configurations
{
    public class TransportFuelTypeConfiguration : IEntityTypeConfiguration<TransportFuelType>
    {
        public void Configure(EntityTypeBuilder<TransportFuelType> builder)
        {
            builder.HasOne(tf => tf.FuelType).WithMany(f => f.Transports).HasForeignKey(tf => tf.FuelTypeId);
            builder.HasOne(tf => tf.Transport).WithMany(t => t.FuelTypes).HasForeignKey(tf => tf.TransportId);

            builder.HasData(TransportFuelTypeSeed.Ford1_FuelType1, TransportFuelTypeSeed.Ford1_FuelType2, TransportFuelTypeSeed.Mercedes1_FuelType1);
        }
    }
}
