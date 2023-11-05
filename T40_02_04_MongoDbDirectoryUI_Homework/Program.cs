using Microsoft.Extensions.Configuration;
using System;
using T40_02_03_NoSQLDirectoryDALibrary_Homework;
using T40_02_03_NoSQLDirectoryDALibrary_Homework.Models;

namespace T40_02_04_MongoDbDirectoryUI_Homework
{
	// Build a simple database in MongoDB that holds People, Addresses, and Employers.
	// Make sure it builds and that you can load and save data in C#.

	public class Program
	{
		private static readonly MongoDbDataAccess db = new("MongoDirectoryDB", GetConnectionString());
		private static readonly string tableName = "Directory";

		static void Main(string[] args)
		{
			EmployerModel employer = new();

			//CreateEmployer(employer);
			//AddEmployee("7cdc7fd9-15fe-4dca-825f-79d7c3eb4a21");
			//GetEmployerById("0c114e02-dae2-4cbf-9462-e73a7b69d3b7");
			//RemoveLastEmployer();
			GetAllEmployers();
		}

		public static void CreateEmployer(EmployerModel employer)
		{
			db.UpsertRecord(tableName, employer.Id, employer);
		}

		public static void AddEmployee(string id, PersonModel employee = null!)
		{
			Guid guid = new(id);
			var employer = db!.LoadRecordById<EmployerModel>(tableName, guid);

			employer.People.Add(employee ?? new PersonModel());

			db.UpsertRecord(tableName, employer.Id, employer);
		}

		public static void RemoveLastEmployer()
		{
			var employers = db!.LoadRecords<EmployerModel>(tableName);

			if (employers.Count > 0)
			{
				db.DeleteRecord<EmployerModel>(tableName, employers[employers.Count - 1].Id);
			}
		}

		public static void GetEmployerById(string id)
		{
			Guid guid = new(id);
			var employer = db.LoadRecordById<EmployerModel>(tableName, guid);

			Console.WriteLine($"{employer.Id}: {employer.Employer}, " +
				$"{employer.Address.StreetAddress}, {employer.Address.City}, {employer.Address.Country}");
			PrintPeople(employer);
		}

		public static void GetAllEmployers()
		{
			var employers = db.LoadRecords<EmployerModel>(tableName);

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