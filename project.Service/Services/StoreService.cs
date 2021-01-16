using System.Threading.Tasks;
using project.Data.Models;
using project.Data.Interfaces;

namespace project.Service.Services
{
    public class StoreService : IStoreService
    {
        private readonly IGenericRepository<Store> _repository;

        public StoreService(IGenericRepository<Store> repository)
        {
            _repository = repository;
        }
        
       public Task<Store> AddStoreAsync(Store store)
       {
           var result = _repository.AddAsync(store);
           return result;
       } 
    }
}