using Core.MongoStudio.Functions.DbFunctions;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using Core.MongoStudio.DataTypes;
using Core.MongoStudio.Errors;
using Core.MongoStudio.Constants;

namespace Core.MongoStudio.Adapters
{
    class FindAdapter:Adapter
    {
        internal dynamic find(DbFunction dbFunction)
        {
            ConnectionManager.OpenConnection(dbFunction.Url, dbFunction.DatabaseName);
            var collection = ConnectionManager.GetCollection(dbFunction.Collection);
            BsonDocument filter = new BsonDocument();
            BsonDocument projection = new BsonDocument();
            
            if (dbFunction.Arguments.Count > 0
                && !dbFunction.Arguments[0].GetType().Name.Equals(DataType.BsonDocument))
            {
                HasError = true;
                return new List<BsonDocument>() { FindErrors.GetDontKnowHowToMessageObject() };
            }
            if (dbFunction.SuffixFunction == null)
            {
                switch (dbFunction.Arguments.Count)
                {
                    case 0:
                        {
                            return collection.Find(filter).ToList();
                        }

                    case 1:
                        {

                            filter = dbFunction.Arguments[0].ToBsonDocument();
                            return collection.Find(filter).ToList();
                        }
                    case 2:
                        {
                            if (dbFunction.Arguments[1].GetType().Name.Equals(DataType.BsonDocument))
                            {
                                filter = dbFunction.Arguments[0].ToBsonDocument();
                                projection = dbFunction.Arguments[1].ToBsonDocument();

                            }
                            return collection.Find(filter).Project(projection).ToList();
                        }
                    case 3:
                        {
                            if (dbFunction.Arguments[1].GetType().Name.Equals(DataType.BsonDocument))
                            {
                                filter = dbFunction.Arguments[0].ToBsonDocument();
                                projection = dbFunction.Arguments[1].ToBsonDocument();

                            }
                            int limit = dbFunction.Arguments[2].ToInt32();
                            return collection.Find(filter).Project(projection).Limit(limit).ToList();

                        }
                    default:
                        {
                            if (dbFunction.Arguments[1].GetType().Name.Equals(DataType.BsonDocument))
                            {
                                filter = dbFunction.Arguments[0].ToBsonDocument();
                                projection = dbFunction.Arguments[1].ToBsonDocument();

                            }
                            int limit = dbFunction.Arguments[2].ToInt32();
                            int skip = dbFunction.Arguments[3].ToInt32();
                            return collection.Find(filter).Project(projection).Skip(skip).Limit(limit).ToList();

                        }
                }
            }
            else
            {
                if (dbFunction.SuffixFunction.Name.Equals(SuffixFunctionNames.count)&& dbFunction.SuffixFunction.SuffixFunction==null)
                {
                    return collection.Find(filter).Count();
                }
                else
                {
                    HasError = true;
                    return FindErrors.NotAFunction(dbFunction);
                }
            }
        }
        
    }
}
