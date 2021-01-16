using System.Threading.Tasks;
using project.Service.ViewModels;

namespace project.Service.Services
{
    public interface IShoppingService
    {
        Task<int> CreateNewShoppingStore(ShoppingViewModel shoppingViewModel);
    }
}