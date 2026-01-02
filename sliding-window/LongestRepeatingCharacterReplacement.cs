using System.Diagnostics;

var sol = new Solution();
Debug.Assert(sol.CharacterReplacement("xyyx", 2) == 4);

public class Solution {
    public int CharacterReplacement(string s, int k) {
        var freqCount = new Dictionary<char, int>();
        var res = 0;

        int l = 0, maxFreq = 0;
        for(int r = 0; r < s.Length; r++)
        {
            if(freqCount.ContainsKey(s[r]))
            {
                freqCount[s[r]]++;
            }
            else
            {
                freqCount[s[r]] = 1;
            }

            maxFreq = Math.Max(maxFreq, freqCount[s[r]]);

            while((r - l + 1) - maxFreq > k)
            {
                freqCount[s[l]]--;
                l++;
            }

            res = Math.Max(res, r - l + 1);
        }

        return res;
    }
}
