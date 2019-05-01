using Core.MongoStudio.Constants;
using Core.MongoStudio.DataTypes;
using Core.MongoStudio.Functions.DbFunctions;
using Core.MongoStudio.Errors;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Core.MongoStudio.Adapters
{
    class FindAndModifyAdapter : Adapter
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
                            HasError = true;
                            return FindErrors.FindAndUpdateNoArgument();
                        }

                    case 1:
                        {

                            filter = dbFunction.Arguments[0].ToBsonDocument();
                            BsonValue query = filter["query"];
                            BsonValue update = filter["update"];
                            BsonValue upsert = filter["upsert"];
                            BsonValue sort = filter["sort"];
                            //collection.FindOneAndUpdate(query, update, sort);
                            if (filter.Contains("update") || filter.Contains("remove"))
                            {
                                return null;// collection.FindOneAndUpdate(filter,update,options,cancellationToken);
                            }
                            else
                                return FindErrors.FindAndUpdateNoArgument();
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
                            //return collection.Find(filter).Project(projection).Skip(skip).Limit(limit).ToList();


                            var update = Builders<BsonDocument>.Update.Inc("UseCount", 1);
                            var sort = new FindOneAndUpdateOptions<BsonDocument>
                            {
                                Sort = Builders<BsonDocument>.Sort.Ascending("UseCount")
                            };
                            return collection.FindOneAndUpdate(filter, update, sort);

                        }
                }
            }
            else
            {
                if (dbFunction.SuffixFunction.Name.Equals(SuffixFunctionNames.count) && dbFunction.SuffixFunction.SuffixFunction == null)
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
