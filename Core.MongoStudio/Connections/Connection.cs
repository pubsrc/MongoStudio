using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.MongoStudio.Connections
{
    internal class Connection
    {
        protected IMongoClient Client;
        protected IMongoDatabase Database;
        protected MongoUrl Url;
        protected string DatabaseName { get; set; }

        public Connection(string url)
        {
            Url = new MongoUrl(url);
            Client = new MongoClient(Url);
        }
    }
}
