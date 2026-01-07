using System.Diagnostics;

KthLargest kthLargest = new KthLargest(3, [1, 2, 3, 3]);
Debug.Assert(kthLargest.Add(3) == 3);
Debug.Assert(kthLargest.Add(5) == 3);
Debug.Assert(kthLargest.Add(6) == 3);   // return 3
Debug.Assert(kthLargest.Add(7) == 5);   // return 5
Debug.Assert(kthLargest.Add(8) == 6);   // return 6

public class KthLargest {

    private PriorityQueue<int, int> heap;
    private int k;

    public KthLargest(int k, int[] nums) {
        heap = new PriorityQueue<int, int>();
        foreach(var num in nums)
        {
            heap.Enqueue(num, num);
            if(heap.Count > k)
            {
                heap.Dequeue();
            }
        }

        this.k = k;
    }
    
    public int Add(int val) {
        heap.Enqueue(val, val);
        if(heap.Count > k)
        {
            heap.Dequeue();
        }
        return heap.Peek();
    }
}
