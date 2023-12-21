using System;
using System.Linq;
using System.Threading.Tasks;
using chapter6.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace chapter6.UseCases
{
    public class ChangesUseCase : UseCase
    {
        public override async Task<string> ExecuteAsync()
        {
            using (var session = new LeanTrainingDbContext())
            {
                var products = await session.Products.AsNoTracking().ToListAsync();

                var projected = products.Select(p =>
                {
                    var entry = session.Entry(p);

                    return $"{entry.Entity.GetType().Name} - {entry.State} - {p.Id}";
                });

                return string.Join("\n", projected);
            }
        }
    }
}