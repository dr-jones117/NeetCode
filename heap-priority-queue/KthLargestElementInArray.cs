using System.Diagnostics;
var sol = new Solution();
Debug.Assert(sol.FindKthLargest([2,3,1,5,4], 2) == 4);

public class Solution {
    public int FindKthLargest(int[] nums, int k) {
        var heap = new PriorityQueue<int, int>(Comparer<int>.Create((x,y) => y.CompareTo(x)));
        foreach(var num in nums)
        {
            heap.Enqueue(num, num);
        }

        var res = Int32.MinValue;
        for(int i = 0; i < k; i++)
            res = heap.Dequeue();
        return res;
    }
}
