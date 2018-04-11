using BLL.Services.Implementations;
using DAL.Repositories.Implementations;
using DAL.Models;
using System.Threading.Tasks;
using DAL.Unit_of_work;
using System.Collections.Generic;

namespace BLL.Services.Realizations
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IProductRepository _productRepository;

        public ProductService(IUnitOfWork unitOfWork, IProductRepository productRepository)
        {
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
        }

        public Task Create(Product entity)
        {
            return Task.Run(() => _productRepository.Create(entity));
        }
        
        public async Task<IEnumerable<Product>> GetAll()
        {
            return await Task.Run(() => _productRepository.GetAll());
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
