using SA.Transport.Core.Domain.Model;
using System;

namespace SA.Transport.Infrastructure.Database.Configurations.DataSeed
{
    internal static class FuelTypeSeed
    {
        internal static readonly FuelType Gasoline = new FuelType { Id = Guid.NewGuid(), Type = "ბენზინი" };
        internal static readonly FuelType Electric = new FuelType { Id = Guid.NewGuid(), Type = "ელექტრო" };
        internal static readonly FuelType Diesel = new FuelType { Id = Guid.NewGuid(), Type = "დიზელი" };
        internal static readonly FuelType Gas = new FuelType { Id = Guid.NewGuid(), Type = "გაზი" };

    }
}
