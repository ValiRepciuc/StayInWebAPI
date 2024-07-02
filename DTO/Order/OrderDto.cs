using StayInAPI.Models;

namespace StayIn.DTO.Order
{
    public class OrderDto
    {

        public int Number { get; set; }
        public DateTime? Date { get; set; }
        public int CustomerId { get; set; }
        public int RestaurantId { get; set; }
        public int DeliveryGuyId { get; set; }
        public int CustomerAdressId { get; set; }
    }
}
