using Core.MongoStudio.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.MongoStudio.Queries
{
    interface IQuery
    {
      QueryResult Execute();
    }
}
