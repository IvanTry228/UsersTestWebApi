using Microsoft.EntityFrameworkCore;

namespace RepositoryTemplate
{
    public interface IRepositoryEntity<T> : IRepositoryGeneral<T> where T : class
    {
        void SetInjectDbSetEntity(DbSet<T> _injectedDb);

        void SetInjectAppDbContext(DbContext _dbContext);

        // + other specif
        //IEnumerable<T> Filter(ICriteria<T> criteria);
        //void Load(T entity, Expression<Func<T, TProperty>> property);
    }
}
