using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedisConnector
{
    public static class ConnectionManager
    {
        public static Dictionary<string, RedisCluster> Connections = new Dictionary<string, RedisCluster>();

    }
}
