using System.Linq;

namespace RepositoryTemplate.IQueryablesTempates
{
    public interface IQueryableItemsSet<T>
    {
        public void SetQueryableItems(IQueryable<T> _setQueryableItems);
    }
}