using System.ComponentModel.DataAnnotations;

namespace StayInAPI.Models
{
    public class Customer_Adress
    {
        public int CaId { get; set; }

        public ICollection<Order>? Order { get; set; }

        public Customer? Customer { get; set; }

        public string CustomerId { get; set; }

        public Adress? Adress { get; set; }

        public int AdressId { get; set; }
    }
}
