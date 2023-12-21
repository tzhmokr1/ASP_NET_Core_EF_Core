using System;
using System.Collections.Generic;

namespace chapter5.Models
{
    public class Product : Entity
    {
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        
        public List<Part> Parts { get; set; }
        public int StationId { get; set; }
        public Station Station { get; set; }
        public Round Round { get; set; }

        public override string ToString()
            => $"Product: Id {Id} DLZ - {End-Start}";
    }
}