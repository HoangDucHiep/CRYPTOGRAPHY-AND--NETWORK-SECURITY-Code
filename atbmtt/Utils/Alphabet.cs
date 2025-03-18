namespace Atbmtt.Utils;

public class Alphabet
{
    public string Lowercase { get; }
    public string Uppercase { get; }

    public Alphabet(string Lowercase, string? Uppercase = null)
    {
        if (Lowercase.Length != Lowercase.Distinct().Count())
        {
            throw new ArgumentException("Lowercase alphabet must not contain duplicate characters");
        }

        if (Uppercase != null && Uppercase.Length != Uppercase.Distinct().Count())
        {
            throw new ArgumentException("Uppercase alphabet must not contain duplicate characters");
        }

        if (Uppercase != null && Lowercase.Length != Uppercase.Length)
        {
            throw new ArgumentException(
                "Lowercase and Uppercase alphabets must have the same length"
            );
        }

        this.Lowercase = Lowercase;
        this.Uppercase = Uppercase ?? Lowercase;
    }

    public bool IsLower(char c)
    {
        return Lowercase.Contains(c);
    }

    public bool IsUpper(char c)
    {
        return Uppercase.Contains(c);
    }

    public char ToLower(char c)
    {
        if (IsUpper(c))
        {
            return Lowercase[Uppercase.IndexOf(c)];
        }

        return c;
    }

    public char ToUpper(char c)
    {
        if (IsLower(c))
        {
            return Uppercase[Lowercase.IndexOf(c)];
        }

        return c;
    }

    /// <summary>
    /// Check if a character is a letter for this alphabet
    /// </summary>
    /// <param name="c"></param>
    /// <returns>boolean</returns>
    /// <remarks>It is case-insensitive, even c is number or some character, if it is in this alphabet, we count it as a letter</remarks>
    public bool IsLetter(char c)
    {
        return IsLower(c) || IsUpper(c);
    }
}
