using Microsoft.Extensions.Configuration;
using T41_01_01_DataAccessLibrary;
using T41_01_01_DataAccessLibrary.Models;

namespace T41_01_02_TextFileUI
{
	public class Program
	{
		private static IConfiguration? _config;
		private static string? _textFile;
		private static readonly TextFileDataAccess _db = new();

		static void Main(string[] args)
		{
			InitializeConfiguration();
			_textFile = _config!.GetValue<string>("TextFile");

			ContactModel user1 = new()
			{
				FirstName = "Tim",
				LastName = "Corey"
			};
			user1.EmailAddresses.Add("tim@iamtimcorey.com");
			user1.EmailAddresses.Add("me@timothycorey.com");
			user1.PhoneNumbers.Add("555-1212");
			user1.PhoneNumbers.Add("555-1234");

			ContactModel user2 = new()
			{
				FirstName = "Charity",
				LastName = "Corey"
			};
			user2.EmailAddresses.Add("nope@aol.com");
			user2.EmailAddresses.Add("me@timothycorey.com");
			user2.PhoneNumbers.Add("555-1212");
			user2.PhoneNumbers.Add("555-9876");

			//CreateContact(user1);
			//CreateContact(user2);
			//UpdateContactFirstName("Timothy");
			//RemovePhoneNumberFromUser("555-1212");
			//RemoveUser();

			GetAllContacts();
		}

		public static void CreateContact(ContactModel contact)
		{
			var contacts = _db.ReadAllRecords(_textFile!);
			contacts.Add(contact);
			_db.WriteAllRecords(contacts, _textFile!);
		}

		public static void GetAllContacts()
		{
			var contacts = _db.ReadAllRecords(_textFile!);
			foreach (var contact in contacts)
			{
				Console.WriteLine($"{contact.FirstName} {contact.LastName}");
			}
		}

		public static void UpdateContactFirstName(string firstName)
		{
			var contacts = _db.ReadAllRecords(_textFile!);
			contacts[0].FirstName = firstName;
			_db.WriteAllRecords(contacts, _textFile!);
		}

		public static void RemovePhoneNumberFromUser(string phoneNumber)
		{
			var contacts = _db.ReadAllRecords(_textFile!);
			contacts[0].PhoneNumbers.Remove(phoneNumber);
			_db.WriteAllRecords(contacts, _textFile!);
		}

		public static void RemoveUser()
		{
			var contacts = _db.ReadAllRecords(_textFile!);
			contacts.RemoveAt(0);
			_db.WriteAllRecords(contacts, _textFile!);
		}

		public static void InitializeConfiguration()
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json");
			_config = builder.Build();
		}
	}
}