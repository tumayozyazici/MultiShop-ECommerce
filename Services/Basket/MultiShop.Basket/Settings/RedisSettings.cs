using System.Runtime.CompilerServices;

namespace MultiShop.Basket.Settings
{
    public class RedisSettings
    {
        public string _host { get; set; }
        public int _port { get; set; }

        public RedisSettings(string host, int port)
        {
            _host = host;
            _port = port;
        }
    }
}
