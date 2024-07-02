using StayIn.DTO.Order_Menu_Items;
using StayInAPI.Models;

namespace StayIn.Interfaces
{
    public interface IOrderMenuItemRepository
    {
        Task<IEnumerable<Order_Menu_Item>> GetAllAsync();
        Task<Order_Menu_Item> GetByIdASync(int id);
        Task<Order_Menu_Item> AddAsync(Order_Menu_Item item);
        Task<Order_Menu_Item> UpdateAsync(Order_Menu_ItemsDto itemDto, int id);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
