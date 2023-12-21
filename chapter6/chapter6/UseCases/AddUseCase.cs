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
        public override Task<string> ExecuteAsync()
        {
            throw new NotImplementedException();
        }
    }
}