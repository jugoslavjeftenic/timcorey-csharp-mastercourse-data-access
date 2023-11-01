using Microsoft.Extensions.Configuration;
using T39_03_05_SQLDirectoryDALibrary_Homework;

namespace T39_05_02_MySqlDirectoryUI
{
	// Build a simple database in MySQL that holds People, Addresses, and Employers.
	// Make sure it builds and that you can load and save data in C#.

	internal class Program
	{
		static void Main(string[] args)
		{
			MySqlCrud sql = new(GetConnectionString());
			//sql.CreateAddressEntity();
			//sql.CreateEmployerEntity();
			//sql.CreatePersonEntity();

			//Console.WriteLine(sql.ReadAddressById(1).StreetAddress);
			//UpdateAddress(sql);
			//sql.DeleteAddress(12);
			sql.CreateDirectoryEntry();
			PrintAllTables(sql);
		}

		private static void UpdateAddress(MySqlCrud sql)
		{
			var address = sql.ReadAddressById(1);
			address.City = "Subotica";
			sql.UpdateAddress(address);
		}

		private static void PrintAllTables(MySqlCrud sql)
		{
			var addressesRows = sql.ReadAddressesList();
			foreach (var row in addressesRows)
			{
				Console.WriteLine($"{row.Id:D2}: {row.StreetAddress} {row.City} {row.Country}");
			}

			Console.WriteLine();

			var employersRows = sql.ReadEmployersList();
			foreach (var row in employersRows)
			{
				Console.WriteLine($"{row.Id:D2}: {row.Employer}");
			}

			Console.WriteLine();

			var peopleRows = sql.ReadPeopleList();
			foreach (var row in peopleRows)
			{
				Console.WriteLine($"{row.Id:D2}: {row.FirstName} {row.LastName}");
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