using T39_03_05_SQLDirectoryDALibrary_Homework.DTOs;
using T39_03_05_SQLDirectoryDALibrary_Homework.Models;

namespace T39_03_05_SQLDirectoryDALibrary_Homework
{
	public class MySqlCrud
	{
		private readonly string _connectionString;
		private readonly MySqlDataAccess db = new();

		public MySqlCrud(string connectionString)
		{
			_connectionString = connectionString;
		}

		// Create Address
		public void CreateAddressEntity(AddressModel? address = null)
		{
			address ??= new AddressModel();
			string sql = "insert into Addresses (StreetAddress, City, Country) " +
				"values (@StreetAddress, @City, @Country);";
			db.SaveData(sql, new { address.StreetAddress, address.City, address.Country }, _connectionString);
		}

		// Read Addresses
		public List<AddressDTO> ReadAddressesList()
		{
			string sql = "select Id, StreetAddress, City, Country from Addresses";
			return db.LoadData<AddressDTO, dynamic>(sql, new { }, _connectionString);
		}

		// Read Address by Id
		public AddressDTO ReadAddressById(int id)
		{
			string sql = "select Id, StreetAddress, City, Country from Addresses where Id = @Id";
			var output = db
				.LoadData<AddressDTO, dynamic>(sql, new { Id = id }, _connectionString)
				.FirstOrDefault();
			return output ?? throw new Exception($"Record with Id {id} is not found.");
		}

		// Update Address
		public void UpdateAddress(AddressDTO address)
		{
			string sql = "update Addresses set " +
				"StreetAddress = @StreetAddress, City = @City, Country = @Country where Id = @Id;";
			db.SaveData(sql, address, _connectionString);
		}

		// Delete Address
		public void DeleteAddress(int id)
		{
			string sql = "delete from Addresses where Id = @Id;";
			db.SaveData(sql, new { Id = id }, _connectionString);
		}

		// Create Employer
		public void CreateEmployerEntity(EmployerModel? employer = null)
		{
			employer ??= new EmployerModel();
			string sql = "insert into Employers (Employer) " +
				"values (@Employer);";
			db.SaveData(sql, new { employer.Employer }, _connectionString);
		}

		// Read Employers
		public List<EmployerDTO> ReadEmployersList()
		{
			string sql = "select Id, Employer from Employers";
			return db.LoadData<EmployerDTO, dynamic>(sql, new { }, _connectionString);
		}

		// Create Person
		public void CreatePersonEntity(PersonModel? person = null)
		{
			person ??= new PersonModel();
			string sql = "insert into People (FirstName, LastName) " +
				"values (@FirstName, @LastName);";
			db.SaveData(sql, new { person.FirstName, person.LastName }, _connectionString);
		}

		// Read People
		public List<PersonDTO> ReadPeopleList()
		{
			string sql = "select Id, FirstName, LastName from People";
			return db.LoadData<PersonDTO, dynamic>(sql, new { }, _connectionString);
		}

		// Create AddressEmployerPersonRelation
		public void CreateDirectoryEntry(AddressEmployerPersonModel? directoryEntry = null)
		{
			if (directoryEntry == null)
			{
				string fetchIdSql;
				Random random = new();
				directoryEntry = new AddressEmployerPersonModel();

				// Random Address Id
				fetchIdSql = "select Id from Addresses";
				var fetchAddressesId = db
					.LoadData<AddressesIdsDTO, dynamic>(fetchIdSql, new { }, _connectionString);
				directoryEntry.AddressId = fetchAddressesId[random.Next(0, fetchAddressesId.Count)].Id;

				// Random Employer Id
				fetchIdSql = "select Id from Employers";
				var fetchEmployersId = db
					.LoadData<EmployersIdsDTO, dynamic>(fetchIdSql, new { }, _connectionString);
				directoryEntry.EmployerId = fetchEmployersId[random.Next(0, fetchEmployersId.Count)].Id;

				// Random Person Id
				fetchIdSql = "select Id from People";
				var fetchPeopleId = db
					.LoadData<PeopleIdsDTO, dynamic>(fetchIdSql, new { }, _connectionString);
				directoryEntry.PersonId = fetchPeopleId[random.Next(0, fetchPeopleId.Count)].Id;
			}

			string sql = "insert into AddressesEmployersPeople (AddressId, EmployerId, PersonId) " +
				"values (@AddressId, @EmployerId, @PersonId);";
			db.SaveData(sql, new { directoryEntry.AddressId, directoryEntry.EmployerId, directoryEntry.PersonId },
				_connectionString);
		}
	}
}
