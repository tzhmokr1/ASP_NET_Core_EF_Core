

using System.Threading.Tasks;
using chapter3.DataAccess;

namespace chapter3.UseCases
{
    public abstract class UseCase
    {
        public abstract Task<string> ExecuteAsync();

        protected LeanTrainingDbContext CreateSession()
            => new LeanTrainingDbContext();
    }
}