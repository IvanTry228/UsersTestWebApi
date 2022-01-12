namespace RepositoryTemplate
{
    public interface IRepositoryDependency<T>
    {
        public void SetRepository(IRepositoryGeneral<T> _setRepository);
        public IRepositoryGeneral<T> GetRepository();
    }
}