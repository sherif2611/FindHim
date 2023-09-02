using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Project1.Models
{
    public class MissingPerson
    {
        public int Id { get; set; }
        [MinLength(2)]
        public string ?Name { get; set; }
        [AllowNull]
        public int Age { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
        [Required]
        public string FoundCity { get; set;}
        public string FoundGovern { get; set; }
        [Required]
        public string Address_Govern { get; set; }
		[Required]
		public string Address_City { get; set; }
		[Required]
        public byte[] Image { get; set; }
        public int UserId { get; set; }
        public User ?User { get; set; }
    }
}
