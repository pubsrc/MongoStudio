using Core.MongoStudio.Constants;
using Core.MongoStudio.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Core.MongoStudio.Factories
{
    class ModuleFactory
    {
        public static Module GetModule(string query)
        {
            DbModule module = null;
            if (query.StartsWith("db")&& Regex.IsMatch(query, Patterns.DbModule))
            {
                module= new DbModule();
            }
            return module;
        }
    }
}
