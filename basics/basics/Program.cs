using System;
using System.Linq;
using basics.dataaccess;

namespace basics
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new BasicsContext())
            {
                var items = context.Entity.ToList();

                string result = string.Join("\n", items.Select(e => $"Id: [{e.Id}] - Name: [{e.Name}]"));

                System.Console.WriteLine(result);
            }

            Console.ReadLine();
        }
    }
}
