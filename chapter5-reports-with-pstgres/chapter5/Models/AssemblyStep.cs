using System.Collections.Generic;

namespace chapter5.Models
{
    public class AssemblyStep : Entity
    {
        public string Name { get; set; }
        public int Cost { get; set; }
        public List<StationsAssemblySteps> StationAssemblySteps { get; set; }

        public bool Mandatory { get; set; }

        public override string ToString()
            => $"AssemblyStep - Name : {Name} - Cost: {Cost} - Mandatory {Mandatory}";
    }
}