using System;

namespace LRUCache
{
    public class LRULinkedList
    {
        public int CurrentSize { get; set; }
        public Node Head { get; set; }
        public Node Tail { get; set; }
        private ILogger _logger;

        public LRULinkedList(ILogger logger) {
            Head = null;
            Tail = null;
            CurrentSize = 0;
            _logger = logger;
        }

        /*

         */
        public void Touch(Node node)
        {
            node.TouchedTimes++;
            // already at Tail
            if(Tail == node) return;

            // Reset Head
            if (Head == node){
                Head = node.Next;
                Head.Prev = null;
            }

            // Link node's adjacent nodes
            if(node.Prev != null)
                node.Prev.Next = node.Next;
            node.Next.Prev = node.Prev;

            // Setup Tail 
            Tail.Next = node;
            node.Prev = Tail;

            Tail = node;
            Tail.Next = null;
            _logger.Log($"TOUCHED {node.Key}");
        }

        public Node Add(string key, string value)
        {
            var newNode = new Node {
                Prev = Tail,
                Next = null,
                Key = key,
                Value = value
            };

            if (Tail != null) Tail.Next = newNode;
            Tail = newNode;

            if(Head == null) Head = newNode;

            CurrentSize++;
            return newNode;
        }

        // retuns the key of the Evicted Node
        public string Evict() 
        {
            if(Head == null) return null;

            var evictedKey = Head.Key;

            Head = Head.Next;

            if (Head != null) Head.Prev = null;

            CurrentSize--;

            _logger.Log($"EVICTED {evictedKey}");

            return evictedKey;
        }

        // for debugging:
        public void Print()
        {
            if (CurrentSize == 0)
            Console.WriteLine("Cache is Empty");
            var node = Head;
            var i = 0;

            while (node != null) {
                Console.WriteLine($"{++i}: {node.Key} = {node.Value}");
                node = node.Next;
            }
        }
        
    }
    
}