using System;
using System.Collections.Generic;

namespace SearchEngine.Indexing
{

    public class Trie
    {
        private readonly TrieNode _root = new TrieNode();

        // Insert a word into the trie
        public void Insert(string word)
        {
            var node = _root;
            foreach (var ch in word)
            {
                if (!node.Children.ContainsKey(ch))
                {
                    node.Children[ch] = new TrieNode();
                }
                node = node.Children[ch];
            }
            node.IsEndOfWord = true;
        }

        // Search for a word in the trie
        public bool Search(string word)
        {
            var node = GetNode(word);
            return node != null && node.IsEndOfWord;
        }

        // Check if there is any word in the trie that starts with the given prefix
        public bool StartsWith(string prefix)
        {
            return GetNode(prefix) != null;
        }

        // Helper method to get the TrieNode corresponding to the given prefix
        private TrieNode? GetNode(string prefix)
        {
            var node = _root;
            foreach (var ch in prefix)
            {
                if (!node.Children.ContainsKey(ch))
                {
                    return null;
                }
                node = node.Children[ch];
            }
            return node;
        }
    }
}