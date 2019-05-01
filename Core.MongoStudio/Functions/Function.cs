using Core.MongoStudio.Queries;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.MongoStudio.Functions
{
    public abstract class Function
    {
        private Function _suffixFunction;
        public string Query { get; set; }
        public abstract string Name { get; }
        public string FunctionType { get; set; }
        public Function PrefixFunction { get; private set; }
        public Function SuffixFunction
        {
            get { return _suffixFunction; }
            set
            {
                _suffixFunction = value;
                _suffixFunction.PrefixFunction = this;
            }
        }
        public bool IsValid { get; set; }

        
        public BsonArray Arguments { get; set; }
        public abstract void BuildFunction();
        public Function()
        {
            Arguments = new BsonArray();
            IsValid = true;
        }

        public bool ValidateArgString(string arg)
        {

            return false;
        }
        //todo: Move GetCollectionName to appropriate class
        protected string GetCollectionName(string query)
        {
            int startIndex = query.IndexOf(".") + 1;
            int lastIndex = query.IndexOf("(");
            query = query.Substring(startIndex, lastIndex - startIndex);
            query = query.Substring(0, query.LastIndexOf("find")).Trim();
            query = query.Substring(0, query.LastIndexOf(".")).Trim();
            return query;
        }
        protected string GetAruments(string query)
        {
            int startIndex = query.IndexOf("(") + 1;
            int lastIndex = GetClosingBracketIndex(query, '(');
            if (startIndex >= 0 && lastIndex >= 0)
            {
                return query.Substring(startIndex, lastIndex - startIndex - 1);
            }
            return "";
        }
        protected string GetSuffixFunction(string query)
        {
            int lastIndex = GetClosingBracketIndex(query, '(');
            if (query.Length > lastIndex)
            {
                var suffixFunction = query.Substring(lastIndex).Trim();
                if (suffixFunction[0] != '.')
                {
                    throw new Exception("Unexpected identifier ");
                }
                suffixFunction = suffixFunction.Substring(1).Trim();
                if (String.IsNullOrEmpty(suffixFunction))
                {
                    throw new Exception("Unexpected identifier");
                }
                return suffixFunction;
            }
            return String.Empty;
        }
        protected int GetClosingBracketIndex(string str, char openingBracket)
        {
            try
            {
                int index = str.IndexOf(openingBracket);
                char closingBracket = GetClosingBracket(openingBracket);
                if (index < 0)
                {
                    return 0;
                }
                index++;
                int counter = 1;
                while (counter > 0)
                {
                    char c = str[index];
                    if (c == openingBracket)
                    {
                        counter++;
                    }
                    else if (c == closingBracket)
                    {
                        counter--;
                    }
                    index++;
                }
                return index;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        protected char GetClosingBracket(char openingBracket)
        {
            switch (openingBracket)
            {
                case '(':
                    return ')';
                case '{':
                    return '}';
                case '[':
                    return ']';
            }
            throw new Exception(openingBracket + " is not a bracket");
        }
        protected static BsonArray ParseParameterInArray(String json)
        {
            if (String.IsNullOrWhiteSpace(json))
            {
                return new BsonArray();
            }
            json = json.Trim();
            if (json.StartsWith(",") || json.EndsWith(","))
            {
                throw new Exception("Not valid json");
            }

            return BsonSerializer.Deserialize<BsonArray>("[" + json + "]");
            //return args.Select(b=>b.ToString()).ToList();
            //  return BsonSerializer.Deserialize<List<dynamic>>(json);

        }
    }
}
