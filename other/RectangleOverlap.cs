#:property PublishAot=false

using System.Diagnostics;

var sol = new Solution();
Debug.Assert(sol.IsRectangleOverlap([0,0,2,2], [1,1,3,3]));
Debug.Assert(!sol.IsRectangleOverlap([0,0,1,1], [1,0,2,1]));

public class Solution {
    public bool IsRectangleOverlap(int[] rec1, int[] rec2)
    {
        return !(
            // check for when they aren't overlapping then return the opposite
            // left 
            rec1[2] <= rec2[0] || 
            // right
            rec1[0] >= rec2[2] ||
            // up
            rec1[1] >= rec2[3] ||
            //down  
            rec1[3] <= rec2[1]
            );
    }


    public bool IsRectangleOverlapCondensed(int[] rec1, int[] rec2)
    {
        return !(rec1[2] <= rec2[0] || rec1[0] >= rec2[2] || 
                 rec1[1] >= rec2[3] || rec1[3] <= rec2[1]);
    }
}