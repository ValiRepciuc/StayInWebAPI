using System.ComponentModel.DataAnnotations;

namespace StayIn.DTO.Account
{
    public class NewCustomerDto 
    {
        [Required]
        public string Username {  get; set; }
        [Required]

        public string Email {  get; set; }
        [Required]
        public string FirstName {  get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Token { get; set; }
    }
}
