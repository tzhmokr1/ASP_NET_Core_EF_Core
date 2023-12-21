using System;
using System.Linq;
using System.Threading.Tasks;
using chapter6.Models;
using Microsoft.EntityFrameworkCore;

namespace chapter6.UseCases
{
    public class QueryUseCase : UseCase
    {
        public override async Task<string> ExecuteAsync()
        {
            using (var session = CreateSession())
            {
                var viewResult = await session.Set<QueryResult>().Take(10).ToListAsync();

                return string.Join(",", viewResult.Select(x => x.ToString()));
            }
        }
    }
}