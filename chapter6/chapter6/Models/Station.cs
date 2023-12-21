using System;
using System.Collections.Generic;
using System.Linq;

namespace chapter6.Models
{
    public class Station : Entity
    {
        public List<StationsAssemblySteps> StationAssemblySteps { get; set; }
        public Round Round { get; set; }
        public string Position { get; set; }

        public List<Product> Products { get; set; }

        public override string ToString()
            => $"Station: Id [{Id}] - Position [{Position}]";
    }
}