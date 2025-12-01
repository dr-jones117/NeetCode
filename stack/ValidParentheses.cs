using System.Diagnostics;

bool IsValid(string s)
{
    var pStack = new Stack<char>();
    var pDict = new Dictionary<char, char>
    {
        {'}', '{'},
        {']', '['},
        {')', '('},
    };

    foreach(var c in s)
    {
        if (pDict.ContainsKey(c))
        {
            if(pStack.Count() == 0) return false;

            var correctChar = pDict[c];
            var currOpen = pStack.Pop();

            if(currOpen != correctChar) return false;
        } 
        else
        {
            pStack.Push(c);
        }
    }

    return pStack.Count == 0;
}

Debug.Assert(IsValid("[]"));
Debug.Assert(IsValid("([{}])"));
Debug.Assert(!IsValid("[(])"));
