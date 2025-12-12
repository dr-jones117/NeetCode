using System.Diagnostics;

double FindMedianSortedArrays(int[] nums1, int[] nums2)
{
    // Always search on the smaller array
    if (nums1.Length > nums2.Length)
        return FindMedianSortedArrays(nums2, nums1);
    
    int[] small = nums1;
    int[] large = nums2;
    int halfSize = (small.Length + large.Length + 1) / 2;
    
    int left = 0, right = small.Length;
    
    while(left <= right)
    {
        int cut1 = left + (right - left) / 2;
        int cut2 = halfSize - cut1;
        
        int left1 = (cut1 == 0) ? int.MinValue : small[cut1 - 1];
        int right1 = (cut1 == small.Length) ? int.MaxValue : small[cut1];
        int left2 = (cut2 == 0) ? int.MinValue : large[cut2 - 1];
        int right2 = (cut2 == large.Length) ? int.MaxValue : large[cut2];
        
        if(left1 <= right2 && left2 <= right1)
        {
            bool isEven = (small.Length + large.Length) % 2 == 0;
            return isEven ? (Math.Max(left1, left2) + Math.Min(right1, right2)) / 2.0 
                          : Math.Max(left1, left2);
        }
        else if(left1 > right2)
            right = cut1 - 1;
        else
            left = cut1 + 1;
    }
    
    return -1.0;
}

Debug.Assert(FindMedianSortedArrays([1,2],[3]) == 2.0);
Debug.Assert(FindMedianSortedArrays([1,3],[2,4]) == 2.5);