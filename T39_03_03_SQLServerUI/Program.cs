using Microsoft.Extensions.Configuration;
using T39_03_01_DataAccessLibrary;
using T39_03_01_DataAccessLibrary.Models;

namespace T39_03_03_SQLServerUI
{
	public class Program
	{
		static void Main(string[] args)
		{
			SqlCrud sql = new(GetConnectionString());

			//ReadAllContacts(sql);
			//ReadContact(sql, 1);
			//CreateNewContact(sql);
			//UpdateContact(sql);
			RemovePhoneNumberFromContact(sql, 1, 1);
		}

		private static void RemovePhoneNumberFromContact(SqlCrud sql, int contactId, int phoneNumberId)
		{
			sql.RemovePhoneNumberFromContact(contactId, phoneNumberId);
		}

		private static void UpdateContact(SqlCrud sql)
		{
			BasicContactModel contact = new()
			{
				Id = 1,
				FirstName = "Timothy",
				LastName = "Corey"
			};
			sql.UpdateContactName(contact);
		}

		private static void CreateNewContact(SqlCrud sql)
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

		private static void ReadAllContacts(SqlCrud sql)
		{
			var rows = sql.GetAllContacts();

			foreach (var row in rows)
			{
				Console.WriteLine($"{row.Id}: {row.FirstName} {row.LastName}");
			}
		}

		private static void ReadContact(SqlCrud sql, int contactId)
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