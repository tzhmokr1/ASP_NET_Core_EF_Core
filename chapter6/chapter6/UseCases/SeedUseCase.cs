using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using chapter6.DataAccess;
using chapter6.Models;

namespace chapter6.UseCases
{
    public class SeedUseCase : UseCase
    {
        public override async Task<string> ExecuteAsync()
        {
            try
            {
                DateTime start = DateTime.Now;
                using (var context = CreateSession())
                {
                    Round round = await AddRoundAsync(context, start);
                    await AddStationsAsync(context, round);
                    await AddProductsAsync(context, round, start);
                    await AddPartDefinitionsAsync(context);
                    await AddAssemblyStepsAsync(context);

                    await context.SaveChangesAsync();
                    System.Console.WriteLine($"round id after save: [{round.Id}]");
                }
            }
            catch (System.Exception)
            {
                throw;
            }
            return "seeded initial data";
        }

        private Task AddAssemblyStepsAsync(LeanTrainingDbContext context)
        {
            var steps = new List<AssemblyStep>()
            {
                new AssemblyStep { Name = "Bohren", Cost = 2 },
                new AssemblyStep { Name = "Fügen", Cost = 1 },
                new AssemblyStep { Name = "Kleben", Cost = 2 }
            };

            return context.AssemblySteps.AddRangeAsync(steps);
        }

        private Task AddPartDefinitionsAsync(LeanTrainingDbContext context)
        {
            var parts = new List<PartDefinition>()
            {
                new PartDefinition { Name = "0815", Cost = 100 },
                new PartDefinition { Name = "0816", Cost = 100 },
                new PartDefinition { Name = "0818", Cost = 120 },
                new PartDefinition { Name = "0819", Cost = 120 }
            };

            return context.PartDefinitions.AddRangeAsync(parts);
        }

        private Task AddProductsAsync(LeanTrainingDbContext context, Round round, DateTime start)
        {
            var products = new List<Product>();
            var rnd = new Random();
            for (int i = 0; i < 50; i++)
            {
                int add = rnd.Next(0, 60);
                products.Add(new Product { Start = start.AddMinutes(add), Round = round });
            }

            return context.AddRangeAsync(products);

        }

        private Task AddStationsAsync(LeanTrainingDbContext context, Round round)
        {
            var stations = new List<Station>();
            for (int i = 1; i < 7; i++)
            {
                string name = $"Station_{i}";
                stations.Add(new Station { Position = name, Round = round });
            }

            return context.Stations.AddRangeAsync(stations);
        }

        private async Task<Round> AddRoundAsync(LeanTrainingDbContext context, DateTime start)
        {
            var round = new Round { Start = start };
            System.Console.WriteLine($"round id before: [{round.Id}]");
            await context.Rounds.AddAsync(round);

            return round;
        }
    }
}