using System.Linq;
using System.Collections.Generic;

namespace RepositoryTemplate
{
    public interface IRepositoryGeneral<T>
    {
        T GetItemById(int _id);

        void AddItem(T _entity);

        void UpdateItem(T _entity);

        void RemoveItem(T _entity);

        IEnumerable<T> GetAll();

        void SaveChangesApply();

        //get and set queryables (old in interfaces):
        void SetQueryableItems(IQueryable<T> _setQueryableItems);

        IQueryable<T> GetQueryableItems();
    }
}
