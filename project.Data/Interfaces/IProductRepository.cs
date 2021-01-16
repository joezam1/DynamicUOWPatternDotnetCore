using System.Threading.Tasks;
using project.Data.Interfaces;
using project.Data.Models;


namespace project.Data.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<Product> GetProductByIdAsync(int id);
    }
}