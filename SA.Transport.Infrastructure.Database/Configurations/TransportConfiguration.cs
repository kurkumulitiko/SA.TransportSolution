using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SA.Transport.Infrastructure.Database.Configurations.DataSeed;

namespace SA.Transport.Infrastructure.Database.Configurations
{
    public class TransportConfiguration : IEntityTypeConfiguration<Transport.Core.Domain.Model.Transport>
    {

        public void Configure(EntityTypeBuilder<Core.Domain.Model.Transport> builder)
        {

            builder.Property(x => x.MakeGE).HasMaxLength(50).IsRequired();
            builder.Property(x => x.MakeEN).HasMaxLength(50).IsRequired();
            builder.Property(x => x.ModelGE).HasMaxLength(50).IsRequired();
            builder.Property(x => x.ModelEN).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Number).HasMaxLength(20).IsRequired();
            builder.Property(x => x.VinCode).HasMaxLength(100).IsRequired();

            builder.HasOne(x => x.Color).WithMany(c => c.Transports).HasForeignKey(x => x.ColorId);

            builder.HasData(TransportSeed.Ford_1, TransportSeed.Mercedes_1);


        }
    }
}
