using Microsoft.EntityFrameworkCore;
using StayIn.DTO.Customer;
using StayIn.Interfaces;
using StayInAPI.Data;
using StayInAPI.Models;

namespace StayIn.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;
        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
            _context.Customer.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<bool> CustomerExistsAsync(string id)
        {
            return await _context.Customer.AnyAsync(e => e.Id == id);
        }

        public async Task<bool> DeleteCustomerAsync(string id)
        {
            var customer = await _context.Customer.FindAsync(id);
            if (customer == null)
            {
                return false;
            }

            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Customer>> GetCustomerAsync()
        {
            return await _context.Customer.ToListAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(string id)
        {
            return await _context.Customer.FindAsync(id);
        }

        public async Task<Customer> UpdateCustomerAsync(CustomerDto customer, string id)
        {
            var existingCustomer = await _context.Customer.FindAsync(id);
            if (existingCustomer == null)
            {
                return null;
            }

            _context.Entry(existingCustomer).CurrentValues.SetValues(customer);
            await _context.SaveChangesAsync();
            return existingCustomer;
        }
    }
}
