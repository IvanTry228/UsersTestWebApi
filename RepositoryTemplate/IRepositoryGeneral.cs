using System.Collections.Generic;
using RepositoryTemplate.IQueryablesTempates;

namespace RepositoryTemplate
{
    public interface IRepositoryGeneral<T> : IQueryableItemsSet<T>, IQueryableItemsGet<T> ///IQueryableItems<T> //where T : class
    {
        T GetItemById(int _id);

        void AddItem(T _entity);

        void UpdateItem(T _entity);

        //void AddItems(IEnumerable<T> _entitiesCollection);

        void RemoveItem(T _entity);

        IEnumerable<T> GetAll();

        void SaveChangesApply();
    }
}
