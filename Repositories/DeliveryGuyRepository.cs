using Microsoft.EntityFrameworkCore;
using StayIn.DTO.Delivery_GuyDto;
using StayIn.Interfaces;
using StayInAPI.Data;
using StayInAPI.Models;

namespace StayIn.Repositories
{
    public class DeliveryGuyRepository : IDeliveryGuyRepository
    {

        private readonly ApplicationDbContext _context;
        public DeliveryGuyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Delivery_Guy> AddDeliveryGuyAsync(Delivery_Guy deliveryGuy)
        {
            _context.Delivery_Guy.Add(deliveryGuy);
            await _context.SaveChangesAsync();
            return deliveryGuy;

        }

        public async Task<bool> DeleteDeliveryGuyAsync(int id)
        {
            var deliveryGuy = await _context.Delivery_Guy.FindAsync(id);
            if(deliveryGuy == null)
            {
                return false;
            }

            _context.Delivery_Guy.Remove(deliveryGuy);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeliveryGuyExistsAsync(int id)
        {
            return await _context.Delivery_Guy.AnyAsync(e => e.DeliveryGuyId == id);
        }

        public async Task<Delivery_Guy> GetDeliveryGuyByIdAsync(int id)
        {
            return await _context.Delivery_Guy.FindAsync(id);
        }

        public async Task<IEnumerable<Delivery_Guy>> GetDeliveryGuysAsync()
        {
            return await _context.Delivery_Guy.ToListAsync();
        }

        public async Task<Delivery_Guy> UpdateDeliveryGuyAsync(Delivery_GuyDto deliveryGuy, int id)
        {
            var existingDeliveryGuy = await _context.Delivery_Guy.FindAsync(id);
            if(existingDeliveryGuy == null)
            {
                return null;
            }
            _context.Entry(existingDeliveryGuy).CurrentValues.SetValues(deliveryGuy);
            await _context.SaveChangesAsync();
            return existingDeliveryGuy;
        }
    }
}
