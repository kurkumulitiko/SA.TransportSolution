using SA.Transport.Core.Domain.Model;
using System;

namespace SA.Transport.Infrastructure.Database.Configurations.DataSeed
{
    internal static class TransportFuelTypeSeed
    {
        internal static readonly TransportFuelType Ford1_FuelType1 = new TransportFuelType
        {
            Id = Guid.NewGuid(),
            FuelTypeId = FuelTypeSeed.Gasoline.Id,
            TransportId = TransportSeed.Ford_1.Id,
            StartDate = TransportSeed.Ford_1.CreateDate
        };
        internal static readonly TransportFuelType Ford1_FuelType2 = new TransportFuelType
        {
            Id = Guid.NewGuid(),
            FuelTypeId = FuelTypeSeed.Electric.Id,
            TransportId = TransportSeed.Ford_1.Id,
            StartDate = TransportSeed.Ford_1.CreateDate
        };
        internal static readonly TransportFuelType Mercedes1_FuelType1 = new TransportFuelType
        {
            Id = Guid.NewGuid(),
            FuelTypeId = FuelTypeSeed.Gasoline.Id,
            TransportId = TransportSeed.Mercedes_1.Id,
            StartDate = TransportSeed.Mercedes_1.CreateDate
        };
    }
}
