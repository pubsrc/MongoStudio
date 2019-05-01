using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.MongoStudio.MongoExceptions
{
    class MongoStudioException : Exception
    {
        public MongoStudioException(string message) : base(message)
        {
        }
    }
}
