using Microsoft.EntityFrameworkCore;
using StayIn.DTO.Country;
using StayIn.Interfaces;
using StayInAPI.Data;
using StayInAPI.Models;

namespace StayIn.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationDbContext _context;
        public CountryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Country> AddCountryAync(Country country)
        {
            _context.Country.Add(country);
            await _context.SaveChangesAsync();
            return country;
        }

        public async Task<bool> CountryExistsAsync(int id)
        {
            return await _context.Country.AnyAsync(e => e.CountryId == id);
        }

        public async Task<bool> DeleteCoutryAsync(int id)
        {
            var country = await _context.Country.FindAsync(id);
            if(country == null)
            {
                return false;
            }
            _context.Country.Remove(country);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Country>> GetCountryAsync()
        {
            return await _context.Country.ToListAsync();
        }

        public async Task<Country> GetCountryByIdAsync(int id)
        {
            return await _context.Country.FindAsync(id);
        }

        public async Task<Country> UpdateCountryAync(CountryDto country, int id)
        {
            var existingCountry = await _context.Country.FindAsync(id);
            if(existingCountry == null)
            {
                return null;
            }

            _context.Entry(existingCountry).CurrentValues.SetValues(country);
            await _context.SaveChangesAsync();
            return existingCountry;
        }
    }
}
