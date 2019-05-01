using Core.MongoStudio.Functions;
using Core.MongoStudio.Functions.DbFunctions;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.MongoStudio.Errors
{
    class FindErrors
    {
        public static BsonDocument GetDontKnowHowToMessageObject()
        {
            return BsonDocument.Parse("{\"message\" : \"don't know how to massage : number\",\"stack\" : \"script:1:9\"}");
        }
        public static BsonDocument GetArgumentDataTypeMissMatch()
        {
            var innerObject = new BsonDocument("ok", 0);
            innerObject.Add(new BsonElement("errmsg", "\"level\" had the wrong type. Expected String, found NumberDouble"));
            innerObject.Add(new BsonElement("code", 14));
            //todo: add below commented cod
            //"_getErrorWithCode @src/mongo/shell/utils.js:23:13" +
            //"DBCommandCursor @src/mongo/shell/query.js:682:1" +
            //"DBQuery.prototype._exec @src/mongo/shell/query.js:105:28" +
            //"DBQuery.prototype.hasNext @src/mongo/shell/query.js:267:5" +
            //"DBCollection.prototype.findOne @src/mongo/shell/collection.js:215:12" +
            //"@(shell):1:1");

            return new BsonDocument("Error", innerObject);
        }
        public static BsonDocument NotAFunction(Function function)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("db." + ((DbFunction)function).Collection);
            while (function != null)
            {
                builder.Append("." + (function.Arguments.Count > 0 ? function.Name + "(...)" : function.Name + "()"));
                function = function.SuffixFunction;
            }
            builder.Append(" is not a function");
            return new BsonDocument("TypeError", builder.ToString());
        }

        public static BsonDocument FindAndUpdateNoArgument()
        {
            var innerObject = new BsonDocument("ok", 0);
            innerObject.Add(new BsonElement("errmsg", "Either an update or remove = true must be specified"));
            innerObject.Add(new BsonElement("code", 9));
            //todo: add below commented cod
            // _getErrorWithCode @src/ mongo / shell / utils.js:23:13
            //DBCollection.prototype.findAndModify @src/ mongo / shell / collection.js:678:1
            //@(shell):1:1

            return new BsonDocument("Error", innerObject);
        }
    }
}
