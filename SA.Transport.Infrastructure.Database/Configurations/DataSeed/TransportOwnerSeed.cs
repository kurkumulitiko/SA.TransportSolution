using SA.Transport.Core.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SA.Transport.Infrastructure.Database.Configurations.DataSeed
{
    internal static class TransportOwnerSeed
    {
        internal static readonly TransportOwner Ford1_Owner1 = new TransportOwner
        {
            Id = Guid.NewGuid(),
            TransportId = TransportSeed.Ford_1.Id,
            PersonId = PersonSeed.GiorgiGiorgadze.Id,
            StartDate = DateTime.Now.AddMonths(-7)
        };

        internal static readonly TransportOwner Mercedes1_Owner1 = new TransportOwner
        {
            Id = Guid.NewGuid(),
            TransportId = TransportSeed.Mercedes_1.Id,
            PersonId = PersonSeed.NinoNinidze.Id,
            StartDate = DateTime.Now.AddYears(-1)
        };

        internal static readonly TransportOwner Mercedes1_Owner2 = new TransportOwner
        {
            Id = Guid.NewGuid(),
            TransportId = TransportSeed.Mercedes_1.Id,
            PersonId = PersonSeed.KhatiaKhatiashvili.Id,
            StartDate = DateTime.Now.AddMonths(-3)
        };
    }
}
