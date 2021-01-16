using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using project.Data.Models;

namespace project.Service.Services
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetAllCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int id);
        Task<Customer> AddCustomerAsync(Customer newCustomer);
        Task<Customer> UpdateCustomerAsync(Customer existingCustomer);
        Task<Customer> DeleteCustomerAsync(int id);
    }
}

