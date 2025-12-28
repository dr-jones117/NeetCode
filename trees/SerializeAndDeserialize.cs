#:property PublishAot=false
using System.Runtime.InteropServices;

var root = new TreeNode(1, new TreeNode(25), new TreeNode(32));
var codec = new Codec();
var test = codec.Serialize(root);
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

public class Codec {

    // Encodes a tree to a single string.
    public string Serialize(TreeNode root)
    {
        var res = new List<string>();
        if(root == null) return "N"; 
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while(queue.Count > 0)
        {
            var node = queue.Dequeue();
            if(node != null)
            {
                res.Add(node.val.ToString());
                queue.Enqueue(node.left);
                queue.Enqueue(node.right);
            }
            else
            {
                res.Add("N");
            }
        }

        return string.Join(",", res);
    }

    // Decodes your encoded data to tree.
    public TreeNode Deserialize(string data)
    {
        var vals = data.Split(',');
        if (vals[0] == "N") return null;
        var root =  new TreeNode(int.Parse(vals[0]));
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        int index = 1;

        while(queue.Count > 0)
        {
            var node = queue.Dequeue();
            if(vals[index] != "N")
            {
                node.left = new TreeNode(int.Parse(vals[index]));
                queue.Enqueue(node.left);
            }
            index++;
            if(vals[index] != "N")
            {
                node.right = new TreeNode(int.Parse(vals[index]));
                queue.Enqueue(node.right);
            }
            index++;
        }

        return root;
    }
}
