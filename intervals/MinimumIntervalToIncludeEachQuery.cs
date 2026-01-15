using System.Diagnostics;

var sol =  new Solution();
var resOne = sol.MinInterval([[1,3],[2,3],[3,7],[6,6]], [2,3,1,7,6,8]);
Debug.Assert(resOne.SequenceEqual([2,2,3,5,1,-1]));

public class Solution {
    public int[] MinInterval(int[][] intervals, int[] queries)
    {
        var sortedQueries = new (int queryVal, int index)[queries.Length];
        int i = 0;
        for(; i < queries.Length; i++)
        {
            sortedQueries[i] = (queries[i], i);
        }

        Array.Sort(sortedQueries, (a, b) => a.queryVal.CompareTo(b.queryVal));
        Array.Sort(intervals, (x, y) => x[0].CompareTo(y[0]));

        var minHeap = new PriorityQueue<int, int>();
        var res = new int[queries.Length];

        i = 0;
        foreach(var (queryVal, originalIndex) in sortedQueries)
        {
            while(i < intervals.Length && intervals[i][0] <= queryVal)
            {
                minHeap.Enqueue(intervals[i][1], intervals[i][1] - intervals[i][0] + 1);
                i++;
            }

            while(minHeap.Count > 0 && queryVal > minHeap.Peek())
                minHeap.Dequeue();

            if(minHeap.Count <= 0)
                res[originalIndex] = -1;
            else
            {
                minHeap.TryPeek(out _, out int len);
                res[originalIndex] = len;
            }
        }

        return res;
    }
}
