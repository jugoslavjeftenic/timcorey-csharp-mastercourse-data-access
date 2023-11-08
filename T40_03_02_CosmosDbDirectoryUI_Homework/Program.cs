using Microsoft.Extensions.Configuration;
using T40_02_03_NoSQLDirectoryDALibrary_Homework;
using T40_02_03_NoSQLDirectoryDALibrary_Homework.Models;

namespace T40_03_02_CosmosDbDirectoryUI_Homework
{
	// Build a simple database in MongoDB that holds People, Addresses, and Employers.
	// Make sure it builds and that you can load and save data in C#.

	public class Program
	{
		private static readonly string _endpointUrl = GetCosmosInfo().endpointUrl;
		private static readonly string _primaryKey = GetCosmosInfo().primaryKey;
		private static readonly string _databaseName = GetCosmosInfo().databaseName;
		private static readonly string _containerName = GetCosmosInfo().containerName;
		private static readonly CosmosDbDataAccess _db =
			new CosmosDbDataAccess(_endpointUrl, _primaryKey, _databaseName, _containerName);


		static async Task Main(string[] args)
		{
			//EmployerModel employer = new();
			//for (int i = 0; i < 5; i++)
			//{
			//	employer.People.Add(new PersonModel());
			//}

			//await CreateEmployer(employer);
			//await GetEmployerById("d5eb1c36-931e-4e8b-b36a-d5ed0e356d6a");
			//await RemoveLastEmployer();
			//await AddEmployee("4e71509f-603d-40bb-8c45-afa982accf1a");

			await GetAllEmployers();
		}

		public static async Task CreateEmployer(EmployerModel employer)
		{
			await _db.UpsertRecordAsync(employer);
		}

		public static async Task AddEmployee(string id, PersonModel employee = null!)
		{
			var employer = await _db.LoadRecordByIdAsync<EmployerModel>(id);

			employer.People.Add(employee ?? new PersonModel());

			await _db!.UpsertRecordAsync(employer);
		}

		public static async Task RemoveLastEmployer()
		{
			var employers = await _db.LoadRecordsAsync<EmployerModel>();

			if (employers.Count > 0)
			{
				await _db!.DeleteRecordAsync<EmployerModel>
					(employers[employers.Count - 1].Id.ToString(), employers[employers.Count - 1].Employer);
			}
		}

		public static async Task GetEmployerById(string id)
		{
			var employer = await _db.LoadRecordByIdAsync<EmployerModel>(id);

			Console.WriteLine($"{employer.Id}: {employer.Employer}, " +
				$"{employer.Address.StreetAddress}, {employer.Address.City}, {employer.Address.Country}");
			PrintPeople(employer);
		}

		public static async Task GetAllEmployers()
		{
			var employers = await _db.LoadRecordsAsync<EmployerModel>();

			foreach (var employer in employers)
			{
				Console.WriteLine($"{employer.Id}: {employer.Employer}, " +
					$"{employer.Address.StreetAddress}, {employer.Address.City}, {employer.Address.Country}");
				PrintPeople(employer);
				Console.WriteLine();
			}
		}

		private static void PrintPeople(EmployerModel employer)
		{
			foreach (var employee in employer.People)
			{
				Console.WriteLine($" - {employee.FirstName} {employee.LastName}");
			}
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