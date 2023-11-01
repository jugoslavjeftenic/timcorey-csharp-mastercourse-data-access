using Microsoft.Extensions.Configuration;
using T39_03_01_DataAccessLibrary.Models;
using T39_03_01_DataAccessLibrary;

namespace T39_05_01_MySqlUI
{
	public class Program
	{
		static void Main(string[] args)
		{
			MySqlCrud sql = new(GetConnectionString());

			//ReadContact(sql, 2);
			//CreateNewContact(sql);
			//UpdateContact(sql);
			//RemovePhoneNumberFromContact(sql, 2, 1);
			ReadAllContacts(sql);
		}

		private static void RemovePhoneNumberFromContact(MySqlCrud sql, int contactId, int phoneNumberId)
		{
			sql.RemovePhoneNumberFromContact(contactId, phoneNumberId);
		}

		private static void UpdateContact(MySqlCrud sql)
		{
			BasicContactModel contact = new()
			{
				Id = 1,
				FirstName = "Timothy",
				LastName = "Corey"
			};
			sql.UpdateContactName(contact);
		}

		private static void CreateNewContact(MySqlCrud sql)
		{
			FullContactModel user = new()
			{
				BasicInfo = new()
				{
					FirstName = "Charity",
					LastName = "Corey"
				}
			};

			user.EmailAddresses.Add(new EmailAddressModel { EmailAddress = "nope@aol.com" });
			user.EmailAddresses.Add(new EmailAddressModel { Id = 2, EmailAddress = "me@timothycorey.com" });

			user.PhoneNumbers.Add(new PhoneNumberModel { PhoneNumber = "555-9876" });
			user.PhoneNumbers.Add(new PhoneNumberModel { Id = 1, PhoneNumber = "555-1212" });

			sql.CreateContact(user);
		}

		private static void ReadAllContacts(MySqlCrud sql)
		{
			var rows = sql.GetAllContacts();

			foreach (var row in rows)
			{
				Console.WriteLine($"{row.Id}: {row.FirstName} {row.LastName}");
			}
		}

		private static void ReadContact(MySqlCrud sql, int contactId)
		{
			var contact = sql.GetFullContactById(contactId);

			if (contact?.BasicInfo != null)
			{
				Console.WriteLine
					($"{contact.BasicInfo.Id}: {contact.BasicInfo.FirstName} {contact.BasicInfo.LastName}");
			}
		}

		private static string GetConnectionString(string connectionStringName = "Default")
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