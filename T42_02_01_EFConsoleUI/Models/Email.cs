using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T42_02_01_EFConsoleUI.Models
{
	public class Email
	{
		public int Id { get; set; }

		[Required]
		public int ContactId { get; set; }

		[Required]
		[MaxLength(100)]
		[Column(TypeName = "varchar(100)")]
		public string EmailAddress { get; set; } = "";
	}
}
