using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.MongoStudio.Constants
{
    class Patterns
    {
        public const string DbModule = @"\W*db\W*.";
        public const string find = @"(db\W*)\.(.*)\.(\W*find\W*)\((.*)\)";
        public const string findOne = @"(db\W*)\.(.*)\.(\W*findOne\W*)\((.*)\)";
        public const string findAndModify = @"(db\W*)\.(.*)\.(\W*findAndModify\W*)\((.*)\)";

    }
}
