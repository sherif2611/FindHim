using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Project1.ViewModels
{
    public class Information
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public DateTime Date { get; set; }
        public string Phone { get; set; }
        public string FoundCity { get; set; }
        public string FoundGovern { get; set; }
        public string Address_Govern { get; set; }
        public string Address_City { get; set; }
        public byte[] Image { get; set; }
        public string UserName { get; set; }
    }
}
