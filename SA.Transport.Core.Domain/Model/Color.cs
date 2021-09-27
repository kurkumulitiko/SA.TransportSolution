using System;
using System.Collections.Generic;

namespace SA.Transport.Core.Domain.Model
{
    public class Color
    {
        public Color()
        {
            Transports = new HashSet<Transport>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Transport> Transports { get; set; }
    }
}
