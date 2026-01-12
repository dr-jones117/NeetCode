#:property PublishAot=false
using System.Diagnostics;

var sol = new Solution();
var res = sol.CombinationSum2([9,2,2,4,6,1,5], 8);
return 0;
public class Solution {
     public List<List<int>> CombinationSum2(int[] candidates, int target) {
        Array.Sort(candidates);
        var res = new List<List<int>>();
        var currSol = new List<int>();
        dfs(candidates, target, 0, 0, res, currSol);
        return res;
    }

    public void dfs(int[] nums, int target, int i, int currSum, List<List<int>> res, List<int> currSol)
    {
        if(currSum == target)
        {
            var newSol = new List<int>(currSol);
            res.Add(newSol);
            return;
        }

        if(currSum > target || i >= nums.Length)
            return;

        currSol.Add(nums[i]);
        currSum += nums[i];
        dfs(nums, target, i + 1, currSum, res, currSol);
        currSol.RemoveAt(currSol.Count - 1);
        currSum -= nums[i];
        
        while (i + 1 < nums.Length && nums[i] == nums[i + 1])
        {
            i++;
        }
        dfs(nums, target, i + 1, currSum, res, currSol);
    }
}
