public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val=0, TreeNode left=null, TreeNode right=null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class Solution
{
    public int MaxDepth(TreeNode root)
    {
        var depth = DFS(root);
        return depth;
    }

    private int DFS(TreeNode node)
    {
        if(node == null) return 0;
        var left = DFS(node.left);
        var right = DFS(node.right);
        return 1 + Math.Max(left, right);
    }
}