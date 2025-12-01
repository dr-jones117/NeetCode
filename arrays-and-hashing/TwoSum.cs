using System.Diagnostics;

int[] TwoSum(int[] nums, int target)
{
    var numDict = new Dictionary<int, int>();
    for(int i = 0; i < nums.Length; i++)
    {
        var complement = target - nums[i];
        if(numDict.TryGetValue(complement, out int idx))
        {
            return [idx, i];
        }
        numDict[nums[i]] = i;
    }

    return [];
}

int[] expected = [0,1];
Debug.Assert(TwoSum([3,4,5,6], 7) is [0,1]);
expected = [0,1];
Debug.Assert(TwoSum([5,5], 10) is [0,1]);
