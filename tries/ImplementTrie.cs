var prefixTree = new PrefixTree();

prefixTree.Insert("dog");
var var1 = prefixTree.Search("dog");    // return true
var var2 = prefixTree.Search("do");     // return false
var var3 = prefixTree.StartsWith("do"); // return true
prefixTree.Insert("do");
var var4 = prefixTree.Search("do");     // return true
return 0;

public class PrefixTree
{
    private class TrieNode
    {
        public Dictionary<char, TrieNode> children;
        public bool isWordEnding;
        public TrieNode()
        {
            children = new Dictionary<char, TrieNode>();
            isWordEnding = false;
        }
    }

    private TrieNode tree;

    public PrefixTree()
    {
        tree = new TrieNode();
    }

    public void Insert(string word)
    {
        var currNode = this.tree;
        for(int i = 0; i < word.Length; i++)
        {
            if(!currNode.children.ContainsKey(word[i]))
                currNode.children[word[i]] = new TrieNode();

            currNode = currNode.children[word[i]];
        }

        currNode.isWordEnding = true;
    }

    public bool Search(string word)
    {
        var currNode = this.tree;
        for(int i = 0; i < word.Length; i++)
        {
            if(!currNode.children.ContainsKey(word[i]))
                return false;

            currNode = currNode.children[word[i]];
        }

        return currNode.isWordEnding;
    }

    public bool StartsWith(string prefix)
    {
        var currNode = this.tree;
        for(int i = 0; i < prefix.Length; i++)
        {
            if(!currNode.children.ContainsKey(prefix[i]))
                return false;

            currNode = currNode.children[prefix[i]];
        }

        return true;
    }
}