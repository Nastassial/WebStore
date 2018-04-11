using System.Linq;

namespace DAL.Repositories.Implementations
{
    public interface IReadRepository<T> where T: class
    {
        IQueryable<T> GetAll();
    }
}
