MedianFinder medianFinder = new MedianFinder();
medianFinder.AddNum(1);    // arr = [1]
var one = medianFinder.FindMedian(); // return 1.0
medianFinder.AddNum(2);    // arr = [1, 3]

var two = medianFinder.FindMedian(); // return 2.0
medianFinder.AddNum(3);    // arr[1, 2, 3]
var twoTwo = medianFinder.FindMedian(); 

return 0;
public class MedianFinder {
    PriorityQueue<int, int> low;
    PriorityQueue<int, int> high;
    public MedianFinder() {
        low = new PriorityQueue<int, int>(Comparer<int>.Create((x,y) => y.CompareTo(x)));
        high = new PriorityQueue<int, int>();
    }
    
    public void AddNum(int num) {
        low.Enqueue(num, num);

        var lowVal = low.Dequeue();
        high.Enqueue(lowVal, lowVal);

        if(high.Count > low.Count)
        {
            var highVal = high.Dequeue();
            low.Enqueue(highVal, highVal);
        }
    }
    
    public double FindMedian() {
        if((low.Count + high.Count) % 2 == 0)
        {
            return (double)(low.Peek() + high.Peek()) / 2;
        }
        return low.Peek();
    }
}
