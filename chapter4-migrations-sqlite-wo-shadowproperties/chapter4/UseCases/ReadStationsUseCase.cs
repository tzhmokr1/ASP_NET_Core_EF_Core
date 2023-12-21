using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace chapter4.UseCases
{
    public class ReadStationsUseCase : UseCase
    {
        public override async Task<string> ExecuteAsync()
        {
            try
            {
                using (var session = CreateSession())
                {
                    var stations = await session.Stations.ToListAsync();

                    return string.Join("\n", stations);
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}