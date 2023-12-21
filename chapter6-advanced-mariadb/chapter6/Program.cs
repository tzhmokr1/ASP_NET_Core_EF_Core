using System;
using System.Collections.Generic;
using System.Linq;
using chapter6.UseCases;

namespace chapter6
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

                    System.Console.WriteLine($"{hL}{nL}{result}{nL}{hL}");
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
                System.Console.WriteLine(ex.InnerException);
            }
            Console.ReadLine();
        }

        private static Dictionary<string, UseCase> _map = new Dictionary<string, UseCase>();

        static Program()
        {
            _map.Add("seed", new SeedUseCase());
            _map.Add("query", new QueryBasicsUseCase());
            _map.Add("read-stations", new ReadStationsUseCase());
            _map.Add("products", new AddProductstoStationUseCase());

            _map.Add("track", new ChangesUseCase());
            _map.Add("add", new AddUseCase());

            _map.Add("delete", new DeleteUseCase());

            _map.Add("rawsql", new RawSql());
            _map.Add("query-type", new QueryUseCase());
        }
    }
}
