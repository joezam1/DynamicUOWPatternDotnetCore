using System;
using System.Threading.Tasks;
using project.Data.Models;


namespace project.Service.Services
{
    public interface IProductService
    {
        Task<Product> AddProductAsync(Product product);
        Task<Product> GetProductByIdAsync(int id);
    }
}