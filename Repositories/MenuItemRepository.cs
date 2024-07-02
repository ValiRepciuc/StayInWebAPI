using Microsoft.EntityFrameworkCore;
using StayIn.DTO.Menu_Item;
using StayIn.Interfaces;
using StayInAPI.Data;
using StayInAPI.Models;

namespace StayIn.Repositories
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private readonly ApplicationDbContext _context;
        public MenuItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Menu_Item> AddMenuItemAsync(Menu_Item item)
        {
            _context.Menu_Item.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<bool> DeleteMenuItemAsync(int id)
        {
            var item = await _context.Menu_Item.FindAsync(id);
            if(item == null)
            {
                return false;
            }
            return true;
        }

        public async Task<IEnumerable<Menu_Item>> GetMenuItemAsync()
        {
            return await _context.Menu_Item.ToListAsync();
        }

        public async Task<Menu_Item> GetMenuItemByIdAsync(int id)
        {
            return await _context.Menu_Item.FindAsync(id);
        }

        public async Task<bool> MenuItemExistsAsync(int id)
        {
            return await _context.Menu_Item.AnyAsync(e => e.RestaurantId == id);
        }
        public async Task<Menu_Item> UpdateMenuItemAsync(Menu_ItemDto item, int id)
        {
            var existingItem = await _context.Menu_Item.FindAsync(id);
            if(existingItem == null)
            {
                return null;
            }
            _context.Entry(existingItem).CurrentValues.SetValues(item);
            await _context.SaveChangesAsync();
            return existingItem;
        }
    }
}

