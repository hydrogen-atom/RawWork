using System.ComponentModel.DataAnnotations;

namespace sqlTest.Server.Models
{
    public class LoginDto
    {
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Username { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 6)]
        public string Password { get; set; }
    }
}
