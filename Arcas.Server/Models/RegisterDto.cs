using System.ComponentModel.DataAnnotations;

namespace sqlTest.Server.Models
{
    public class RegisterDto
    {
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Username { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        [StringLength(30)]
        public string Nickname { get; set; }

        [Required]
        [StringLength(30)]
        [Compare("Password", ErrorMessage = "密码和确认密码不匹配。")]
        public string ConfirmPassword { get; set; }
    }
}
