var six = new ListNode(6);
var five = new ListNode(5, six);
var four = new ListNode(4, five);
var three = new ListNode(3, four);
var two = new ListNode(2, three);
var one = new ListNode(1, two);
var zero = new ListNode(0, one);

var sol = new Solution();
sol.ReorderList(zero);

return 0;

public class Solution {
    public void ReorderList(ListNode head) {
        // edge cases: if the list is empty or only one point long. short curcuit
        if(head == null || head.next == null) return;

        // we need to start with slow+fast pointers to get our midpoint
        // and the end of our list
        ListNode slow = head, fast = head;
        while(fast.next != null && fast.next.next != null)
        {
            fast = fast.next.next;
            slow = slow.next;
        }

        // we need to reverse the second half of our list
        var currPtr = slow.next;
        slow.next = null;
        ListNode prev = null;

        while(currPtr != null)
        {
            var next = currPtr.next;
            currPtr.next = prev;
            prev = currPtr;
            currPtr = next;
        }

        // prev and head are the heads of our two lists
        // now we just need to reorder them
        var currOne = head;
        var currTwo = prev;
        while(currOne != null && currTwo != null)
        {
            var currOneNext = currOne.next;
            currOne.next = currTwo;
            currOne = currOneNext;

            var currTwoNext = currTwo.next;
            currTwo.next = currOne;
            currTwo = currTwoNext;
        }
    }
}

public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int val=0, ListNode next=null) {
        this.val = val;
        this.next = next;
    }
}
