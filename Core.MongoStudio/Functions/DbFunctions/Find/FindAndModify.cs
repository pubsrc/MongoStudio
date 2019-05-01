using Core.MongoStudio.Adapters;
using Core.MongoStudio.Constants;
using Core.MongoStudio.Factories;
using Core.MongoStudio.Queries;
using System;

namespace Core.MongoStudio.Functions.DbFunctions.Find
{
    class FindAndModify:DbFunction
    {
        readonly FindAndModifyAdapter adappter;
        public override string Name { get { return DbFunctionNames.findAndModify; } }
        public FindAndModify(string query) : base(query)
        {
            adappter = new FindAndModifyAdapter();
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
                return new QueryResult(ex, false);
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
