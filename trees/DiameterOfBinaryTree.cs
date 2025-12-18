using System.ComponentModel;

var five = new TreeNode(5);
var six = new TreeNode(6);
var seven = new TreeNode(7);

var four = new TreeNode(4, null, six);
var three = new TreeNode(3, null, five);
var two = new TreeNode(2, three, four);
var one = new TreeNode(1, null, two);

var sol = new Solution();
var d = sol.DiameterOfBinaryTree(one);

return 0;

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

public class Solution
{
    public int DiameterOfBinaryTree(TreeNode root)
    {
        var retMax = 0;
        DFS(root, ref retMax);
        return retMax;
    }

    private int DFS(TreeNode node, ref int retMax)
    {
        if(node == null) return 0;

        var max = 0;
        var left = DFS(node.left, ref retMax);
        var right = DFS(node.right, ref retMax);
        max = Math.Max(left, right);
        retMax = Math.Max(retMax, left + right);

        return 1 + max;
    }
}