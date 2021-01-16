using System.Threading.Tasks;
using project.Service.ViewModels;
using project.Data.Models;
using project.Data.Interfaces;

namespace project.Service.Services
{
    public class ShoppingService : IShoppingService
    {
        private IUnitOfWorkRepository _unitOfWorkRepository;
        public ShoppingService(IUnitOfWorkRepository unitOfWorkRepository)
        {
            _unitOfWorkRepository = unitOfWorkRepository;
        }
        public async Task<int> CreateNewShoppingStore(ShoppingViewModel shoppingViewModel)
        {
            //Example usage
            foreach(var store in shoppingViewModel.Stores)
            {
                //Logics to verify/validate entitities to Insert in Database 
                var existingStore = await _unitOfWorkRepository.GetBySelectedIdAsync<Store>(store.Id);
                if(existingStore == null)
                {
                    store.Id = 0;
                    _unitOfWorkRepository.SetEntitiesToInsert(store);
                }
                else
                {
                    _unitOfWorkRepository.SetEntitiesToDelete(store);
                }
            }

            foreach(var product in shoppingViewModel.Products)
            {
                //Logics to verify/validate entities to Update in Database;
                 var existingProduct =await _unitOfWorkRepository.GetBySelectedIdAsync<Product>(product.Id);
                 if(existingProduct == null)
                 {
                     product.Id = 0;
                    _unitOfWorkRepository.SetEntitiesToInsert(product);
                 }
                 else
                 {
                    _unitOfWorkRepository.SetEntitiesToUpdate(product);
                 }
                
            }

            foreach(var customer in shoppingViewModel.Customers)
            {
                 //Logics to verify/validate entities to Delete in database;
                var existing =await _unitOfWorkRepository.GetBySelectedIdAsync<Customer>(customer.Id);
                if(existing !=null)
                {
                    _unitOfWorkRepository.SetEntitiesToDelete(customer);
                }
                else
                {
                    customer.Id = 0;
                     _unitOfWorkRepository.SetEntitiesToInsert(customer);
                }
            }

            
            
            var committedEntities = await _unitOfWorkRepository.Commit();
            return committedEntities;
        }
    }
}