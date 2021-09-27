using System;
using System.Collections.Generic;

namespace SA.Transport.Core.Domain.Model
{
    public class FuelType
    {
        public FuelType()
        {
            Transports = new HashSet<TransportFuelType>();
        }
        public Guid Id { get; set; }
        public string Type { get; set; }
        public ICollection<TransportFuelType> Transports { get; set; }

    }
}
