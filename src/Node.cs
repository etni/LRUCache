namespace LRUCache
{
    public class Node 
    {
        public Node Prev { get; set; }
        public Node Next { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public int TouchedTimes { get; set; }
    }
    
}