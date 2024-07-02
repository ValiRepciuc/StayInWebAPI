using System.ComponentModel.DataAnnotations;

namespace StayIn.DTO.Account
{
    public class ChangePasswordDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
    }
}
