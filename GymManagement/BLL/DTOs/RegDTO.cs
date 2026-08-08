using BLL.Validations;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs
{
    public class RegDTO
    {
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Name { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [UniqueUname]
        public string Username { get; set; }

        [Required]
        [PasswordMatch]
        public string ConfPassword { get; set; }
    }
}