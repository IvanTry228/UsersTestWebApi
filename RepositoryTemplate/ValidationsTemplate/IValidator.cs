using OtherCustomTools;

namespace RepositoryTemplate.IValidationTemplates
{
    public interface IValidator<T>
    {
        public bool IsValidatedItem(T _argItemCheck, IResultOperation _argIResult);
    }
}