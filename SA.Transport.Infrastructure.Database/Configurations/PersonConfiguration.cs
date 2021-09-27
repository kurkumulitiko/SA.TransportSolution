using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SA.Transport.Core.Domain.Model;
using SA.Transport.Infrastructure.Database.Configurations.DataSeed;

namespace SA.Transport.Infrastructure.Database.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(x => x.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.PN).HasMaxLength(30).IsRequired();

            builder.HasIndex(x => x.PN).IsUnique();

            builder.HasData(PersonSeed.GiorgiGiorgadze, PersonSeed.NinoNinidze, PersonSeed.KhatiaKhatiashvili);


        }
    }
}
