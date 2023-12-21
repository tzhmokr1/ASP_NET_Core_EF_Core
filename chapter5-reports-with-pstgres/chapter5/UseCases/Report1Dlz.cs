using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using chapter5.Models;
using Microsoft.EntityFrameworkCore;

namespace chapter5.UseCases
{
    public class Report1Dlz : UseCase
    {
        public override async Task<string> ExecuteAsync()
        {
            try
            {
                // finde und sortiere Produkte absteigend nach Durchlaufzeit und Cost to produce 
                // {
                //  Cost = Sum-of-costs,
                //  DLZ = product.End - product.Start
                // }
                using (var session = CreateSession())
                {
                    var products = await session.Products
                                                .Include(x => x.Parts) //--> partdefinition --> costs
                                                    .ThenInclude(x => x.PartDefinition)
                                                .Select(product => new
                                                {
                                                    Cost = product.Parts.Sum(part => part.PartDefinition.Cost),
                                                    DLZ = product.End - product.Start,
                                                    Product = product
                                                })
                                                .OrderByDescending(x => x.DLZ)
                                                .OrderByDescending(x => x.Cost)
                                                .Select(x => x.Product)
                                                .ToListAsync();
                    return string.Join("\n", products);
                }
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
    }
    
}