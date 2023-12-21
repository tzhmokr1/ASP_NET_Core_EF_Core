using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using chapter4.DataAccess;
using chapter4.Models;
using chapter4.UseCases;
using Microsoft.EntityFrameworkCore;

namespace chapter4.UseCases
{
    public class UpdateAndDeleteUseCase : UseCase
    {
        public override async Task<string> ExecuteAsync()
        {
            try
            {
                using (var session = CreateSession())
                {
                    List<PartDefinition> parts = await session.PartDefinitions.ToListAsync();

                    System.Console.WriteLine(string.Join("\n", parts));
                    System.Console.WriteLine($"count products: {await session.Products.CountAsync()}");

                    await UpdatePartDefinitionsAsync(session, parts);
                    await DeleteProductsAsync(session);

                    await session.SaveChangesAsync();

                    System.Console.WriteLine($"count products: {await session.Products.CountAsync()}");
                    System.Console.WriteLine(string.Join("\n", await session.PartDefinitions.ToListAsync()));

                    return "deleted products without parts, and updated PartDefinitions!";
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        private async Task DeleteProductsAsync(LeanTrainingDbContext session)
        {
            var noParts = await session.Products.Where(x => x.Parts.Any() == false).ToListAsync();

            session.Products.RemoveRange(noParts);
        }

        private Task UpdatePartDefinitionsAsync(LeanTrainingDbContext session, List<PartDefinition> parts)
        {
            foreach (var part in parts)
            {
                // 0815/6/8/9 -- > 0815-1/2/3/4
                part.Name = $"0815-{part.Id}";
            }

            session.UpdateRange(parts);
            return Task.CompletedTask;
        }
    }
}