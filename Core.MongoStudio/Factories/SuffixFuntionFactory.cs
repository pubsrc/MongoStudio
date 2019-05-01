using Core.MongoStudio.Constants;
using Core.MongoStudio.Functions;
using Core.MongoStudio.Functions.SuffixFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Core.MongoStudio.Factories
{
    class SuffixFuntionFactory
    {
        public static Function GetFunction(string funtion)
        {
            Function function = null;
            if (Regex.IsMatch(funtion, SuffixFunctionPatterns.count))
            {
                function = new Count();
            }
            return function;
        }
    }
}
