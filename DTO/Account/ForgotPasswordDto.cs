using System.ComponentModel.DataAnnotations;

namespace StayIn.DTO.Account
{
    public class ForgotPasswordDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
