using System;
using System.Collections.Generic;
using System.Linq;

namespace chapter3.Models
{
    public class Round : Entity
    {
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }

        public List<Station> Stations { get; set; }
        public List<Product> Products { get; set; }

        public override string ToString()
        {
            return $"Id: [{Id}] - Stations: [{Stations.Count}] - Products : [{Products.Count}]";
        }

    }
}