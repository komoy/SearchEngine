namespace SearchEngine.Indexing
{
    
    public class SimpleIndexer
    {
        private Dictionary<string, string> _index = new Dictionary<string, string>();

        // Add or update an entry in the index
        public void Add(string key, string value)
        {
            _index[key] = value;
        }

        // Retrieve a value by its key
        public string? Get(string key)
        {
            return _index.TryGetValue(key, out var value) ? value : null;
        }

        // Remove an entry from the index
        public bool Remove(string key)
        {
            return _index.Remove(key);
        }

        // List all entries
        public void ListAll()
        {
            foreach (var entry in _index)
            {
                Console.WriteLine($"Key: {entry.Key}, Value: {entry.Value}");
            }
        }
    }

}
