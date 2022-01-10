using Microsoft.EntityFrameworkCore;

namespace RepositoryTemplate
{
    public interface IRepositoryEntity<T> : IRepositoryGeneral<T> where T : class
    {
        void SetInjectDbSetEntity(DbSet<T> _injectedDb);

        void SetInjectAppDbContext(DbContext _dbContext);
    }
}