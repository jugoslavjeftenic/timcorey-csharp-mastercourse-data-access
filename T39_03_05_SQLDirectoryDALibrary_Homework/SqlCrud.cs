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

		// Create Person
		public void CreatePerson(PersonModel? person = null)
		{
			person ??= new PersonModel();

			string sql = "insert into dbo.People (FirstName, LastName) values (@FirstName, @LastName);";
			db.SaveData(sql, new { person.FirstName, person.LastName }, _connectionString);
		}
	}
}
