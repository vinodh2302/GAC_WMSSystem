using WMSSystems.Models;
using WMSSystems.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks; // Needed for async/await
using System.Collections.Generic; // Needed for List<T>

namespace WMSSystems.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        [Route("customers")]
        public async Task<List<Customer>> GetCustomers()
        {
            var customers = await _customerService.GetAllCustomersAsync();
            return customers.ToList();
        }

        [HttpGet]
        [Route("customers/{id}")]
        public async Task<ActionResult<Customer>> GetCustomerById(string id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);
            if (customer == null)
                return NotFound();
            return Ok(customer);
        }

        // POST: api/customers
        [HttpPost]
        [Route("customers")]
        public async Task<ActionResult<Customer>> CreateCustomer([FromBody] Customer customer)
        {
            await _customerService.AddCustomerAsync(customer);
            return CreatedAtAction(nameof(GetCustomerById), new { id = customer.customerId }, customer);
        }


        

    }
}