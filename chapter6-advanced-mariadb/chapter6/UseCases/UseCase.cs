

using System.Threading.Tasks;
using chapter6.DataAccess;

namespace chapter6.UseCases
{
    public abstract class UseCase
    {
        public abstract Task<string> ExecuteAsync();

        protected LeanTrainingDbContext CreateSession()
            => new LeanTrainingDbContext();
    }
}