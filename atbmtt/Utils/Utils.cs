namespace Atbmtt.Utils;

public class Utils
{
    public static bool IsShuffled(string s1, string s2)
    {
        if (s1.Length != s2.Length)
        {
            return false;
        }

        var s1Chars = s1.ToCharArray();
        var s2Chars = s2.ToCharArray();

        Array.Sort(s1Chars);
        Array.Sort(s2Chars);

        for (var i = 0; i < s1Chars.Length; i++)
        {
            if (s1Chars[i] != s2Chars[i])
            {
                return false;
            }
        }

        return true;
    }
}
