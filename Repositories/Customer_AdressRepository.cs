using Microsoft.EntityFrameworkCore;
using StayIn.Interfaces;
using StayInAPI.Data;
using StayInAPI.Models;

namespace StayIn.Repositories
{
    public class Customer_AdressRepository : ICustomer_AdressRepository
    {
        private readonly ApplicationDbContext _context;

        public Customer_AdressRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Customer_Adress> AddCustomerAdressAsync(Customer_Adress customer_adress)
        {
            _context.Customer_Adress.Add(customer_adress);
            await _context.SaveChangesAsync();
            return customer_adress;
        }

        public async Task<bool> CustomerAdressExistsAsync(int id)
        {
            return await _context.Customer_Adress.AnyAsync(e => e.CaId == id);
        }

        public async Task<bool> DeleteCustomerAdressAsync(int id)
        {
            var customer_adress = await _context.Customer_Adress.FindAsync(id);
            if(customer_adress == null)
            {
                return false;
            }

            _context.Customer_Adress.Remove(customer_adress);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Customer_Adress> GetCustomerAdressByIdAsync(int id)
        {
            return await _context.Customer_Adress.FindAsync(id);
        }

        public async Task<IEnumerable<Customer_Adress>> GetCustomerAdressesAsync()
        {
            return await _context.Customer_Adress.ToListAsync();
        }

        public async Task<Customer_Adress> UpdateCustomerAdressAsync(int id, Customer_Adress customer_adress)
        {
            var existingCustomerAdress = await _context.Customer_Adress.FindAsync(id);
            if(existingCustomerAdress == null)
            {
                return null;
            }

            _context.Entry(existingCustomerAdress).CurrentValues.SetValues(customer_adress);
            await _context.SaveChangesAsync();
            return existingCustomerAdress;
        }
    }
}
