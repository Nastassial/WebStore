using System.Linq;
using DAL.Models;
using DAL.Repositories.Implementations;
using DAL.Unit_of_work;

namespace DAL.Repositories.Realizations
{
    public class StoreRepository : IStoreRepository
    {
        public readonly ApplicationDbContext _context;

        public StoreRepository(IUnitOfWork unitOfWork)
        {
            _context = unitOfWork.DbContext;
        }

        public void Create(Store entity)
        {
            _context.Stores.Add(entity);
            _context.SaveChanges();
        }

        public IQueryable<Store> GetAll()
        {
            return _context.Stores;
        }

        public Store GetByName(string name)
        {
            return _context.Stores.Where(s => s.Name == name).FirstOrDefault();
        }

        public IQueryable<Product> GetProducts(int storeId)
        {
            var store = _context.Stores.Find(storeId);
            return store.Products.AsQueryable();
        }
    }
}
