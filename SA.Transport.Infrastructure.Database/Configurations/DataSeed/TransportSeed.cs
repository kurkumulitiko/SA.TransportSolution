using System;

namespace SA.Transport.Infrastructure.Database.Configurations.DataSeed
{
    internal static class TransportSeed
    {

        internal static readonly Core.Domain.Model.Transport Ford_1 = new Core.Domain.Model.Transport
        {
            Id = Guid.NewGuid(),
            MakeGE = "ფორდი",
            MakeEN = "Ford",
            ModelGE = "ფუჯნ",
            ModelEN = "Fusion",
            Number = "TE-111-ST",
            VinCode = "1111",
            CreateDate = DateTime.Now.AddYears(-3).Date,
            ColorId = ColorSeed.White.Id,
        };
        internal static readonly Core.Domain.Model.Transport Mercedes_1 = new Core.Domain.Model.Transport
        {
            Id = Guid.NewGuid(),
            MakeGE = "მერსედესი",
            MakeEN = "Mercedes",
            ModelGE = "ა-კლასი",
            ModelEN = "A-Klasse",
            Number = "TE-222-ST",
            VinCode = "2222",
            CreateDate = DateTime.Now.AddYears(-5).Date,
            ColorId = ColorSeed.Black.Id
        };
    }
}
