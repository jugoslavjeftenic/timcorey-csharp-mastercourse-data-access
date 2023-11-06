using Microsoft.Extensions.Configuration;
using T40_02_01_DataAccessLibrary;
using T40_02_01_DataAccessLibrary.Models;

namespace T40_03_01_CosmosDbUI
{
	public class Program
	{
		private static CosmosDbDataAccess? _db;

		static async Task Main(string[] args)
		{
			var (endpointUrl, primaryKey, databaseName, containerName) = GetCosmosInfo();
			_db = new CosmosDbDataAccess(endpointUrl, primaryKey, databaseName, containerName);

			ContactModel user1 = new()
			{
				FirstName = "Tim",
				LastName = "Corey"
			};
			user1.EmailAddresses.Add(new EmailAddressModel { EmailAddress = "tim@iamtimcorey.com" });
			user1.EmailAddresses.Add(new EmailAddressModel { EmailAddress = "me@timothycorey.com" });
			user1.PhoneNumbers.Add(new PhoneNumberModel { PhoneNumber = "555-1212" });
			user1.PhoneNumbers.Add(new PhoneNumberModel { PhoneNumber = "555-1234" });

			ContactModel user2 = new()
			{
				FirstName = "Charity",
				LastName = "Corey"
			};
			user2.EmailAddresses.Add(new EmailAddressModel { EmailAddress = "nope@aol.com" });
			user2.EmailAddresses.Add(new EmailAddressModel { EmailAddress = "me@timothycorey.com" });
			user2.PhoneNumbers.Add(new PhoneNumberModel { PhoneNumber = "555-1212" });
			user2.PhoneNumbers.Add(new PhoneNumberModel { PhoneNumber = "555-9876" });

			//await CreateContact(user1);
			//await CreateContact(user2);

			//await UpdateContactsFirstName("Timothy", "dba2e7c5-9c5d-4b9d-b530-1127cf2afc56");
			//await RemovePhoneNumberFromUser("555-1212", "dba2e7c5-9c5d-4b9d-b530-1127cf2afc56");

			await RemoveUser("dba2e7c5-9c5d-4b9d-b530-1127cf2afc56", "Corey");

			//await GetContactById("dba2e7c5-9c5d-4b9d-b530-1127cf2afc56");
			await GetAllContacts();
		}

		public static async Task CreateContact(ContactModel contact)
		{
			await _db!.UpsertRecordAsync(contact);
		}

		public static async Task GetAllContacts()
		{
			var contacts = await _db!.LoadRecordsAsync<ContactModel>();

			foreach (var contact in contacts)
			{
				Console.WriteLine($"{contact.Id}: {contact.FirstName} {contact.LastName}");
			}
		}

		public static async Task UpdateContactsFirstName(string firstName, string id)
		{
			var contact = await _db!.LoadRecordByIdAsync<ContactModel>(id);

			contact.FirstName = firstName;

			await _db!.UpsertRecordAsync(contact);
		}

		public static async Task RemovePhoneNumberFromUser(string phoneNumber, string id)
		{
			var contact = await _db!.LoadRecordByIdAsync<ContactModel>(id);

			contact.PhoneNumbers = contact.PhoneNumbers.Where(x => x.PhoneNumber != phoneNumber).ToList();

			await _db!.UpsertRecordAsync(contact);
		}

		public static async Task RemoveUser(string id, string lastName)
		{
			await _db!.DeleteRecordAsync<ContactModel>(id, lastName);
		}

		public static async Task GetContactById(string id)
		{
			var contact = await _db!.LoadRecordByIdAsync<ContactModel>(id);
			Console.WriteLine($"{contact.Id}: {contact.FirstName} {contact.LastName}");
		}

		public static
			(string endpointUrl, string primaryKey, string databaseName, string containerName)
			GetCosmosInfo()
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json");
			var config = builder.Build();

			(string endpointUrl, string primaryKey, string databaseName, string containerName) output;

			output.endpointUrl = config.GetValue<string>("CosmosDB:EndpointUrl")!;
			output.primaryKey = config.GetValue<string>("CosmosDB:PrimaryKey")!;
			output.databaseName = config.GetValue<string>("CosmosDB:DatabaseName")!;
			output.containerName = config.GetValue<string>("CosmosDB:ContainerName")!;

			return output;
		}
	}
}