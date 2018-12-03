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
        static LRUCache cache;
        static ILogger _logger;

        static void L(string message) => _logger.Log(message);
        static void get(string key)
        {
            var value = cache.Get(key) ?? "Not Found";
             
            L($"GET {key}: {value}");
        }

        static void put(string key, string value) {
            L($"SET {key} = {value}");
            cache.Put(key, value);
        }

        static void print()
        {
            L($"=== Size {cache.CurrentSize}/{cache.MaxSize} ===");
            cache.Print();
        }


        static void Main(string[] args)
        {
            _logger = new Logger();
            cache = new LRUCache(3, _logger);
            put("a", "a");
            put("b", "b");
            put("c", "c");
            get("a");
            put("d", "d");
            print();

        }
    }
}
