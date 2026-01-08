using System.Diagnostics;

var sol = new Solution();
Debug.Assert(1 == sol.LastStoneWeight([2,3,6,2,4]));

public class Solution {
    public int LastStoneWeight(int[] stones) {
        var heap = new PriorityQueue<int, int>(Comparer<int>.Create((x, y) => y.CompareTo(x)));
        foreach(var stone in stones)
            heap.Enqueue(stone, stone);

        while(heap.Count > 1)
        {
            var x = heap.Dequeue();
            var y = heap.Dequeue();

            var diff = Math.Abs(x -  y);
            if(diff > 0)
                heap.Enqueue(diff, diff);
        }

        if(heap.Count <= 0)
            return 0;

        return heap.Peek(); 
    }
}
