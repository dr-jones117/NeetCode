using System.Diagnostics;

int[] TopKFrequent(int[] nums, int k)
{
    var topKFreq = nums
        .GroupBy(x => x)
        .Select(g => g.ToList())
        .OrderByDescending(l => l.Count)
        .Take(k)
        .ToList()
        .Select(x => x[0])
        .ToArray();

    return topKFreq;
}

Debug.Assert(TopKFrequent([1,2,2,3,3,3], 2).SequenceEqual([2,3]));
Debug.Assert(TopKFrequent([7,7], 1).SequenceEqual([7]));