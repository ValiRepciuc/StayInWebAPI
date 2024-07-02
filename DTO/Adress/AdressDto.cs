using StayInAPI.Models;

namespace StayIn.DTO.Adress
{
    public class AdressDto
    {
        public int StreetNumber { get; set; }
        public int ZIP { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
    }
}
