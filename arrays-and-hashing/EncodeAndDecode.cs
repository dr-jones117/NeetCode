using System.Diagnostics;

var sol = new Solution();
Debug.Assert(sol.Decode(sol.Encode(["neet", "code", "love", "you"])).SequenceEqual(["neet", "code", "love", "you"]));

public class Solution
{
    public string Encode(IList<string> strs)
    {
        var returnStr = string.Empty;
        foreach(var str in strs)
        {
            returnStr += str.Length + "#" + str;
        }
        return returnStr;
    }

    public List<string> Decode(string s)
    {
        var returnList = new List<string>();

        while(s.Length > 0)
        {
            var hashIdx = s.IndexOf('#');
            if(int.TryParse(s.Substring(0, hashIdx), out int num))
            {
                returnList.Add(s.Substring(hashIdx + 1, num));
                s = s.Substring(hashIdx + num + 1);
            }
            else
            {
                return returnList;
            }
        }

        return returnList;
    }
}
