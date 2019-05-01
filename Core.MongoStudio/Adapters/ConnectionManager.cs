using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.MongoStudio.Adapters
{
    class ConnectionManager
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;
   

     public   static void  OpenConnection(MongoUrl url,string database)
        {
            _client = new MongoClient(url);
            _database = _client.GetDatabase(database);
        }
        public static IMongoCollection<BsonDocument> GetCollection(string collection)
        {
            return _database.GetCollection<BsonDocument>(collection);
        }

        static void CloseConnection()
        {
            
        }
    }
}
