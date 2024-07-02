using Microsoft.EntityFrameworkCore;
using StayIn.DTO.Restaurant;
using StayIn.Interfaces;
using StayInAPI.Data;
using StayInAPI.Models;

namespace StayIn.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly ApplicationDbContext _context;
        public RestaurantRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> DeleteRestaurantAsync(int id)
        {
            var restaurant = await _context.Restaurant.FindAsync(id);
            if(restaurant == null)
            {
                return false;
            }
           
            _context.Restaurant.Remove(restaurant);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Restaurant>> GetRestaurantAsync()
        {
            return await _context.Restaurant.ToListAsync();
        }

        public async Task<Restaurant> GetRestaurantByIdAsync(int id)
        {
            return await _context.Restaurant.FindAsync(id);
        }

        public async Task<Restaurant> AddResturantAsync(Restaurant restaurant)
        {
            _context.Restaurant.Add(restaurant);
            await _context.SaveChangesAsync();
            return restaurant;

        }

        public async Task<bool> RestaurantExistsAsync(int id)
        {
            return await _context.Restaurant.AnyAsync(e => e.RestaurantId == id);
        }

        public async Task<Restaurant> UpdateRestaurantAsync(RestaurantDto restaurant, int id)
        {
            var existingRestaurant = await _context.Restaurant.FindAsync(id);
            if(existingRestaurant == null)
            {
                return null;
            }

            _context.Entry(existingRestaurant).CurrentValues.SetValues(restaurant);
            await _context.SaveChangesAsync();
            return existingRestaurant;
        }
    }
}
