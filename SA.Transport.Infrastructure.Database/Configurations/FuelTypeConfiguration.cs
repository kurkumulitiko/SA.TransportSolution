using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SA.Transport.Core.Domain.Model;
using SA.Transport.Infrastructure.Database.Configurations.DataSeed;

namespace SA.Transport.Infrastructure.Database.Configurations
{
    public class FuelTypeConfiguration : IEntityTypeConfiguration<FuelType>
    {
        public void Configure(EntityTypeBuilder<FuelType> builder)
        {
            builder.Property(x => x.Type).HasMaxLength(30).IsRequired();

            builder.HasData(FuelTypeSeed.Gasoline, FuelTypeSeed.Electric, FuelTypeSeed.Gas, FuelTypeSeed.Diesel);
        }
    }
}
