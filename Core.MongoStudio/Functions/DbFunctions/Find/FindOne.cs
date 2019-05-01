using Core.MongoStudio.Adapters;
using Core.MongoStudio.Constants;
using Core.MongoStudio.Factories;
using Core.MongoStudio.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.MongoStudio.Functions.DbFunctions.Find
{
    class FindOne : DbFunction
    {
       readonly FindOneAdapter adappter;
        public override string Name { get { return DbFunctionNames.findOne; } }
        public FindOne(string query) : base(query)
        {
            adappter = new FindOneAdapter();
        }
        public override QueryResult Execute()
        {
            try
            {
                BuildFunction();
                var cursor = adappter.findOne(this);
                QueryResult result = new QueryResult(cursor, !adappter.HasError);
                return result;
            }
            catch (Exception ex)
            {
                return new QueryResult(ex, true);
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
