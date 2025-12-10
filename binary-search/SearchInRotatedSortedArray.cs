using System.Diagnostics;

var sol = new Solution();

Debug.Assert(sol.Search([3,4,5,6,1,2], 1) == 4);
Debug.Assert(sol.Search([3,5,6,0,1,2], 4) == -1);
Debug.Assert(sol.Search([1], 1) == 0);

public class Solution
{
    public int Search(int[] nums, int target)
    {
        var left = 0;
        var right = nums.Length - 1;

        while(left <= right)
        {
            var mid = left + (right - left) / 2;
            var nextIdx = mid == nums.Length - 1 ? 0: mid + 1;
            if(nums[mid] == target)
            {
                return mid;
            }
            else if(nums[mid] > nums[nextIdx])
            {
                //we can now search both the left and the right side
                var firstHalfSearchResult = BinarySearchWithBounds(nums, target, 0, mid);
                var secondHalfSearchResult = BinarySearchWithBounds(nums, target, mid + 1, nums.Length - 1);
                return firstHalfSearchResult == -1 ? secondHalfSearchResult: firstHalfSearchResult;
            }
            else if(nums[mid] >= nums[0])
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return -1;
    }

    private int BinarySearchWithBounds(int[] nums, int target, int left, int right)
    {
        while(left <= right)
        {
            var mid = left + (right - left) / 2;
            if(nums[mid] < target)
            {
                left = mid + 1;
            }
            else if(nums[mid] > target)
            {
                right = mid - 1;
            }
            else
            {
                return mid;
            }
        }

        return -1;
    }
}