using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.MongoStudio.Connections
{
    public  class ConnectionManager
    {
        private static LinkedList<Connection> _connections;
        static ConnectionManager()
        {
            _connections = new LinkedList<Connection>();
        }

        private void OpenConnection(MongoUrl url)
        {

        }
    }
}
