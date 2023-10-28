using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace T39_03_05_SQLDirectoryDALibrary_Homework
{
	public class SqlDataAccess
	{
		public List<T> LoadData<T, U>(string sqlStatement, U parameters, string connectionString)
		{
			using IDbConnection connection = new SqlConnection(connectionString);
			List<T> rows = connection.Query<T>(sqlStatement, parameters).ToList();
			return rows;
		}

		public void SaveData<T>(string sqlStatement, T parameters, string connectionString)
		{
			using IDbConnection connection = new SqlConnection(connectionString);
			connection.Execute(sqlStatement, parameters);
		}
	}
}
