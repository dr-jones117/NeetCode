using System.Diagnostics;

var pairs = new List<Pair>
{
    new Pair(5, "apple"),
    new Pair(2, "banana"),
    new Pair(9, "cherry")
};

var sol = new Solution();
var sorted = sol.InsertionSort(pairs);
Console.WriteLine(sorted);

public class Pair {
    public int Key;
    public string Value;

    public Pair(int key, string value) {
        Key = key;
        Value = value;
    }
}

public class Solution
{
    public List<List<Pair>> InsertionSort(List<Pair> pairs)
    {
        var states = new List<List<Pair>>();
        if(pairs.Count() < 1) return states;

        states.Add(new List<Pair>(pairs));

        for(int i = 1; i < pairs.Count(); i++)
        {
            var currIdx = i;
            while(currIdx > 0 && pairs[currIdx].Key < pairs[currIdx - 1].Key)
            {
                var temp = pairs[currIdx];
                pairs[currIdx] = pairs[currIdx - 1];
                pairs[currIdx - 1] = temp;
                currIdx--;
            }
            states.Add(new List<Pair>(pairs));
        }

        return states;
    }
}