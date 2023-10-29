using Microsoft.Extensions.Configuration;
using T39_03_05_SQLDirectoryDALibrary_Homework;

namespace T39_03_06_SQLDirectoryUI_Homework
{
	// Build a simple database in SQL that holds People, Addresses, and Employers.
	// Make sure it builds and that you can load and save data in C#.

	public class Program
	{
		static void Main(string[] args)
		{
			SqlCrud sql = new(GetConnectionString());
			//sql.CreateAddressEntity();

			//PrintAllTables(sql);
			//Console.WriteLine(sql.ReadAddressById(1).StreetAddress);
			//UpdateAddress(sql);
			//sql.DeleteAddress(12);
			sql.CreateDirectoryEntry();
		}

		private static void UpdateAddress(SqlCrud sql)
		{
			var address= sql.ReadAddressById(1);
			address.City = "Subotica";
			sql.UpdateAddress(address);
		}

		private static void PrintAllTables(SqlCrud sql)
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