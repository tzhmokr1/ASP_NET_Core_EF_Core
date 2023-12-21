using System.Collections.Generic;

namespace chapter6.Models
{
    public class AssemblyStep : Entity
    {
        public string Name { get; set; }
        public int Cost { get; set; }
        public List<StationsAssemblySteps> StationAssemblySteps { get; set; }

        public bool Mandatory { get; set; }
    }
}