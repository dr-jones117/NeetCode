using System.Diagnostics;

var sol = new Solution();
var res = sol.MinMeetingRooms(new List<Interval>([new Interval(0,40), new Interval(4,10), new Interval(15,20)]));
Debug.Assert(res == 2);

public class Interval {
    public int start, end;
    public Interval(int start, int end) {
        this.start = start;
        this.end = end;
    }
}

public class Solution {
    public int MinMeetingRooms(List<Interval> intervals)
    {
        // base cases
        if(intervals.Count == 0) return 0;
        if(intervals.Count == 1) return 1;

        var heap = new PriorityQueue<int, int>();

        // we need to sort!
        intervals = intervals.OrderBy(x => x.start).ToList();

        heap.Enqueue(intervals[0].end, intervals[0].end);

        for(int i = 1; i < intervals.Count; i++)
        {
            if(intervals[i].start >= heap.Peek())
            {
                heap.Dequeue();
            }
            heap.Enqueue(intervals[i].end, intervals[i].end);
             
        }
        return heap.Count;
    }
}
