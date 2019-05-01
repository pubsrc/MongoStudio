using System.Text.RegularExpressions;
using Core.MongoStudio.Constants;
using Core.MongoStudio.Functions.DbFunctions;
using Core.MongoStudio.Functions.DbFunctions.Find;
using MongoDB.Driver;

namespace Core.MongoStudio.Modules
{
    class DbModule : Module
    {
        public override DbFunction GetDbFunction(string query)
        {
            DbFunction dbFunction = null;
            if (Regex.IsMatch(query, Patterns.find))
            {
                dbFunction = new Find(query);
            }
            else if (Regex.IsMatch(query, Patterns.findOne))
            {
                dbFunction = new FindOne(query);
            }
            else if (Regex.IsMatch(query, Patterns.findAndModify))
            {
                dbFunction = new FindAndModify(query);
            }
            return dbFunction;
        }
    }
}
