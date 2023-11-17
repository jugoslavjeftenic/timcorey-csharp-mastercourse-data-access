namespace T42_01_01_LinqUI.Models
{
	public class AddressModel
	{
		public int Id { get; set; }
		public int ContactId { get; set; }
		public string City { get; set; } = "";
		public string State { get; set; } = "";
	}
}
