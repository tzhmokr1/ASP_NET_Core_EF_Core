using System;
using System.Linq;
using System.Threading.Tasks;
using chapter6.DataAccess;
using chapter6.Models;
using Microsoft.EntityFrameworkCore;

namespace chapter6.UseCases
{
    public class AddUseCase : UseCase
    {
        private static DateTime dt = new DateTime(2020, 01, 01);
        public override async Task<string> ExecuteAsync()
        {
            using (var session = new LeanTrainingDbContext())
            {
                var round = await session.Rounds.Include(x => x.Stations)
                                                .AsNoTracking().FirstOrDefaultAsync();
                var station6 = round.Stations.Single(x => x.Position.EndsWith("6"));

                var product = new Product
                {
                    Start = dt,
                    Round = round,
                    StationId = station6.Id,
                    Station = station6
                };
                DisplayState(session, product);

                session.Entry(product).State = EntityState.Added;

                session.Products.Add(product);
                await session.SaveChangesAsync();
                DisplayState(session, product);

                return "tracked changes!";
            }
        }

        public static void DisplayState(LeanTrainingDbContext session, Product product)
        {
            string state = $"{product.GetType().Name} - {session.Entry(product).State}";
            System.Console.WriteLine(state);
        }
    }
}