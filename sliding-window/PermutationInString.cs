using System.Diagnostics;

var sol = new Solution();

Debug.Assert(sol.CheckInclusion("abc", "lecabee"));
Debug.Assert(sol.CheckInclusion("adc", "dcda"));
Debug.Assert(!sol.CheckInclusion("abc", "lecaabee"));

public class Solution {
    public bool CheckInclusion(string s1, string s2) {
        if(s1.Length > s2.Length)
            return false;

        // create a freq dict for s1
        var checkDict = new Dictionary<char, int>();
        for(int i = 0; i < s1.Length; i++)
        {
            if(!checkDict.ContainsKey(s1[i]))
                checkDict[s1[i]] = 0;
            checkDict[s1[i]]++;
        }

        var l = 0;
        var currDict = new Dictionary<char, int>();
        for(int r = 0; r < s2.Length; r++)
        {
            // add the current char to the currDict
            if(!currDict.ContainsKey(s2[r]))
                currDict[s2[r]] = 0;
            currDict[s2[r]]++;

            // if the right char isn't in the checkDict,
            // or adding the new char would create a greater freq than 
            // the checkDict
            if(!checkDict.ContainsKey(s2[r]))
            {
                // we need to set the left pointer to the current i
                // and reset our currDict
                l = r + 1;
                currDict.Clear();
            }
            else
            {
                while(currDict[s2[r]] > checkDict[s2[r]])
                {
                    currDict[s2[l]]--;
                    l++;
                }
            }

            if(r - l + 1 == s1.Length) return true;
        }

        return false;
    }
}
