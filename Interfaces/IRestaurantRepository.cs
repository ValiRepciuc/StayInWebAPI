using StayIn.DTO.Restaurant;
using StayInAPI.Models;

namespace StayIn.Interfaces
{
    public interface IRestaurantRepository
    {
        Task<IEnumerable<Restaurant>> GetRestaurantAsync();
        Task<Restaurant> GetRestaurantByIdAsync(int id);
        Task<Restaurant> AddResturantAsync(Restaurant restaurant);
        Task<Restaurant> UpdateRestaurantAsync(RestaurantDto restaurantDto, int id);
        Task<bool> DeleteRestaurantAsync(int id);
        Task<bool> RestaurantExistsAsync(int id);
    }
}
