using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace T40_02_01_DataAccessLibrary.Models
{
	public class ContactModel
	{
		[BsonId]
		[JsonProperty(PropertyName = "id")]
		public Guid Id { get; set; } = Guid.NewGuid();
		public string FirstName { get; set; } = "";
		public string LastName { get; set; } = "";
		public List<EmailAddressModel> EmailAddresses { get; set; } = new();
		public List<PhoneNumberModel> PhoneNumbers { get; set; } = new();
	}
}
