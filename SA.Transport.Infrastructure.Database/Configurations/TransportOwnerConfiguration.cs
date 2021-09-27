using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SA.Transport.Core.Domain.Model;
using SA.Transport.Infrastructure.Database.Configurations.DataSeed;

namespace SA.Transport.Infrastructure.Database.Configurations
{
    public class TransportOwnerConfiguration : IEntityTypeConfiguration<TransportOwner>
    {
        public void Configure(EntityTypeBuilder<TransportOwner> builder)
        {
            builder.HasOne(to => to.Person).WithMany(p => p.Transports).HasForeignKey(to => to.PersonId);
            builder.HasOne(to => to.Transport).WithMany(t => t.Owners).HasForeignKey(to => to.TransportId);

            builder.HasData(TransportOwnerSeed.Ford1_Owner1, TransportOwnerSeed.Mercedes1_Owner1, TransportOwnerSeed.Mercedes1_Owner2);
        }
    }
}


