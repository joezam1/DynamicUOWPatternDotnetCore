
using System.Collections.Generic;
using project.Data.Models;
using System.Threading.Tasks;
using project.Data.Interfaces;

namespace project.Service.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            return await _customerRepository.GetAllCustomersAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await _customerRepository.GetCustomerByIdAsync(id);
        }

        public async Task<Customer> AddCustomerAsync(Customer newCustomer)
        {
            var result = await _customerRepository.AddAsync(newCustomer);
            return result;
        }
        public async Task<Customer> UpdateCustomerAsync(Customer existingCustomer)
        {
            var result = await _customerRepository.UpdateAsync(existingCustomer);
            return result;
        }

         public async Task<Customer> DeleteCustomerAsync(int id)
        {
            var result = await _customerRepository.DeleteAsync(id);
            return result;
        }

    }
}