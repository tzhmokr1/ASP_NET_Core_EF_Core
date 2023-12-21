using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace chapter4.UseCases
{
    public class QueryBasicsUseCase : UseCase
    {
        public override async Task<string> ExecuteAsync()
        {
            try
            {
                using (var session = CreateSession())
                {
                    // first
                    // var first = await session.Products.FirstOrDefaultAsync();
                    // single with id 10
                    // var first = await session.Products.SingleOrDefaultAsync(x => x.Id == 10);
                    // last 
                    // var first = await session.Products.OrderByDescending(x => x.Id).FirstOrDefaultAsync();

                    // var first = await session.Products.Include(x => x.Round)
                    //                                   .ThenInclude(x => x.Stations)
                    //                                   .Include("Round.Products")
                    //                                   .FirstOrDefaultAsync();

                    var round = await session.Rounds.Include(x => x.Products)
                                                    .Include(x => x.Stations)
                                                    .AsNoTracking()
                                                    .ToListAsync();

                    var first = round.SelectMany(x => x.Products).First();
                    return first.ToString();
                }
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
    }
}