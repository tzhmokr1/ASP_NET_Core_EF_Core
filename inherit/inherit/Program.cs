using System;
using System.Collections.Generic;
using System.Linq;

namespace inherit
{
    class Program
    {
        static void Main(string[] args)
        {
            var vehicles = new List<Vehicle>
            {
                new Car { Make = "Daimler", Model = "E-Klasse" },
                new Airplane { CruiseAltitude = "50000 feet" },
                new Vessel { Bunker = "50000t"}
            };

            var context = new InheritDbContext();

            context.AddRange(vehicles);
            context.SaveChanges();

            var result = context.Set<Vehicle>().ToList(); // set<Car>, Set<Airplane> also possible
            System.Console.WriteLine(string.Join("\n", result.Select(x => x.ToString())));

            context.Dispose();
        }
    }
}
