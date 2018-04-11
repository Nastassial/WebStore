using System.Linq;
using DAL.Models;
using DAL.Repositories.Implementations;
using DAL.Unit_of_work;

namespace DAL.Repositories.Realizations
{
    public class ProductRepository : IProductRepository
    {
        public readonly ApplicationDbContext _context;

        public ProductRepository(IUnitOfWork unitOfWork)
        {
            _context = unitOfWork.DbContext;
        }

        public void Create(Product entity)
        {
            _context.Products.Add(entity);
            _context.SaveChanges();
        }

        public IQueryable<Product> GetAll()
        {
            return _context.Products;
        }
    }
}
