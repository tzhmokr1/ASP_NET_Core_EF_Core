namespace chapter4.Models
{
    public class StationsAssemblySteps : Entity
    {
        public Station Station { get; set; }
        public AssemblyStep AssemblyStep { get; set; }
    }
}