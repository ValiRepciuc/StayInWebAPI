using StayInAPI.Models;

namespace StayIn.DTO.Menu_Item
{
    public class Menu_ItemDto
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int RestaurantId { get; set; }
    }
}
