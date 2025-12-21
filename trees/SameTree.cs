using System.Diagnostics;

var three = new TreeNode(3);
var two = new TreeNode(2);
var one = new TreeNode(1, two, three);


var threeTwo = new TreeNode(3);
var twoTwo = new TreeNode(2);
var oneTwo = new TreeNode(1, twoTwo, threeTwo);

Debug.Assert(IsSameTree(one, oneTwo));

bool IsSameTree(TreeNode p, TreeNode q)
{
    // edge cases for nulls
    if(p == null && q == null) return true;
    if(p == null || q == null) return false;

    // put the roots into the queue since they both exist
    var queue = new Queue<Tuple<TreeNode, TreeNode>>();
    queue.Enqueue(new Tuple<TreeNode, TreeNode>(p, q));

    while(queue.Count > 0)
    {
        var treeLevelAmount = queue.Count;
        for(int i = 0; i < treeLevelAmount; i++)
        {
            var (leftNode, rightNode) = queue.Dequeue();
            if(leftNode.val != rightNode.val) return false;
            
            if(leftNode.left != null && leftNode.left != null)
                queue.Enqueue(new Tuple<TreeNode, TreeNode>(leftNode.left, rightNode.left));
            else if(leftNode.left != null || rightNode.left != null)
                return false;

            if(leftNode.right != null && leftNode.right != null)
                queue.Enqueue(new Tuple<TreeNode, TreeNode>(leftNode.right, rightNode.right));
            else if(leftNode.right != null || rightNode.right != null)
                return false;
        }
    }

    return true;
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