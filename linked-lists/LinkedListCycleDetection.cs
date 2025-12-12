using System.Diagnostics;

var four = new ListNode(4);
var three = new ListNode(3, four);
var two = new ListNode(2, three);
var one = new ListNode(1, two);
four.next = two;

var merged = HasCycle(one);

bool HasCycle(ListNode head)
{
    var slow = head;
    var fast = head;
    while(fast != null && fast.next != null)
    {
        slow = slow.next;
        fast = fast.next.next;

        if(slow == fast)
        {
            return true;
        } 
    }
    return false;
}

public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int val=0, ListNode next=null) {
        this.val = val;
        this.next = next;
    }
}