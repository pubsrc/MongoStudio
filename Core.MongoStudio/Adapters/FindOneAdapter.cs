using Core.MongoStudio.Functions.DbFunctions;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using Core.MongoStudio.DataTypes;
using Core.MongoStudio.Errors;

namespace Core.MongoStudio.Adapters
{
    class FindOneAdapter:Adapter
    {
        internal dynamic findOne(DbFunction dbFunction)
        {
            ConnectionManager.OpenConnection(dbFunction.Url, dbFunction.DatabaseName);
            var collection = ConnectionManager.GetCollection(dbFunction.Collection);
            BsonDocument filter = new BsonDocument();
            BsonDocument projection = new BsonDocument();

            if (dbFunction.Arguments.Count > 0
                && !dbFunction.Arguments[0].GetType().Name.Equals(DataType.BsonDocument))
            {
                HasError = true;
                return FindErrors.GetDontKnowHowToMessageObject();
            }
            if (dbFunction.SuffixFunction != null)
            {
                HasError = true;
                return FindErrors.NotAFunction(dbFunction);
            }
            switch (dbFunction.Arguments.Count)
            {
                case 0:
                    {

                        return collection.Find(filter).FirstOrDefault();
                    }

                case 1:
                    {

                        filter = dbFunction.Arguments[0].ToBsonDocument();
                        return collection.Find(filter).FirstOrDefault();
                    }
                case 2:
                    {
                        if (dbFunction.Arguments[1].GetType().Name.Equals(DataType.BsonDocument))
                        {
                            filter = dbFunction.Arguments[0].ToBsonDocument();
                            projection = dbFunction.Arguments[1].ToBsonDocument();

                        }
                        return collection.Find(filter).Limit(1).Project(projection).FirstOrDefault();
                    }
                default:
                    {
                        if (dbFunction.Arguments[3] is BsonString)
                        {
                            if (dbFunction.Arguments[1].GetType().Name.Equals(DataType.BsonDocument))
                            {
                                filter = dbFunction.Arguments[0].ToBsonDocument();
                                projection = dbFunction.Arguments[1].ToBsonDocument();

                            }
                            int limit = dbFunction.Arguments[2].ToInt32();
                            return collection.Find(filter).Limit(1).Project(projection).Limit(limit).FirstOrDefault();
                        }
                        HasError = true;
                        return FindErrors.GetArgumentDataTypeMissMatch();

                    }
            }
        }
    }
}
