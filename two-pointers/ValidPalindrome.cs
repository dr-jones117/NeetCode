using System.Diagnostics;

bool IsPalindrome(string s)
{
    var beginPtr = 0;
    var lastPtr = s.Length - 1;

    while(beginPtr < lastPtr)
    {
        while(!char.IsLetterOrDigit(s[beginPtr]))
        {
            beginPtr++;
            if(beginPtr > s.Length - 1) return true;
        }
        while(!char.IsLetterOrDigit(s[lastPtr]))
        {
            lastPtr--;
            if(lastPtr < 0) return true;
        }

        if(char.ToLower(s[beginPtr]) != char.ToLower(s[lastPtr]))
        {
            return false;
        }
        beginPtr++;
        lastPtr--;
    }

    return true;
}

Debug.Assert(IsPalindrome("Was it a car or a cat I saw?"));
Debug.Assert(!IsPalindrome("tab a cat"));
Debug.Assert(IsPalindrome(".,"));