using System;
using System.Collections.Generic;
using System.Linq;

namespace chapter6.Models
{
    public class Round : Entity
    {
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }

        public List<Station> Stations { get; set; }
        public List<Product> Products { get; set; }

    }
}