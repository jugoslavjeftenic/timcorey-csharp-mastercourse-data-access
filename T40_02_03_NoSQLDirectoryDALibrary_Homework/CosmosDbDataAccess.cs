using Microsoft.Azure.Cosmos;

namespace T40_02_03_NoSQLDirectoryDALibrary_Homework
{
	public class CosmosDbDataAccess
	{
		private readonly string _endpointUrl;
		private readonly string _primaryKey;
		private readonly string _databaseName;
		private readonly string _containerName;
		private readonly CosmosClient _cosmosClient;
		private readonly Database _database;
		private readonly Container _container;

		public CosmosDbDataAccess
			(string endpointUrl, string primaryKey, string databaseName, string containerName)
		{
			_endpointUrl = endpointUrl;
			_primaryKey = primaryKey;
			_databaseName = databaseName;
			_containerName = containerName;

			_cosmosClient = new CosmosClient(_endpointUrl, _primaryKey);
			_database = _cosmosClient.GetDatabase(_databaseName);
			_container = _database.GetContainer(_containerName);
		}

		public async Task<List<T>> LoadRecordsAsync<T>()
		{
			string sql = "select * from c";

			QueryDefinition queryDefinition = new(sql);
			FeedIterator<T> feedIterator = _container.GetItemQueryIterator<T>(queryDefinition);

			List<T> output = new();

			while (feedIterator.HasMoreResults)
			{
				FeedResponse<T> currentResultSet = await feedIterator.ReadNextAsync();

				foreach (var item in currentResultSet)
				{
					output.Add(item);
				}
			}

			return output;
		}

		public async Task<T> LoadRecordByIdAsync<T>(string id)
		{
			string sql = "select * from c where c.id = @Id";

			QueryDefinition queryDefinition = new QueryDefinition(sql).WithParameter("@Id", id);
			FeedIterator<T> feedIterator = _container.GetItemQueryIterator<T>(queryDefinition);

			while (feedIterator.HasMoreResults)
			{
				FeedResponse<T> currentResultSet = await feedIterator.ReadNextAsync();

				foreach (var item in currentResultSet)
				{
					return item;
				}
			}

			throw new Exception("Item not found");
		}

		public async Task UpsertRecordAsync<T>(T record)
		{
			await _container.UpsertItemAsync(record);
		}

		public async Task DeleteRecordAsync<T>(string id, string partitionKey)
		{
			await _container.DeleteItemAsync<T>(id, new PartitionKey(partitionKey));
		}
	}
}
