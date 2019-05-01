using Core.MongoStudio.Constants;
using Core.MongoStudio.Factories;
using System;

namespace Core.MongoStudio.Functions.SuffixFunctions
{
    class Count : Function
    {
        public override void BuildFunction()
        {
            string args = GetAruments(Query);
            Arguments = ParseParameterInArray(args);
            var rawSuffixFunction = GetSuffixFunction(Query);
            if (!String.IsNullOrEmpty(rawSuffixFunction))
            {
                var suffixFunction = SuffixFuntionFactory.GetFunction(rawSuffixFunction);
                if (suffixFunction != null)
                {
                    IsValid = false;
                    suffixFunction.Query = rawSuffixFunction;
                    suffixFunction.BuildFunction();
                    this.SuffixFunction = suffixFunction;
                }
            }
        }

       public override string Name { get { return SuffixFunctionNames.count; } }
    }
}
