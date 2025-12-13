using System.Diagnostics;

var four = new ListNode(4);
var three = new ListNode(3, four);
var two = new ListNode(2, three);
var one = new ListNode(1, two);

var removed = RemoveNthFromEnd(one, 2);


two = new ListNode(2);
one = new ListNode(1, two);
removed = RemoveNthFromEnd(one, 2);
return 0;

ListNode RemoveNthFromEnd(ListNode head, int n)
{
    if(head == null || head.next == null) return null;

    var headPtr = head;
    int size = 0;
    while(headPtr != null)
    {
        size++;
        headPtr = headPtr.next;
    }

    var amountToMove = size - n;
    headPtr = head;
    var prev = new ListNode(-1, headPtr);
    var dummy = new ListNode(-1, prev);
    for(int i = 0; i < amountToMove; i++)
    {
        headPtr = headPtr.next;
        prev = prev.next;
    }

    prev.next = headPtr.next;

    return dummy.next.next;
}

public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int val=0, ListNode next=null) {
        this.val = val;
        this.next = next;
    }
}