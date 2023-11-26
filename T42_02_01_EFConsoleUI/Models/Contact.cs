using System.ComponentModel.DataAnnotations;

namespace T42_02_01_EFConsoleUI.Models
{
	public class Contact
	{
		public int Id { get; set; }

		[Required]
		[MaxLength(50)]
		public string FirstName { get; set; } = "";

		[Required]
		[MaxLength(50)]
		public string LastName { get; set; } = "";

		public List<Email> EmailAddresses { get; set; } = new();

		public List<Phone> PhoneNumbers { get; set; } = new();
	}
}
