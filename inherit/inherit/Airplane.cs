namespace inherit
{
    public class Airplane : Vehicle
    {
        public string CruiseAltitude { get; set; }
        public override string ToString()
        {
            return $"Id: {this.Id} - CruiseAltitude: {this.CruiseAltitude}";
        }
    }
}

