using System.Threading.Tasks;
using project.Data.Models;
using Microsoft.EntityFrameworkCore;
using project.Data.Context;
using project.Data.Interfaces;

namespace project.Data.Repositories
{
    public class ProductRepository: GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public Task<Product> GetProductByIdAsync(int id)
        {
            return GetAll().FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}