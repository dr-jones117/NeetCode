var root = new TreeNode(2, new TreeNode(1), new TreeNode(3));
var sol = new Solution();
Console.WriteLine(sol.IsValidBST(root));

public class Solution {
    public bool IsValidBST(TreeNode root) {
        // to determine if it's a valid BST, we need to check if the current node
        // is less than a value or greater than a value
        // node - obv, int - should be less than , int - should be greater than
        var stack = new Stack<Tuple<TreeNode, int, int>>();
        if(root == null) return true;
        stack.Push(new Tuple<TreeNode, int, int>(root, Int32.MaxValue, Int32.MinValue));
        bool atRoot = true;
        while(stack.Count > 0)
        {
            var (node, lesser, greater) = stack.Pop();
            if(!atRoot && (node.val >= lesser || node.val <= greater))
                return false;
            atRoot = false;
            
            if(node.left != null)
                stack.Push(new Tuple<TreeNode, int, int>(node.left, node.val, greater));    
            if(node.right != null)
                stack.Push(new Tuple<TreeNode, int, int>(node.right, lesser, node.val));    
        }
        return true;
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