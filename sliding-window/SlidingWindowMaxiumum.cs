using System.Data;
using System.Diagnostics;

var sol = new Solution();
Debug.Assert(sol.MaxSlidingWindow([1,2,1,0,4,2,6], 3).SequenceEqual([2,2,4,4,6]));
return 0;

public class Solution {
    private class myComparer: IComparer<int>
    {
        public int Compare(int left, int right)
        {
            return right.CompareTo(left);
        }
    }

    // i could make this more efficient in the future by storing more info in the
    // priority queue
    public int[] MaxSlidingWindow(int[] nums, int k) {
        var queue = new PriorityQueue<int, int>(new myComparer());
        var res = new List<int>();

        var l = 0;
        var numsCount = nums.Count();
        for(int i = 0; i < numsCount; i++)
        {
            queue.Enqueue(nums[i], nums[i]);
            if(i >= k - 1)
            {
                res.Add(queue.Peek());
                queue.Remove(nums[l], out int idc, out int idc2);
                l++;
            }

        }

        return res.ToArray();
    }
}
