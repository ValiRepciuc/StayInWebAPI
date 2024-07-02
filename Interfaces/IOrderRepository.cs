using StayIn.DTO.Order;
using StayInAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StayInAPI.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetOrdersAsync();
        Task<Order> GetOrderByIdAsync(int id);
        Task<Order> AddOrderAsync(Order order);
        Task<Order> UpdateOrderAsync(OrderDto orderDto, int id);
        Task<bool> DeleteOrderAsync(int id);
        Task<bool> OrderExistsAsync(int id);
    }
}
