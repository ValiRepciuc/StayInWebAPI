using StayInAPI.Data;
using StayInAPI.Models;
using StayIn.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using StayIn.DTO.Adress;

namespace StayIn.Repositories
{
    public class AdressRepository : IAdressRepository
    {
        private readonly ApplicationDbContext _context;

        public AdressRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Adress>> GetAdressAsync()
        {
            return await _context.Adress.ToListAsync();
        }

        public async Task<Adress> GetAdressByIdAsync(int id)
        {
            return await _context.Adress.FindAsync(id);
        }

        public async Task<Adress> AddAdressAsync(Adress adress)
        {
            _context.Adress.Add(adress);
            await _context.SaveChangesAsync();
            return adress;
        }

        public async Task<Adress> UpdateAdressAsync(int id, AdressDto adress)
        {
            var existingAdress = await _context.Adress.FindAsync(id);
            if (existingAdress == null)
            {
                return null;
            }

            _context.Entry(existingAdress).CurrentValues.SetValues(adress);
            await _context.SaveChangesAsync();
            return existingAdress;
        }

        public async Task<bool> DeleteAdressAsync(int id)
        {
            var adress = await _context.Adress.FindAsync(id);
            if (adress == null)
            {
                return false;
            }

            _context.Adress.Remove(adress);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AdressExistsAsync(int id)
        {
            return await _context.Adress.AnyAsync(e => e.AdressId == id);
        }
    }
}
