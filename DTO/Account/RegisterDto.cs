using System.ComponentModel.DataAnnotations;

namespace StayIn.DTO.Account
{
    public class RegisterDto
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        [CustomerValidation]
        public string FirstName { get; set; }

        [Required]
        [CustomerValidation]
        public string LastName { get; set; }
    }
}
