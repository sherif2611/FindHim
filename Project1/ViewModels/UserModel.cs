using System.ComponentModel.DataAnnotations;

namespace Project1.ViewModels
{
    public class UserModel
    {
        [Required]
        [MinLength(6, ErrorMessage = "Min Length is 6 characters")]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(8, ErrorMessage = "Min Length is 8 characters")]
        public string Password { get; set; }
        [Required]
        public string CoPassword { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
    }
}
