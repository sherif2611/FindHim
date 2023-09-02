using System.ComponentModel.DataAnnotations;

namespace Project1.ViewModels
{
    public class UserModel
    {
        [MinLength(6)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(8)]
        public string Password { get; set; }
        [Required]
        [MinLength(8)]
        public string CoPassword { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
    }
}
