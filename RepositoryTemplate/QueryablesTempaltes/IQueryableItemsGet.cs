using System.Linq;

namespace RepositoryTemplate.IQueryablesTempates
{
    public interface IQueryableItemsGet<T>
    {
        public IQueryable<T> GetQueryableItems();
    }
}