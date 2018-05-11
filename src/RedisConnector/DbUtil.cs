using StackExchange.Redis;

namespace RedisConnector
{
    public static class DbUtil
    {
        /// <summary>
        /// 打开连接
        /// </summary>
        /// <param name="connectionStr">数据库连接字符串</param>
        /// <returns></returns>
        public static IConnectionMultiplexer Open(string connectionStr)
        {
            if (string.IsNullOrEmpty(connectionStr))
                return null;
            else
            {
                var options = ConfigurationOptions.Parse(connectionStr);
                options.SyncTimeout = int.MaxValue;
                options.AllowAdmin = true;
                return ConnectionMultiplexer.Connect(options);
            }
                
        }
    }
}
