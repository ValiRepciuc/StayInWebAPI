using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StayIn.DTO.Restaurant;
using StayIn.Interfaces;
using StayInAPI.Data;
using StayInAPI.Models;

namespace StayIn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IRestaurantRepository _restaurantRepository;

        public RestaurantController(ApplicationDbContext context, IRestaurantRepository restaurantRepository)
        {
            _context = context;
            _restaurantRepository = restaurantRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetRestaurants()
        {
            var restaurants = await _restaurantRepository.GetRestaurantAsync();
            return Ok(restaurants);
        }
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetRestaurant(int id)
        {
            var restaurant = await _restaurantRepository.GetRestaurantByIdAsync(id);
            if(restaurant == null)
            {
                return NotFound(new { message = $"Restaurantul cu id-ul {id} nu exista" });
            }
            return Ok(restaurant);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PostRestaurant([FromBody] Restaurant restaurant)
        {
            var createdRestaurant = await _restaurantRepository.AddResturantAsync(restaurant);
            return CreatedAtAction(nameof(GetRestaurant), new { id = createdRestaurant.RestaurantId }, createdRestaurant);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PutRestaurant([FromBody]RestaurantDto restaurant, int id)
        {
            var restaurantModel = _context.Restaurant.FirstOrDefault(x => x.RestaurantId == id);
            if(restaurantModel == null)
            {
                return NotFound(new { message = "Restaurantul nu a fost gasit" });
            }

            restaurantModel.Number = restaurant.Number;
            restaurantModel.RestaurantName = restaurant.RestaurantName;
            restaurantModel.AdressId = restaurant.AdressId;

            _context.SaveChanges();
            return Ok(new {message = $"Restaurantul cu id-ul {id} s-a modificat cu succes"});
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteRestaurant(int id)
        {
            var restaurantExists = await _restaurantRepository.RestaurantExistsAsync(id);
            if (!restaurantExists)
            {
                return NotFound(new { message = "Restaurantul nu a fost gasit" });
            }
            await _restaurantRepository.DeleteRestaurantAsync(id);
            return Ok(new { message = $"Restaurantul cu id-ul {id} s-a sters cu succes!" });
        }
    }
}
