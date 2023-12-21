using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace chapter5.UseCases
{
    public class Report2Station : UseCase
    {
        public override async Task<string> ExecuteAsync()
        {
            try
            {
                // finde die Station die die meisten Kosten verursacht (product + assemblystep Kosten)
                using (var session = CreateSession())
                {
                    var stations = await session.Stations
                                                .Include(x => x.Products)
                                                    .ThenInclude(x => x.Parts)
                                                    .ThenInclude(x => x.PartDefinition)
                                                .Include(x => x.StationAssemblySteps)
                                                    .ThenInclude(x => x.AssemblyStep)
                                                .Select(x => new
                                                {
                                                    Costs = x.StationAssemblySteps.Sum(a => a.AssemblyStep.Cost)
                                                            + x.Products.SelectMany(p => p.Parts).Sum(p2 => p2.PartDefinition.Cost),
                                                    Station = x.ToString(),
                                                    AssemblySteps = string.Join("|", x.StationAssemblySteps.Select(y => y.AssemblyStep)),
                                                    Products = string.Join("|", x.Products)
                                                })
                                                .OrderByDescending(x => x.Costs)
                                                .ToListAsync();

                    return string.Join("\n", stations);
                }
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
    }
}