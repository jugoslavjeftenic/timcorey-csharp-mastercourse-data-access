using Microsoft.EntityFrameworkCore;
using T42_02_01_EFConsoleUI.DataAccess;
using T42_02_01_EFConsoleUI.Models;

namespace T42_02_01_EFConsoleUI
{
	public class Program
	{
		static void Main()
		{
			//CreateTim();
			//CreateCharity();
			//ReadById(1);
			//UpdateFirstName(1, "Timothy");
			//RemovePhoneNumber(1, "555-1212");
			RemoveUser(1);
			ReadAll();
		}

		public static void CreateTim()
		{
			var c = new Contact()
			{
				FirstName = "Tim",
				LastName = "Corey",
			};
			c.EmailAddresses.Add(new Email { EmailAddress = "tim@iamtimcorey.com" });
			c.EmailAddresses.Add(new Email { EmailAddress = "me@timothycorey.com" });
			c.PhoneNumbers.Add(new Phone { PhoneNumber = "555-1212" });
			c.PhoneNumbers.Add(new Phone { PhoneNumber = "555-1234" });

			using var db = new ContactContext();
			db.Contacts.Add(c);
			db.SaveChanges();
		}

		public static void CreateCharity()
		{
			var c = new Contact()
			{
				FirstName = "Charity",
				LastName = "Corey",
			};
			c.EmailAddresses.Add(new Email { EmailAddress = "nope@aol.com" });
			c.EmailAddresses.Add(new Email { EmailAddress = "me@timothycorey.com" });
			c.PhoneNumbers.Add(new Phone { PhoneNumber = "555-1212" });
			c.PhoneNumbers.Add(new Phone { PhoneNumber = "555-9876" });

			using var db = new ContactContext();
			db.Contacts.Add(c);
			db.SaveChanges();
		}

		public static void ReadAll()
		{
			using var db = new ContactContext();
			var records = db.Contacts
				.Include(e => e.EmailAddresses)
				.Include(p => p.PhoneNumbers)
				.ToList();

			foreach (var c in records)
			{
				Console.WriteLine($"{c.FirstName} {c.LastName}");
			}
		}

		public static void ReadById(int id)
		{
			using var db = new ContactContext();
			var user = db.Contacts.Where(c => c.Id == id).First();
			Console.WriteLine($"{user.FirstName} {user.LastName}");
		}

		public static void UpdateFirstName(int id, string firstName)
		{
			using var db = new ContactContext();
			var user = db.Contacts.Where(c => c.Id == id).First();

			user.FirstName = firstName;

			db.SaveChanges();
		}

		public static void RemovePhoneNumber(int id, string phoneNumber)
		{
			using var db = new ContactContext();
			var user = db.Contacts
				.Include(p => p.PhoneNumbers)
				.Where(c => c.Id == id).First();

			user.PhoneNumbers.RemoveAll(p => p.PhoneNumber == phoneNumber);

			db.SaveChanges();
		}

		public static void RemoveUser(int id)
		{
			using var db = new ContactContext();
			var user = db.Contacts
				.Include(e => e.EmailAddresses)
				.Include(p => p.PhoneNumbers)
				.Where(c => c.Id == id).First();
			db.Contacts.Remove(user);
			db.SaveChanges();
		}
	}
}