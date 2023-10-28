using T39_03_05_SQLDirectoryDALibrary_Homework.DTOs;
using T39_03_05_SQLDirectoryDALibrary_Homework.Models;

namespace T39_03_05_SQLDirectoryDALibrary_Homework
{
	public class SqlCrud
	{
		private readonly string _connectionString;
		private readonly SqlDataAccess db = new();

		public SqlCrud(string connectionString)
		{
			_connectionString = connectionString;
		}

		// Create Address
		public void CreateAddressEntity(AddressModel? address = null)
		{
			address ??= new AddressModel();

			string sql = "insert into dbo.Addresses (StreetAddress, City, Country) " +
				"values (@StreetAddress, @City, @Country);";
			db.SaveData(sql, new { address.StreetAddress, address.City, address.Country }, _connectionString);
		}

		// Read Addresses
		public List<AddressDTO> ReadAddressesList()
		{
			string sql = "select Id, StreetAddress, City, Country from dbo.Addresses";
			return db.LoadData<AddressDTO, dynamic>(sql, new { }, _connectionString);

		}

		// Create Employer
		public void CreateEmployerEntity(EmployerModel? employer = null)
		{
			employer ??= new EmployerModel();

			string sql = "insert into dbo.Employers (Employer) " +
				"values (@Employer);";
			db.SaveData(sql, new { employer.Employer }, _connectionString);
		}

		// Read Employers
		public List<EmployerDTO> ReadEmployersList()
		{
			string sql = "select Id, Employer from dbo.Employers";
			return db.LoadData<EmployerDTO, dynamic>(sql, new { }, _connectionString);

		}

		// Create Person
		public void CreatePersonEntity(PersonModel? person = null)
		{
			person ??= new PersonModel();

			string sql = "insert into dbo.People (FirstName, LastName) " +
				"values (@FirstName, @LastName);";
			db.SaveData(sql, new { person.FirstName, person.LastName }, _connectionString);
		}

		// Read People
		public List<PersonDTO> ReadPeopleList()
		{
			string sql = "select Id, FirstName, LastName from dbo.People";
			return db.LoadData<PersonDTO, dynamic>(sql, new { }, _connectionString);

		}

		// Create AddressEmployerPersonRelation
		public void CreateAddressEmployerPersonRelation(AddressEmployerPersonModel? AMPRelation = null)
		{
			if (AMPRelation == null)
			{
				AMPRelation = new AddressEmployerPersonModel();
				// TODO: random address ID
				// TODO: random employer ID
				// TODO: random person ID
			}

			string sql = "insert into dbo.AddressesEmployersPeople (AddressId, EmployerId, PersonId) " +
				"values (@AddressId, @EmployerId, @PersonId);";
			db.SaveData(sql, new { AMPRelation.AddressId, AMPRelation.EmployerId, AMPRelation.PersonId },
				_connectionString);
		}
	}
}
