using Microsoft.EntityFrameworkCore;
using StayIn.DTO.Order_Menu_Items;
using StayIn.Interfaces;
using StayInAPI.Data;
using StayInAPI.Models;

namespace StayIn.Repositories
{
    public class OrderMenuItemRepository : IOrderMenuItemRepository
    {
        private readonly ApplicationDbContext _context;
        public OrderMenuItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Order_Menu_Item> AddAsync(Order_Menu_Item item)
        {
            _context.Order_Menu_Item.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var orderItem = await _context.Order_Menu_Item.FindAsync(id);
            if(orderItem == null) {
            return false;
            }
            _context.Order_Menu_Item.Remove(orderItem);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Order_Menu_Item.AnyAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<Order_Menu_Item>> GetAllAsync()
        {
            return await _context.Order_Menu_Item.ToListAsync();
        }

        public async Task<Order_Menu_Item> GetByIdASync(int id)
        {
            return await _context.Order_Menu_Item.FindAsync(id);
        }

        public async Task<Order_Menu_Item> UpdateAsync(Order_Menu_ItemsDto item, int id)
        {
            var existingOrderItem = await _context.Order_Menu_Item.FindAsync(id);
            if(existingOrderItem == null)
            {
                return null;
            }
            _context.Entry(existingOrderItem).CurrentValues.SetValues(item);
            await _context.SaveChangesAsync();
            return existingOrderItem;
        }
    }
}
