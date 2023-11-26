using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace T42_02_01_EFConsoleUI.Models
{
	public class Phone
	{
		public int Id { get; set; }

		[Required]
		public int ContactId { get; set; }

		[Required]
		[MaxLength(20)]
		[Column(TypeName = "varchar(20)")]
		public string PhoneNumber { get; set; } = "";
	}
}
