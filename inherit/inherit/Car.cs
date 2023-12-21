namespace inherit
{
    public class Car : Vehicle
    {
        public string Make { get; set; }
        public string Model { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} - Make: {this. Make} - Model: {this.Model}";
        }
    }
}

