using System.Collections.Generic;

namespace LRUCache
{
    public class LRUCache
    {
        private ILogger _logger;
        private LRULinkedList _nodes;
        private Dictionary<string, Node> _hash;
        private int _size;

        public int MaxSize { get => _size; }

        public LRUCache(int size, ILogger logger){
            _nodes = new LRULinkedList(logger);
            _hash = new Dictionary<string, Node>();
            _size = size;
            _logger = logger;
        }

        public int CurrentSize { get => _nodes.CurrentSize; }

        public void Print() => _nodes.Print();

        public string Get(string key){
            if (_hash.ContainsKey(key))
            {
                var node = _hash[key];
                _nodes.Touch(node);
                return node.Value;
            }
            return null;
        }

        public void Put(string key, string value)
        {
            if(_hash.ContainsKey(key)){
                var node = _hash[key];
                node.Value = value;
                _nodes.Touch(node);
            }
            else {
                if (_nodes.CurrentSize + 1 > MaxSize) {
                    var evictedKey = _nodes.Evict();
                    _hash.Remove(evictedKey);
                }
                var newNode = _nodes.Add(key,value);
                _hash.Add(key,newNode);
            }
        }




    }
    
}