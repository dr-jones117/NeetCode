using System.Diagnostics;

int FindMin(int[] nums)
{
    var left = 0;
    var right = nums.Length - 1;

    //if array is sorted, return the first number
    if(nums[left] < nums[right]) return nums[0];

    while(left <= right)
    {
        var mid = left + (right - left) / 2;
        var currNum = nums[mid];

        var nextIdx = mid >= nums.Length - 1 ? 0 : mid + 1;
        if(currNum > nums[nextIdx])
        {
            return nums[nextIdx];
        }
        else if(currNum < nums[0])
        {
            right = mid - 1;
        }
        else
        {
            left = mid + 1;
        }
    }

    return nums[0];
}

Debug.Assert(FindMin([3,4,5,6,1,2]) == 1);
Debug.Assert(FindMin([4,5,0,1,2,3]) == 0);