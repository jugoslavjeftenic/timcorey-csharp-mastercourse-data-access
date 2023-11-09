namespace T41_01_01_DataAccessLibrary.Models
{
	public class ContactModel
	{
		public string FirstName { get; set; } = "";
		public string LastName { get; set; } = "";
		public List<string> PhoneNumbers { get; set; } = new();
		public List<string> EmailAddresses { get; set; } = new();
	}
}
