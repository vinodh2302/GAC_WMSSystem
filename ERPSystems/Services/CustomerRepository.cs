using WMSSystems.Models;

namespace WMSSystems.Services
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly List<Customer> _customers = new List<Customer>();
        public Task<Customer> GetCustomerByIdAsync(string customerId)
        {
            var customer = _customers.FirstOrDefault(c => c.customerId == customerId);
            return Task.FromResult(customer);
        }
        public Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return Task.FromResult(_customers.AsEnumerable());
        }
        public Task AddCustomerAsync(Customer customer)
        {
            _customers.Add(customer);
            return Task.CompletedTask;
        }
        public Task UpdateCustomerAsync(Customer customer)
        {
            var existingCustomer = _customers.FirstOrDefault(c => c.customerId == customer.customerId);
            if (existingCustomer != null)
            {
                existingCustomer.customerName = customer.customerName;
                existingCustomer.customerAddressLine1 = customer.customerAddressLine1;
                existingCustomer.customerAddressLine2 = customer.customerAddressLine2;
                existingCustomer.customerAddressCity = customer.customerAddressCity;
                existingCustomer.customerAddressState = customer.customerAddressState;
                existingCustomer.customerAddressZip = customer.customerAddressZip;
            }
            return Task.CompletedTask;
        }
        public Task DeleteCustomerAsync(string customerId)
        {
            var customer = _customers.FirstOrDefault(c => c.customerId == customerId);
            if (customer != null)
            {
                _customers.Remove(customer);
            }
            return Task.CompletedTask;
        }
    }
}
