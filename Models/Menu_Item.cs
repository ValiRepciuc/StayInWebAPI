using System.ComponentModel.DataAnnotations;

namespace StayInAPI.Models
{
    public class Menu_Item
    {

        public int MenuItemId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public ICollection<Order_Menu_Item>? Order_Menu_Item {  get; set; }

        public Restaurant? Restaurant { get; set; }
        public int RestaurantId { get; set; }
    }
}
