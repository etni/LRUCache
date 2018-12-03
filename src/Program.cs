using System;

namespace LRUCache
{
    public class Logger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }


    class Program
    {
        static Cache _cache;
        static ILogger _logger;

        static void L(string message) => _logger.Log(message);
        static void get(string key)
        {
            var value = _cache.Get(key) ?? "Not Found";
             
            L($"GET {key}: {value}");
        }

        static void set(string key, string value) {
            L($"SET {key} = {value}");
            _cache.Set(key, value);
        }

        static void print()
        {
            L($"=== Size {_cache.CurrentSize}/{_cache.MaxSize} ===");
            _cache.Print();
        }


        static void Main(string[] args)
        {
            _logger = new Logger();
            _cache = new Cache(3, _logger);

            get("foo");
            set("foo", "bar");
            get("foo"); // => "bar"
            set("a", "a");
            set("b", "b");
            set("c", "c");
             
            // // //foo gets evicted
            get("a");
            //h();
            set("d", "d");
            print();
            

        }
    }
}
