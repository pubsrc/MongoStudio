using Core.MongoStudio.Factories;
using Core.MongoStudio.Functions.DbFunctions;
using Core.MongoStudio.Modules;
using Core.MongoStudio.Queries;
using MongoDB.Driver;
using System;

namespace Core.MongoStudio.Executors
{
    public class QueryExecutor
    {
        public  QueryResult Execute(string query,MongoUrl url,string database)
        {
            if (String.IsNullOrWhiteSpace(query))
            {
                return null;
            }
            query = query.Trim();

            Module module = ModuleFactory.GetModule(query);
            DbFunction function = module.GetDbFunction(query);
            function.Url = url;
            function.DatabaseName = database;
            function.Url = url;
            var result = function.Execute();
            return result;
        }
    }
}
