using System.ComponentModel.DataAnnotations;

namespace StayInAPI.Models
{
    public class Adress
    {
        public int AdressId {  get; set; }
        public int StreetNumber { get; set; }
        public int ZIP { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public ICollection<Customer_Adress>? Customer_Adress { get; set; }
        public ICollection<Restaurant>? Restaurant {  get; set; }

        public Country? Country { get; set; }
        public int CountryId {  get; set; }
    }
}
