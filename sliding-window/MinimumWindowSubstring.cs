#:property PublishAot=false
using System.Diagnostics;

var sol = new Solution();
Debug.Assert(sol.MinWindow("OUZODYXAZV", "XYZ") == "YXAZ");
Debug.Assert(sol.MinWindow("s", "xy") == "");

public class Solution {
    public string MinWindow(string s, string t) {
        if(s.Length < t.Length) return string.Empty;

        var checkFreqs = new Dictionary<char, int>();
        for(int i = 0; i < t.Length; i++)
        {
            if(!checkFreqs.ContainsKey(t[i]))
                checkFreqs[t[i]] = 0;
            checkFreqs[t[i]]++;
        }


        var freqs = new Dictionary<char, int>();
        var countGoal = t.Length;
        var score = 0;
        var l = 0;
        var resStartIdx = 0;
        var resEndIdx = Int32.MaxValue;

        for(int i = 0; i < s.Length; i++)
        {
            if(!checkFreqs.ContainsKey(s[i])) 
                continue;

            if(!freqs.ContainsKey(s[i]))
                freqs[s[i]] = 0;
            freqs[s[i]]++;

            if(freqs[s[i]] <= checkFreqs[s[i]])
                score++;
            
            if(score == countGoal)
            {
                while(!checkFreqs.ContainsKey(s[l]))
                {
                    l++;
                }

                var amountToCheck = checkFreqs[s[l]];
                var futureAmount = freqs[s[l]] - 1;
                while(futureAmount >= amountToCheck)
                {
                    freqs[s[l]]--;
                    l++;

                    while(!checkFreqs.ContainsKey(s[l]))
                    {
                        l++;
                    }

                    amountToCheck = checkFreqs[s[l]];
                    futureAmount = freqs[s[l]] - 1;
                }

                if(i - l < resEndIdx - resStartIdx)
                {
                    resStartIdx = l;
                    resEndIdx = i;
                }
            }
        }

        if(resEndIdx == Int32.MaxValue) return string.Empty;
        return s.Substring(resStartIdx, resEndIdx - resStartIdx + 1);
    }
}
