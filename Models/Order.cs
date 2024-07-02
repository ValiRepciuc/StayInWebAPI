using System.ComponentModel.DataAnnotations;

namespace StayInAPI.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public ICollection<Order_Menu_Item>? Order_Menu_Item { get; set; }
        
        public Customer? Customer { get; set; }
        public string CustomerId {  get; set; }
        public Restaurant? Restaurant { get; set; }
        public int RestaurantId {  get; set; }
        public Delivery_Guy? Delivery_Guy { get; set; }
        public int DeliveryGuyId { get; set; }
        public Customer_Adress? Customer_Adress { get; set; }
        public int CustomerAdressId { get; set; }
    }
}
