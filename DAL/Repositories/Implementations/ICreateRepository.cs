namespace DAL.Repositories.Implementations
{
    public interface ICreateRepository<T> where T: class
    {
        void Create(T entity);
    }
}
