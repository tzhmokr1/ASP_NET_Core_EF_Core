using System;
using System.Linq;
using System.Threading.Tasks;
using chapter6.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace chapter6.UseCases
{
    public class DeleteUseCase : UseCase
    {
        public override async Task<string> ExecuteAsync()
        {
            using (var session = new LeanTrainingDbContext())
            {
                var last = await session.Products.OrderByDescending(x => x.Id).FirstAsync();

                session.Products.Remove(last);
                AddUseCase.DisplayState(session, last);

                await session.SaveChangesAsync();

                return $"deleted latest: {last.Id}";
            }
        }
    }
}