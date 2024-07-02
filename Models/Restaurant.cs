using System.ComponentModel.DataAnnotations;

namespace StayInAPI.Models
{
    public class Restaurant
    {
        public int RestaurantId { get; set; }
        public int Number {  get; set; }
        public string? RestaurantName { get; set; }
        public ICollection<Menu_Item>? Menu_Item {  get; set; }
        public ICollection<Order>? Order { get; set; }

        public Adress? Adress { get; set; }
        public int AdressId { get; set; }
    }
}
