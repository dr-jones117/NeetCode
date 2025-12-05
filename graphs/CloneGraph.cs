using System.Diagnostics;

var head = new Node(1);
var two = new Node(2);
var three= new Node(3);

head.neighbors.Add(two);
two.neighbors.Add(head);
two.neighbors.Add(three);
three.neighbors.Add(two);

var sol = new Solution();

var clone = sol.CloneGraph(head);
return 0;

// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}

public class Solution {
    public Node CloneGraph(Node node)
    {
        var visited = new Dictionary<int, Node>();

        return DFS(node, ref visited);
    }

    private Node DFS(Node node, ref Dictionary<int, Node> visited)
    {
        if(node == null) return null;
        if(visited.ContainsKey(node.val)) return visited[node.val];

        var currNode = new Node(node.val);
        visited[node.val] = currNode;

        foreach(var neighbor in node.neighbors)
            currNode.neighbors.Add(DFS(neighbor, ref visited));

        return currNode;
    }
}