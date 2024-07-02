using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StayIn.DTO.Order;
using StayInAPI.Data;
using StayInAPI.Models;

namespace StayInAPI.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;
        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Order> AddOrderAsync(Order order)
        {
            _context.Order.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<bool> DeleteOrderAsync(int id)
        {
            var order = await _context.Order.FindAsync(id);
            if(order == null)
            {
                return false;
            }
            _context.Order.Remove(order);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _context.Order.FindAsync(id);
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync()
        {
            return await _context.Order.ToListAsync();
        }

        public async Task<bool> OrderExistsAsync(int id)
        {
            return await _context.Order.AnyAsync(e => e.OrderID == id);
        }

        public async Task<Order> UpdateOrderAsync(OrderDto order, int id)
        {
            var existingOrder = await _context.Order.FindAsync(id);
            if(existingOrder == null)
            {
                return null;
            }
            _context.Entry(existingOrder).CurrentValues.SetValues(order);
            await _context.SaveChangesAsync();
            return existingOrder;
        }
    }
}
