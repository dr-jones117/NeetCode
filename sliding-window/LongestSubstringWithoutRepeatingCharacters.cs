using System.Diagnostics;

var sol = new Solution();
Debug.Assert(sol.LengthOfLongestSubstring("zxyzxyz") == 3);
Debug.Assert(sol.LengthOfLongestSubstring("xxxx") == 1);


public class Solution {
    public int LengthOfLongestSubstring(string s) {
        if(s.Length == 0) return 0;

        var seenSet = new HashSet<char>();
        var res = 1;
        var start = 0;
        seenSet.Add(s[0]);

        for(int i = 1; i < s.Length; i++)
        {
            while(seenSet.Contains(s[i]))
            {
                seenSet.Remove(s[start]);
                start++;
            }

            seenSet.Add(s[i]);
            res = Math.Max(res, (i + 1) - start);
        }

        return res;
    }
}
