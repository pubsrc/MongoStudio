using Core.MongoStudio.Functions.DbFunctions;

namespace Core.MongoStudio.Modules
{
    abstract class Module
    {
        public string Name { get; set; }
        public ModuleType ModuleType { get; set; }
        public abstract DbFunction GetDbFunction(string query);
    }
}
