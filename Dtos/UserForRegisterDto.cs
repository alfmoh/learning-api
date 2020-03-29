using System.ComponentModel.DataAnnotations;

namespace Learning_Api.Dtos
{
    public class UserForRegisterDto
    {
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [StringLength(12, MinimumLength = 8, ErrorMessage = "You must specify a password between 8 and 12 characters")]
        public string Password { get; set; }
    }
}
