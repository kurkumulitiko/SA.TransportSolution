using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SA.Transport.Core.Domain.Model;
using SA.Transport.Infrastructure.Database.Configurations.DataSeed;

namespace SA.Transport.Infrastructure.Database.Configurations
{
    public class ColorConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(30).IsRequired();
            builder.HasMany(x => x.Transports).WithOne(x => x.Color);

            builder.HasData(ColorSeed.White, ColorSeed.Silver, ColorSeed.Black, ColorSeed.Blue, ColorSeed.Red);


        }
    }
}
