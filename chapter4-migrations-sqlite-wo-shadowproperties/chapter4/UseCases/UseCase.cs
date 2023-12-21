

using System.Threading.Tasks;
using chapter4.DataAccess;

namespace chapter4.UseCases
{
    public abstract class UseCase
    {
        public abstract Task<string> ExecuteAsync();

        protected LeanTrainingDbContext CreateSession()
            => new LeanTrainingDbContext();
    }
}