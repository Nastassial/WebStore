using BLL.Services.Implementations;
using DAL.Repositories.Implementations;
using DAL.Models;
using System.Threading.Tasks;
using DAL.Unit_of_work;
using System.Collections.Generic;

namespace BLL.Services.Realizations
{
    public class StoreService : IStoreService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IStoreRepository _storeRepository;

        public StoreService(IUnitOfWork unitOfWork, IStoreRepository storeRepository)
        {
            _unitOfWork = unitOfWork;
            _storeRepository = storeRepository;
        }

        public Task Create(Store entity)
        {
            return Task.Run(() => _storeRepository.Create(entity));
        }

        public async Task<IEnumerable<Store>> GetAll()
        {
            return await Task.Run(() => _storeRepository.GetAll());
        }

        public async Task<Store> GetByName(string name)
        {
            return await Task.Run(() => _storeRepository.GetByName(name));
        }

        public async Task<IEnumerable<Product>> GetProducts(int storeId)
        {
            return await Task.Run(() => _storeRepository.GetProducts(storeId));
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
