using System;
using System.Collections.Generic;
using System.Text;

namespace SA.Transport.Core.Domain.Model
{
    public class TransportFuelType
    {
        public Guid Id { get; set; }
        public Guid FuelTypeId { get; set; }
        public FuelType FuelType { get; set; }
        public Guid TransportId { get; set; }
        public Transport Transport { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
