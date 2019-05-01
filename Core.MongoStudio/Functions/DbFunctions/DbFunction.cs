using Core.MongoStudio.Modules;
using Core.MongoStudio.Queries;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.MongoStudio.Functions.DbFunctions
{
    abstract class DbFunction : Function,IQuery
    {
        public string Collection { get; set; }
        public string DatabaseName { get; set; }
        public MongoUrl Url { get; set; }
        
        public abstract QueryResult Execute();
        public DbFunction(string query)
        {
            Query = query;
        }
    }
}
