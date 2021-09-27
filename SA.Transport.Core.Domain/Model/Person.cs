using System;
using System.Collections.Generic;

namespace SA.Transport.Core.Domain.Model
{
    public class Person
    {
        public Person()
        {
            Transports = new HashSet<TransportOwner>();
        }
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PN { get; set; }
        public ICollection<TransportOwner> Transports { get; set; }
    }
}
