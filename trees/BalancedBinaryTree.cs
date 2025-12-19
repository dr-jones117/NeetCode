var four = new TreeNode(4);
var three = new TreeNode(3, four, null);
var two = new TreeNode(2);
var one = new TreeNode(1, two, three);

var sol = new Solution();
sol.IsBalanced(one);

public class Solution
{
    public bool IsBalanced(TreeNode root)
    {
        bool balanced;
        DFS(root, out balanced);
        return balanced;
    }

    private int DFS(TreeNode node, out bool balanced)
    {
        balanced = false;

        if(node == null)
        {
            balanced = true;
            return 0;
        }

        bool balLeft;
        bool balRight;
        var left = DFS(node.left, out balLeft);
        var right = DFS(node.right, out balRight);

        if(Math.Abs(left - right) <= 1)
            balanced = true;
        if(!balLeft || !balRight)
            balanced = false;

        return 1 + Math.Max(left, right);
    }
}

public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}