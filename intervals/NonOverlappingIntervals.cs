using System.Diagnostics;

var sol = new Solution();
var res = sol.EraseOverlapIntervals([[1,2],[2,4],[1,4]]);
Debug.Assert(res == 1);

public class Solution {
    public int EraseOverlapIntervals(int[][] intervals)
    {
        Array.Sort(intervals, Comparer<int[]>.Create((x, y) => x[0].CompareTo(y[0])));
        int n = 0;
        for(int i = 0; i < intervals.Length - 1; i++)
        {
            var first = intervals[i];
            var second = intervals[i + 1];
            if(first[1] <= second[0])
                continue;

            if(first[1] < second[1])
                intervals[i + 1] = first;

            n++;
        }
        return n;
    }
}
