using DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services.Implementations
{
    public interface IStoreService : IService<Store>
    {
        Task<IEnumerable<Product>> GetProducts(int storeId);

        Task<Store> GetByName(string name);
    }
}
