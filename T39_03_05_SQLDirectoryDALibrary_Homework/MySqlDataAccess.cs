using System.Data;
using MySql.Data.MySqlClient;
using Dapper;

namespace T39_03_05_SQLDirectoryDALibrary_Homework
{
	public class MySqlDataAccess
	{
		public List<T> LoadData<T, U>(string sqlStatement, U parameters, string connectionString)
		{
			using IDbConnection connection = new MySqlConnection(connectionString);
			List<T> rows = connection.Query<T>(sqlStatement, parameters).ToList();
			return rows;
		}

		public void SaveData<T>(string sqlStatement, T parameters, string connectionString)
		{
			using IDbConnection connection = new MySqlConnection(connectionString);
			connection.Execute(sqlStatement, parameters);
		}
	}
}
