namespace RepositoryTemplate
{
    public interface IRepositoryDependency<T>
    {
        public void SetRepository(IRepositoryGen<T> _setRepository);
        public IRepositoryGen<T> GetRepository();
    }
}
