using OtherCustomTools;
using System.Linq;

namespace RepositoryTemplate.IValidationTemplates
{
    public interface IValidatorQueryableItems<T> //: //IQueryableItemsSet<T>, IQueryableItemsGet<T>
    {
        public bool IsValidatedItem(T _argItemCheck, IResultOperation _argIResult);

        public void SetQueryableItems(IQueryable<T> _setQueryableItems);

        public IQueryable<T> GetQueryableItems();
    }
}