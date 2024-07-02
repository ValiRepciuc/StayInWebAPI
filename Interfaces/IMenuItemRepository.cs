using StayIn.DTO.Menu_Item;
using StayInAPI.Models;

namespace StayIn.Interfaces
{
    public interface IMenuItemRepository
    {
        Task<IEnumerable<Menu_Item>> GetMenuItemAsync();
        Task<Menu_Item> GetMenuItemByIdAsync(int id);
        Task<Menu_Item> AddMenuItemAsync(Menu_Item item);
        Task<Menu_Item> UpdateMenuItemAsync(Menu_ItemDto itemDto, int id);
        Task<bool> DeleteMenuItemAsync(int id);
        Task<bool> MenuItemExistsAsync(int id);
    }
}
