using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using project.Data.Models;
using project.Data.Repositories;

namespace project.Data.Interfaces
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Task<Customer> GetCustomerByIdAsync(int id);
        
            

        Task<List<Customer>> GetAllCustomersAsync();
        
    }
}

