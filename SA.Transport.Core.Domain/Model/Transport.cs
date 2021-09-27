using System;
using System.Collections.Generic;

namespace SA.Transport.Core.Domain.Model
{
    public class Transport
    {
        public Transport()
        {
            Id = Guid.NewGuid();
            FuelTypes = new HashSet<TransportFuelType>();
            Owners = new HashSet<TransportOwner>();
        }
        public Guid Id { get; set; }
        public string MakeGE { get; set; }
        public string MakeEN { get; set; }
        public string ModelGE { get; set; }
        public string ModelEN { get; set; }
        public string VinCode { get; set; }
        public string Number { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid ColorId { get; set; }
        public Color Color { get; set; }
        public ICollection<TransportFuelType> FuelTypes { get; set; }
        public ICollection<TransportOwner> Owners { get; set; }
        public string PhotoName { get; set; }
    }
}
