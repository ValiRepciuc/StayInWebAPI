using System.ComponentModel.DataAnnotations;

namespace StayIn.DTO.Account
{
    public class ResetPasswordDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [Required]
        public string? ConfirmedPassword { get; set; }
    }
}
