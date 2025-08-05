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
      


    }
}