using System.Security.Cryptography.X509Certificates;

var sol = new Solution();

var res = sol.FindWords(new char[][] {
  new char[] {'a','b','c','d'},
  new char[] {'s','a','a','t'},
  new char[] {'a','c','k','e'},
  new char[] {'a','c','d','n'}
}, new string[] {"bat","cat","back","backend","stack"});
return 0;
public class Solution {
    private class TrieNode
    {
        public TrieNode[] children;
        public string word;

        public TrieNode()
        {
            children = new TrieNode[26];
            word = null;
        }
    }

    private void AddWord(TrieNode root, string word)
    {
        var currNode = root;
        foreach(var c in word)
        {
            var idx = (int)c - 97;
            if(currNode.children[idx] == null)
                currNode.children[idx] = new TrieNode();

            currNode = currNode.children[idx];
        }
        currNode.word = word;      
    }

    private void Dfs(int row, int col, TrieNode node, char[][] board, List<string> res)
    {
        char c = board[row][col];
        if (c == '#' || node.children[c - 97] == null) return;

        node = node.children[c - 97];
        if (node.word != null)
        {
            res.Add(node.word);
            node.word = null;
        }

        board[row][col] = '#';

        if (row > 0) Dfs(row - 1, col, node, board, res);
        if (col > 0) Dfs(row, col - 1, node, board, res);
        if (row < board.Length - 1) Dfs(row + 1, col, node, board, res);
        if (col < board[0].Length - 1) Dfs(row, col + 1, node, board, res);

        board[row][col] = c;
    }

    public List<string> FindWords(char[][] board, string[] words) {
        var trieRoot = new TrieNode();
        foreach(var word in words)
            AddWord(trieRoot, word);

        var res = new List<string>();
        int rows = board.Length;
        int cols = board[0].Length;

        for(int row = 0; row < rows; row++)
        {
            for(int col = 0; col < cols; col++)
                Dfs(row, col, trieRoot, board, res);
        }

        return res;
    }
}
