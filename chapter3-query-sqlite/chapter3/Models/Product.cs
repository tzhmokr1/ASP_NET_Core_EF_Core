using System;
using System.Collections.Generic;

namespace chapter3.Models
{
    public class Product : Entity
    {
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        
        public List<Part> Parts { get; set; }
        public Round Round { get; set; }

        public override string ToString()
        {
            return $"Id: [{Id}] - Round:[{Round}]";
        }
    }
}