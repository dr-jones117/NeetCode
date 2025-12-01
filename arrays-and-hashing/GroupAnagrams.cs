using System.Diagnostics;

List<List<string>> GroupAnagrams(string[] strs)
{
    var anagramDict = new Dictionary<string, List<string>>();
    foreach(var str in strs)
    {
        var sortedStr = string.Concat(str.OrderBy(c => c));

        if(!anagramDict.ContainsKey(sortedStr))
        {
            anagramDict[sortedStr] = new List<string>();
        }

        anagramDict[sortedStr].Add(str);
    }

    var groupedAnagrams = new List<List<string>>();

    // generate the list here
    foreach(var kvp in anagramDict)
    {
        groupedAnagrams.Add(kvp.Value);
    }

    return groupedAnagrams;
}
