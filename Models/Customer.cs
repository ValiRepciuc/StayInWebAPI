using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace StayInAPI.Models
{
    public class Customer : IdentityUser
    {

        [CustomerValidation]
        public string FirstName { get; set; }

        [CustomerValidation]
        public string LastName { get; set; }

        public ICollection<Order>? Order { get; set; }
        public ICollection<Customer_Adress>? Customer_Adress { get; set; }
    }
}
