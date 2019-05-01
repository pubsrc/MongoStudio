using System;

namespace Core.MongoStudio.Queries
{
    public class QueryResult
    {
        public QueryResult(dynamic result,bool success)
        {
            Result = result;
            Success = success;
        }
        public QueryResult(dynamic result, bool success,long executionTime)
        {
            Result = result;
            Success = success;
            ExecutionTime = executionTime;
        }
        public bool Success { get;}
        public dynamic Result { get; }
        public double ExecutionTime { get;}
        public string ErrorMessage { get;}
    }
}
