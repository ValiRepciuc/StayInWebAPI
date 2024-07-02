using Microsoft.AspNetCore.Identity;
using StayInAPI.Models;

namespace StayIn.Models
{
    public class User : IdentityUser
    {
        public int CustomerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<Order>? Order { get; set; }
        public ICollection<Customer_Adress>? Customer_Adress { get; set; }
    }
}
