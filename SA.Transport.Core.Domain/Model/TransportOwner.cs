using System;
using System.Collections.Generic;
using System.Text;

namespace SA.Transport.Core.Domain.Model
{
    public class TransportOwner
    {
        public Guid Id { get; set; }
        public Guid TransportId { get; set; }
        public Transport Transport { get; set; }
        public Guid PersonId { get; set; }
        public Person Person { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
