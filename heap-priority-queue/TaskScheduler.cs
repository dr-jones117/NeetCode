using System.Collections;
using System.Diagnostics;
using Microsoft.VisualBasic;

var sol = new Solution();
Debug.Assert(sol.LeastInterval(['X', 'X', 'Y', 'Y'], 2) == 5);
Debug.Assert(sol.LeastInterval(['A', 'A', 'A', 'B', 'C'], 3) == 9);

public class Solution {
    public int LeastInterval(char[] tasks, int n)
    {
        var lastSeen = new Dictionary<char, int>();
        var taskHeap = new PriorityQueue<char, int>();

        int t = 0;
        for(int i = 0; i < tasks.Length; i++)
        {
            var curr = tasks[i];
            var minTime = Int32.MaxValue;
            if(!lastSeen.ContainsKey(curr) || lastSeen[curr] + n + 1 < t)
            {
                minTime = t;
                t++;
            }
            else
                minTime = lastSeen[curr] + n + 1;
            taskHeap.Enqueue(curr, minTime);
            lastSeen[curr] = minTime;
        }

        t = 0;
        while(taskHeap.Count > 0)
        {
            if(taskHeap.TryDequeue(out char currTask, out int priority))
            {
                if(t < priority) t = priority;
                t++;
            }
        }

        return t;
    }
}
