using ERPSystems.Models;

namespace ERPSystems.Services
{
    public interface ICustomerRepository
    {
        Task<Customer> GetCustomerByIdAsync(string customerId);
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task AddCustomerAsync(Customer customer);
        Task UpdateCustomerAsync(Customer customer);
        Task DeleteCustomerAsync(string customerId);
    }
}
