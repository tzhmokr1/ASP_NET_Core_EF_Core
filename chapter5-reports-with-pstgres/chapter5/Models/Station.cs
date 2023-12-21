using System;
using System.Collections.Generic;
using System.Linq;

namespace chapter5.Models
{
    public class Station : Entity
    {
        public List<StationsAssemblySteps> StationAssemblySteps { get; set; }
        public Round Round { get; set; }
        public string Position { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();

        public override string ToString()
            => $"Station: Id [{Id}] - Position [{Position}]";
    }
    public static class StationExtensions
    {
        public static int PositionAsInt(this Station station)
        {
            char last = station.Position.Last();
            if (int.TryParse(new string(new char[] { last }), out int result))
            {
                return result;
            }
            else
            {
                return -1;
            }
        }
    }
}