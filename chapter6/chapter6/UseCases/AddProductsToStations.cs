using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using chapter6.Models;
using Microsoft.EntityFrameworkCore;

namespace chapter6.UseCases
{
    public class AddProductstoStationUseCase : UseCase
    {
        public override async Task<string> ExecuteAsync()
        {
            try
            {
                using (var session = CreateSession())
                {
                    var products = await session.Set<Product>().ToListAsync();
                    int? roundId = session.Entry(products.First()).Property<int?>("RoundId").CurrentValue;
                    // .Include(x=> x.Round); --> First().Round.Id;
                    var stations = await session.Stations.Where(x => x.Round.Id == roundId)
                                                   .ToListAsync();

                    int productAmount = 17;
                    for (int i = 0; i < productAmount; i++)
                    {
                        Station station = FindStation(stations, i);
                        products[i].Station = station;
                        products[i].StationId = station.Id;
                    }
                    session.UpdateRange(products);
                    await session.SaveChangesAsync();

                    return string.Join("\n", products);
                }
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        private static Station FindStation(List<Station> stations, int i)
        {
            // 6 stations per round ... from seeding use case
            if (i <= 3) return stations[0];
            else if (i <= 6) return stations[1];
            else if (i <= 9) return stations[2];
            else if (i <= 12) return stations[3];
            else if (i <= 15) return stations[4];
            else return stations[5];
        }
    }
}