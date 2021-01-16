using project.Data.Models;
using System.Threading.Tasks;
using project.Data.Interfaces;

namespace project.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _productRepository.GetProductByIdAsync(id);
        }

        public async Task<Product> AddProductAsync(Product product )
        {
            return await _productRepository.AddAsync(product);
        }
    }
}