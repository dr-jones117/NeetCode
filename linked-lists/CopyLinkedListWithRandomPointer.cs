
var four = new Node(4);
var three = new Node(3);
var two = new Node(2);
var one = new Node(1);
one.next = two;
two.next = three;
three.next = four;
two.random = four;
three.random = one;
four.random = two;

var newlist = copyRandomList(one);
return 0;

Node copyRandomList(Node head) {
    if(head == null) return null;

    var oldNewDict = new Dictionary<Node, Node?>();
    var currPtr = head;
    
    while(currPtr != null)
    {
        var newCurrPtr = new Node(currPtr.val);
        oldNewDict.Add(currPtr, newCurrPtr);
        currPtr = currPtr.next;
    }

    currPtr = head;

    while(currPtr != null)
    {
        var newPtr = oldNewDict[currPtr];
        if(currPtr.next != null)
        {
            newPtr.next = oldNewDict[currPtr.next];
        }
        if(currPtr.random != null)
        {
            newPtr.random = oldNewDict[currPtr.random];
        }
        currPtr = currPtr.next;
    }

    return oldNewDict[head];        
}

public class Node {
    public int val;
    public Node next;
    public Node random;
    
    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}
