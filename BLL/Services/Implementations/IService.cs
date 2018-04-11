using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services.Implementations
{
    public interface IService<T> where T:class
    {
        Task Create(T entity);

        Task<IEnumerable<T>> GetAll();
    }
}
