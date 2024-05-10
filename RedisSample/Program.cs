using StackExchange.Redis;

namespace RedisSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start Redis Sample!");

            RedisSimpleTest();
        }

        static void RedisSimpleTest()
        {
            // ConfigurationOptions
            ConfigurationOptions config = ConfigurationOptions.Parse("127.0.0.1:6379");
            ConnectionMultiplexer conn = ConnectionMultiplexer.Connect(config.ToString());

            IDatabase db = conn.GetDatabase();

            // Set
            string value = "Hello World";
            db.StringSet("Test", value);

            // Get
            RedisValue test = db.StringGet("Test");

            Console.WriteLine(test);
        }
    }
}