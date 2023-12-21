using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace chapter5.UseCases
{
    public class ShowShadowPropertyUseCase : UseCase
    {
        public override async Task<string> ExecuteAsync()
        {
            try
            {
                using (var session = CreateSession())
                {
                    var products = await session.Products.ToListAsync();
                    var result = products.Select(x => new
                    {
                        CreatedAt = session.Entry(x).Property<DateTime>("CreatedAt").CurrentValue,
                        UpdatedAt = session.Entry(x).Property<DateTime>("UpdatedAt").CurrentValue,
                        LatestUser = session.Entry(x).Property<string>("LatestUser").CurrentValue,
                    });
                    return string.Join("\n", result);
                }
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
    }
}