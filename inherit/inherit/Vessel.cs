namespace inherit
{
    public class Vessel : Vehicle
    {
        public string Bunker { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} - Bunker: {this.Bunker}";
        }
    }
}
