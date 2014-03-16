using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace UnitOfWorkPatternDotNet.EntityFramework
{
    public class EntityFrameworkAsyncUnitOfWork : DbContext, IAsyncUnitOfWork
    {
        public async Task<int?> CommitAsync()
        {
            return await SaveChangesAsync();
        }

        public async Task<int?> CommitAsync(CancellationToken cancellationToken)
        {
            return await SaveChangesAsync(cancellationToken);
        }
    }
}