
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using project.Data.Models;
using project.Service.Services;


namespace project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController: ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("customer/{id:}")]
        public async Task<ActionResult<Customer>> GetSingleCustomer(int id)
        {
             var result= await _customerService.GetCustomerByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("customer/all")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetAllCustomers()
        {
            var result= await _customerService.GetAllCustomersAsync();
            return Ok(result);
        }

        [HttpPost("customer")]
        public async Task<ActionResult<Customer>> CreateCustomer(Customer customer)
        {
            var selectedCustomer = customer;
            var result= await _customerService.AddCustomerAsync(customer);
            return result;
        }

        [HttpPut("customer")]
        public async Task<ActionResult<Customer>> UpdateCustomer(Customer customer)
        {
            var selectedCustomer = customer;
            var result= await _customerService.UpdateCustomerAsync(customer);
            return result;
        }

        [HttpDelete("customer/{id:}")]
        public async Task<ActionResult<Customer>> DeleteCustomer(int id)
        {
            var result= await _customerService.DeleteCustomerAsync(id);
            return result;
        }


    }
}