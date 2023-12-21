using System;
using System.Linq;
using System.Threading.Tasks;
using chapter6.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace chapter6.UseCases
{
    public class RawSql : UseCase
    {
        private string sql = @"
                            SELECT * FROM Products AS p
                            WHERE p.Id > 10 AND p.Id < 35
                            ";
        public override async Task<string> ExecuteAsync()
        {
            using (var session = new LeanTrainingDbContext())
            {
                var result = await session.Products.FromSqlRaw(sql)
                                             .Include(x => x.Station)
                                             .AsNoTracking()
                                             .ToListAsync();
                
                string joined = string.Join("\n", result);
                return joined;
            }
        }
    }
}