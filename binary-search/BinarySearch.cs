using System.Diagnostics;

int Search(int[] nums, int target)
{
    var left = 0;
    var right = nums.Length - 1;

    while(left <= right)
    {
        var mid = ((right - left) / 2) + left;
        if(nums[mid] == target) return mid;
        
        if(nums[mid] < target)
        {
            left = mid + 1;
        }
        else if(nums[mid] > target)
        {
            right = mid - 1;
        }
    }

    return -1;
}

Debug.Assert(Search([-1,0,2,4,6,8], 4) == 3);

