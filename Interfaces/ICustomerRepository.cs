using StayIn.DTO.Customer;
using StayInAPI.Models;

namespace StayIn.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetCustomerAsync();
        Task<Customer> GetCustomerByIdAsync(string id);
        Task<Customer> AddCustomerAsync(Customer customer);
        Task<Customer> UpdateCustomerAsync(CustomerDto customerDto, string id);
        Task<bool> DeleteCustomerAsync(string id);
        Task<bool> CustomerExistsAsync(string id);
    }
}
