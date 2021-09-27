using SA.Transport.Core.Domain.Model;
using System;

namespace SA.Transport.Infrastructure.Database.Configurations.DataSeed
{
    internal static class PersonSeed
    {
        internal static readonly Person GiorgiGiorgadze = new Person { Id = Guid.NewGuid(), FirstName = "გიორგი", LastName = "გიორგაძე", PN = "00000000000" };
        internal static readonly Person NinoNinidze = new Person { Id = Guid.NewGuid(), FirstName = "ნინო", LastName = "ნინიძე", PN = "11111111111" };
        internal static readonly Person KhatiaKhatiashvili = new Person { Id = Guid.NewGuid(), FirstName = "ხატია", LastName = "ხატიაშვილი", PN = "22222222222" };

    }
}
