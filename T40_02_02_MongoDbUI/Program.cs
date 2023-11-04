using Microsoft.Extensions.Configuration;
using T40_02_01_DataAccessLibrary;
using T40_02_01_DataAccessLibrary.Models;

namespace T40_02_02_MongoDbUI
{
	public class Program
	{
		private static MongoDbDataAccess? db;
		private static readonly string tableName = "Contacts";

		static void Main(string[] args)
		{
			db = new("MongoContactsDB", GetConnectionString());

			//ContactModel user = new()
			//{
			//	FirstName = "Tim",
			//	LastName = "Corey"
			//};
			//user.EmailAddresses.Add(new EmailAddressModel { EmailAddress = "tim@iamtimcorey.com" });
			//user.EmailAddresses.Add(new EmailAddressModel { EmailAddress = "me@timothycorey.com" });
			//user.PhoneNumbers.Add(new PhoneNumberModel { PhoneNumber = "555-1212" });
			//user.PhoneNumbers.Add(new PhoneNumberModel { PhoneNumber = "555-1234" });

			ContactModel user = new()
			{
				FirstName = "Charity",
				LastName = "Corey"
			};
			user.EmailAddresses.Add(new EmailAddressModel { EmailAddress = "nope@aol.com" });
			user.EmailAddresses.Add(new EmailAddressModel { EmailAddress = "me@timothycorey.com" });
			user.PhoneNumbers.Add(new PhoneNumberModel { PhoneNumber = "555-1212" });
			user.PhoneNumbers.Add(new PhoneNumberModel { PhoneNumber = "555-9876" });

			//CreateContact(user);
			//UpdateContactsFirstName("Timothy", "eebcada5-4565-4966-af05-bda9c053c78e");
			//RemovePhoneNumberFromUser("555-1212", "eebcada5-4565-4966-af05-bda9c053c78e");
			//GetContactById("eebcada5-4565-4966-af05-bda9c053c78e");
			RemoveUser("eebcada5-4565-4966-af05-bda9c053c78e");
			GetAllContacts();
		}

		public static void CreateContact(ContactModel contact)
		{
			db!.UpsertRecord(tableName, contact.Id, contact);
		}

		public static void GetAllContacts()
		{
			var contacts = db!.LoadRecords<ContactModel>(tableName);

			foreach (var contact in contacts)
			{
				Console.WriteLine($"{contact.Id}: {contact.FirstName} {contact.LastName}");
			}
		}

		public static void UpdateContactsFirstName(string firstName, string id)
		{
			Guid guid = new(id);
			var contact = db!.LoadRecordById<ContactModel>(tableName, guid);

			contact.FirstName = firstName;

			db!.UpsertRecord(tableName, contact.Id, contact);
		}

		public static void RemovePhoneNumberFromUser(string phoneNumber, string id)
		{
			Guid guid = new(id);
			var contact = db!.LoadRecordById<ContactModel>(tableName, guid);

			contact.PhoneNumbers = contact.PhoneNumbers.Where(x => x.PhoneNumber != phoneNumber).ToList();

			db!.UpsertRecord(tableName, contact.Id, contact);
		}

		public static void RemoveUser(string id)
		{
			Guid guid = new(id);
			db!.DeleteRecord<ContactModel>(tableName, guid);
		}

		public static void GetContactById(string id)
		{
			Guid guid = new(id);
			var contact = db!.LoadRecordById<ContactModel>(tableName, guid);

			Console.WriteLine($"{contact.Id}: {contact.FirstName} {contact.LastName}");
		}

		public static string GetConnectionString(string connectionStringName = "Default")
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json");

			var config = builder.Build();

			return config.GetConnectionString(connectionStringName) ??
				throw new Exception("Error connecting to DB.");
		}
	}
}