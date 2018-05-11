using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RedisConnector
{
    public class RedisReplica
    {
        public string Name { get; set; }

        public EndPoint Master { get; set; }

        public List<EndPoint> Slaves { get; set; }

    }
}
