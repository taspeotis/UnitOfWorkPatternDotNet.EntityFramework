using System.Data.Entity;

namespace UnitOfWorkPatternDotNet.EntityFramework
{
    public class EntityFrameworkUnitOfWork : DbContext, IUnitOfWork
    {
        public int? Commit()
        {
            return SaveChanges();
        }
    }
}