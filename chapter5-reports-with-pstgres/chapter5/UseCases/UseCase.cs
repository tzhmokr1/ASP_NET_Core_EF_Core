

using System.Threading.Tasks;
using chapter5.DataAccess;

namespace chapter5.UseCases
{
    public abstract class UseCase
    {
        public abstract Task<string> ExecuteAsync();

        protected LeanTrainingDbContext CreateSession()
            => new LeanTrainingDbContext();
    }
}