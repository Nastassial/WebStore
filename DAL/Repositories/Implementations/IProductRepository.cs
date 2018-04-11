using DAL.Models;

namespace DAL.Repositories.Implementations
{
    public interface IProductRepository : ICreateRepository<Product>, IReadRepository<Product>
    {
    }
}
