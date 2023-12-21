using System;
using System.Collections.Generic;
using System.Linq;
using chapter3.UseCases;

namespace chapter3
{
    class Program
    {
        static void Main(string[] args)
        {
            string key = args.Last();
            try
            {
                string nL = Environment.NewLine;
                string hL = "".PadRight(50, '-');
                if (_map.TryGetValue(key, out UseCase useCase))
                {
                    string result = useCase.ExecuteAsync().Result;

                    System.Console.WriteLine($"{hL}{nL}{result}{hL}{nL}");
                    System.Console.WriteLine($"{result}");
                }
                else
                {
                    string keys = string.Join(", ", _map.Keys);
                    System.Console.WriteLine($"key not found! try:{nL}[{keys}]");
                }
                System.Console.WriteLine($"ran with key [{key}]");
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("failed");
                System.Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }

        private static Dictionary<string, UseCase> _map = new Dictionary<string, UseCase>();

        static Program()
        {
            _map.Add("query", new QueryBasicsUseCase());
            _map.Add("seed", new SeedUseCase());
            _map.Add("update", new UpdateAndDeleteUseCase());
        }
    }

}
