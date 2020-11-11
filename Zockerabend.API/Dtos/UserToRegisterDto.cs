using System.ComponentModel.DataAnnotations;

namespace Zockerabend.API.Dtos
{
    public class UserToRegisterDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "You must specifiy a password between 4 and 20 characters.")]
        public string Password { get; set; }
    }
}
