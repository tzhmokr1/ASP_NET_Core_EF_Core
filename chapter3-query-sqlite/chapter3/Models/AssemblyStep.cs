using System.Collections.Generic;

namespace chapter3.Models
{
    public class AssemblyStep : Entity
    {
        public string Name { get; set; }
        public int Cost { get; set; }
        public List<StationsAssemblySteps> StationAssemblySteps { get; set; }
    }
}