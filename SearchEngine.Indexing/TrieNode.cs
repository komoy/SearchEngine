namespace SearchEngine.Indexing
{
    public class TrieNode
    {
        public Dictionary<char, TrieNode> Children { get; } = new Dictionary<char, TrieNode>();
        public bool IsEndOfWord { get; set; }

        public List<string> Values { get; set; } = new();
    }
}