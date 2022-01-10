using OtherCustomTools;
using RepositoryTemplate.IQueryablesTempates;

namespace RepositoryTemplate.IValidationTemplates
{
    public interface IValidatorQueryableItems<T>: IQueryableItems<T>
    {
        public bool IsValidatedItem(T _argItemCheck, IResultOperation _argIResult);
    }
}