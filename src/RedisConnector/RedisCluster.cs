using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisConnector
{
    public class RedisCluster
    {
        public string Name { get; set; }

        public IConnectionMultiplexer Connection { get; set; }

        public bool Connected { get; set; }

        public List<RedisReplica> Nodes = new List<RedisReplica>();
    }
}
