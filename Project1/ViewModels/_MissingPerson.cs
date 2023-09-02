using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Project1.ViewModels
{
	public class _MissingPerson
	{
		[MinLength(2,ErrorMessage ="Min Length is 2 characters")]
		public string? Name { get; set; }
		public int Age { get; set; } 
		[Required]
		public string Gender { get; set; }
		[Required]
		public DateTime Date { get; set; }
		[Required]
		[Phone]
		public string Phone { get; set; }
		[Required]
		public string FoundCity { get; set; }
		[Required]
		public string FoundGovern { get; set; }
		[Required]
		public string Address_Govern { get; set; }
		[Required]
		public string Address_City { get; set; }
		[Required]
		public IFormFile Image { get; set; }
	}
}
