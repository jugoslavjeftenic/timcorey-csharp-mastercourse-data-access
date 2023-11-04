using MongoDB.Bson;
using MongoDB.Driver;

namespace T40_02_01_DataAccessLibrary
{
	public class MongoDbDataAccess
	{
		private readonly IMongoDatabase db;

		public MongoDbDataAccess(string dbName, string connectionString)
		{
			var client = new MongoClient(connectionString);
			db = client.GetDatabase(dbName);
		}

		public void InsertRecord<T>(string table, T record)
		{
			var collection = db.GetCollection<T>(table);
			collection.InsertOne(record);
		}

		public List<T> LoadRecords<T>(string table)
		{
			var collection = db.GetCollection<T>(table);

			return collection.Find(new BsonDocument()).ToList();
		}

		public T LoadRecordById<T>(string table, Guid id)
		{
			var collection = db.GetCollection<T>(table);
			var filter = Builders<T>.Filter.Eq("Id", id);

			return collection.Find(filter).First();
		}

		//[Obsolete]
		public void UpsertRecord<T>(string table, Guid id, T record)
		{
			var collection = db.GetCollection<T>(table);

			//var result = collection.ReplaceOne(new BsonDocument("_id", id),
			//	record, new UpdateOptions { IsUpsert = true });
			var filter = Builders<T>.Filter.Eq("_id", id);
			var options = new ReplaceOptions { IsUpsert = true };

			var result = collection.ReplaceOne(filter, record, options);
		}

		public void DeleteRecord<T>(string table, Guid id)
		{
			var collection = db.GetCollection<T>(table);
			var filter = Builders<T>.Filter.Eq("Id", id);
			collection.DeleteOne(filter);
		}
	}
}
