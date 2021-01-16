using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using project.Data.Models;
using Microsoft.EntityFrameworkCore;
using project.Data.Context;
using project.Data.Interfaces;

namespace project.Data.Repositories
{
    public class CustomerRepository: GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DataContext dataContext)
        :base(dataContext)
        {
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await GetAll().FirstOrDefaultAsync(x =>x.Id == id);
        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            return await GetAll().ToListAsync();
        }
    }

}