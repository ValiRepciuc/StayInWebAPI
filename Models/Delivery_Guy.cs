using System.ComponentModel.DataAnnotations;

namespace StayInAPI.Models
{
    public class Delivery_Guy
    {
        public int DeliveryGuyId {  get; set; }
        public string Name { get; set; }
        public int CNP { get; set; }
        public int Number {  get; set; }

        public ICollection<Order>? Order { get; set; }
    }
}
