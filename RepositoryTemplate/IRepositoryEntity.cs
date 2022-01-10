using Microsoft.EntityFrameworkCore;

namespace RepositoryTemplate
{
    public interface IRepositoryEntity<T> where T : class //: IRepositoryGeneral<T> 
    {
        void SetInjectDbSetEntity(DbSet<T> _injectedDb);

        void SetInjectAppDbContext(DbContext _dbContext);
    }
}