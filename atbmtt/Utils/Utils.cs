namespace Atbmtt.Utils;

public static class Utils
{
    public static string RemoveWhitespace(this string input)
    {
        return new string(input.Where(c => !Char.IsWhiteSpace(c)).ToArray());
    }
}
