using Core.MongoStudio.Adapters;
using Core.MongoStudio.Constants;
using Core.MongoStudio.Factories;
using Core.MongoStudio.Modules;
using Core.MongoStudio.Queries;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.MongoStudio.Functions.DbFunctions.Find
{
    class Find : DbFunction
    {
        readonly FindAdapter adappter;
        public override string Name { get { return DbFunctionNames.find; } }
        public Find(string query) : base(query)
        {
            adappter = new FindAdapter();
        }
        public override QueryResult Execute()
        {
            try
            {
                BuildFunction();
                
                var watch = System.Diagnostics.Stopwatch.StartNew();
                var cursor = adappter.find(this);
                watch.Stop();
                QueryResult result = new QueryResult(cursor, !adappter.HasError, watch.ElapsedMilliseconds);
                return result;
            }
            catch (Exception ex)
            {
              return  new QueryResult(ex, false);
            }
        }
        public override void BuildFunction()
        {
            Collection = GetCollectionName(Query);
            string args = GetAruments(Query);
            Arguments = ParseParameterInArray(args);
            var rawSuffixFunction = GetSuffixFunction(Query);
            if (!String.IsNullOrEmpty(rawSuffixFunction))
            {
                var suffixFunction = SuffixFuntionFactory.GetFunction(rawSuffixFunction);
                if (suffixFunction != null)
                {
                    suffixFunction.Query = rawSuffixFunction;
                    suffixFunction.BuildFunction();
                    this.SuffixFunction = suffixFunction;
                }
            }
        }
    }
}
