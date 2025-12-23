public class Solution {

    public List<int> RightSideView(TreeNode root) {
        var res = new List<int>();
        var queue = new Queue<TreeNode>();

        if(root == null) return res;       
        queue.Enqueue(root);

        while(queue.Count > 0)
        {
            var amount = queue.Count;
            var last = amount - 1;
            for(int i = 0; i < amount; i++)
            {
                var node = queue.Dequeue();
                if(last == i)
                {
                    res.Add(node.val);
                }
                if(node.left != null)
                {
                    queue.Enqueue(node.left);
                }
                if(node.right != null)
                {
                    queue.Enqueue(node.right);
                }
            }
        }
        return res;
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