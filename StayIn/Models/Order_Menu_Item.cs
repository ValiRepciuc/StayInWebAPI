using System.ComponentModel.DataAnnotations;

namespace StayInAPI.Models
{
    public class Order_Menu_Item
    {
        public int Id { get; set; }
        public int QtyOrdered { get; set; }
        
        public Order Order { get; set; }
        public int OrderId { get; set; }
        public Menu_Item Menu_Item { get; set; }
        public int MenuItemId { get; set; }
    }
}
