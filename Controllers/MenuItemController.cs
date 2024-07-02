using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StayIn.DTO.Menu_Item;
using StayIn.Interfaces;
using StayIn.Repositories;
using StayInAPI.Data;
using StayInAPI.Models;

namespace StayIn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMenuItemRepository _repository;

        public MenuItemController(ApplicationDbContext context, IMenuItemRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetMenuItems()
        {
            var items = await _repository.GetMenuItemAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetMenuItem(int id)
        {
            var item = await _repository.GetMenuItemByIdAsync(id);
            if(item == null)
            {
                return NotFound(new { message = $"Item-ul din meniu cu id-ul {id} nu exista" });
            }
            return Ok(item);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PostMenuItem([FromBody] Menu_Item item)
        {
            var createdItem = await _repository.AddMenuItemAsync(item);
            return CreatedAtAction(nameof(GetMenuItem), new { id = createdItem.MenuItemId }, createdItem);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PutMenuItem([FromBody]Menu_ItemDto item, int id)
        {
           var menuItemModel = _context.Menu_Item.FirstOrDefault(x=>x.MenuItemId == id);
            if(menuItemModel == null)
            {
                return NotFound(new { message = "Item-ul nu a fost gasit" });
            }
            menuItemModel.Name = item.Name;
            menuItemModel.Price = item.Price;
            menuItemModel.RestaurantId = item.RestaurantId;

            _context.SaveChanges();
            return Ok(new { message = $"Item-ul cu id-ul {id} s-a modificat cu succes" });

        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteMenuItem(int id)
        {
            var itemExists = await _repository.MenuItemExistsAsync(id);
            if (!itemExists)
            {
                return NotFound(new { message = "Item-ul nu a fost gasit" });
            }
            await _repository.DeleteMenuItemAsync(id);
            return Ok(new { message = $"Item-ul cu id-ul {id} s-a sters cu succes" });
        }
    }
}