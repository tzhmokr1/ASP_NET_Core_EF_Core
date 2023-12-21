using System.Collections.Generic;

namespace chapter6.Models
{
    public class PartDefinition : Entity
    {
        public int Cost { get; set; }
        public string Name { get; set; }

        public List<Part> Parts { get; set; }

        public override string ToString()
            => $"PartDefinition\nCost:[{Cost}] - Name [{Name}]";
    }
}