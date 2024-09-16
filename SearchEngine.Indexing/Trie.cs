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


        // Insert a key into the Trie
        public void Insert(string key, string value)
        {
            var node = _root;
            foreach (var ch in key)
            {
                if (!node.Children.ContainsKey(ch))
                {
                    node.Children[ch] = new TrieNode();
                }
                node = node.Children[ch];
            }
            node.IsEndOfWord = true;
            node.Values.Add(value); 
        }


        // Search for a word in the trie
        // Modified search to return the second value
        public string Search(string key)
        {
            var node = _root;
            foreach (var ch in key.ToLower())
            {
                if (!node.Children.ContainsKey(ch))
                {
                    return null; // Key not found
                }
                node = node.Children[ch];
            }

            // Check if at least two values exist and return the second one
            if (node.Values.Count > 1)
            {
                return node.Values[1]; // Return the second item
            }
            else if (node.Values.Count == 1)
            {
                return node.Values[0]; // Return the first item if only one exists
            }

            return null; // No values found
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