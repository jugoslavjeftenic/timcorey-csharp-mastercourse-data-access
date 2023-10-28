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
			sql.CreatePerson();
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