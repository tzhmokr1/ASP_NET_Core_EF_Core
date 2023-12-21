using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using chapter5.DataAccess;
using chapter5.Models;
using Microsoft.EntityFrameworkCore;

namespace chapter5.UseCases
{
    public class InsertLinksUseCase : UseCase
    {
        public override async Task<string> ExecuteAsync()
        {
            try
            {
                using (var session = CreateSession())
                {
                    bool wereLinksInjected = await session.StationAssemblySteps.AnyAsync();
                    if (wereLinksInjected)
                    {
                        return "nothing was injected, links are already in place";
                    }
                    await InsertPartsAsync(session);
                    await InsertStationStepsAsync(session);

                    await session.SaveChangesAsync();

                    return "inserted Parts and StationAssemblySteps";
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        private async Task InsertStationStepsAsync(LeanTrainingDbContext session)
        {
            var stations = await session.Stations.ToListAsync();
            var steps = await session.AssemblySteps.ToListAsync();
            var list = new List<StationsAssemblySteps>();

            foreach (var station in stations)
            {
                int position = station.PositionAsInt();
                AssemblyStep step;
                switch (position)
                {
                    // 1 Bohren
                    // 2 Fügen
                    // 3 Kleben
                    case 6: step = steps.FirstOrDefault(x => x.Name.Equals("kleben", StringComparison.InvariantCultureIgnoreCase)); break;
                    case 3: step = steps.FirstOrDefault(x => x.Name.Equals("fügen", StringComparison.InvariantCultureIgnoreCase)); break;
                    case 4: goto case 3;
                    case 5: goto case 3;
                    default:
                        step = steps.First();
                        break;
                }

                list.Add(new StationsAssemblySteps
                {
                    Station = station,
                    AssemblyStep = step
                });
            }
            await session.StationAssemblySteps.AddRangeAsync(list);

        }

        private async Task InsertPartsAsync(LeanTrainingDbContext session)
        {
            var products = await session.Products.Skip(17).Take(17).ToListAsync();
            var definitions = await session.PartDefinitions.ToListAsync();
            var list = new List<Part>();
            foreach (var product in products)
            {
                foreach (var partDefinition in definitions)
                {
                    list.Add(new Part
                    {
                        PartDefinition = partDefinition,
                        Product = product
                    });
                }
            }
            await session.Parts.AddRangeAsync(list);
        }
    }
}