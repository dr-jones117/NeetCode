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

public class Solution {
    public int KthSmallest(TreeNode root, int k) {
        var stack = new Stack<TreeNode>();
        var curr = root;
        while(stack.Count > 0 || curr != null)
        {
            while(curr != null)
            {
                stack.Push(curr);
                curr = curr.left;
            }

            k--;
            var nodeToProcess = stack.Pop();
            if(k == 0)
                return nodeToProcess.val;
            
            curr = nodeToProcess.right;
        }        
        return -1;
    }
}
