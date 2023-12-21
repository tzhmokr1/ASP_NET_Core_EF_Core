namespace chapter5.Models
{
    public class Part : Entity
    {
        public Product Product { get; set; }
        public PartDefinition PartDefinition { get; set; }

        public override string ToString()
            => $"Product: {Product.Id} - PartDef: {PartDefinition}";
    }
}