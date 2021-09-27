using SA.Transport.Core.Domain.Model;
using System;

namespace SA.Transport.Infrastructure.Database.Configurations.DataSeed
{
    internal static class ColorSeed
    {
        internal static readonly Color White = new Color { Id = Guid.NewGuid(), Name = "თეთრი" };
        internal static readonly Color Silver = new Color { Id = Guid.NewGuid(), Name = "ვერცხლისფერი" };
        internal static readonly Color Black = new Color { Id = Guid.NewGuid(), Name = "შავი" };
        internal static readonly Color Blue = new Color { Id = Guid.NewGuid(), Name = "ლურჯი" };
        internal static readonly Color Red = new Color { Id = Guid.NewGuid(), Name = "წითელი" };

    }
}
