using DAL.Models;
using System.Linq;

namespace DAL.Repositories.Implementations
{
    public interface IStoreRepository : ICreateRepository<Store>, IReadRepository<Store>
    {
        IQueryable<Product> GetProducts(int storeId);

        Store GetByName(string name);
    }
}
