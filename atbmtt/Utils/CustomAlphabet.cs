using Atbmtt.MyMath;

namespace Atbmtt.Utils;

public class CustomAlphabet
{
    private readonly string alphabet;
    private readonly string uppercase;

    public CustomAlphabet(string alphabet = "abcdefghijklmnopqrstuvwxyz")
    {
        if (string.IsNullOrEmpty(alphabet))
        {
            throw new ArgumentException("Alphabet must not be empty.");
        }

        if (alphabet.Distinct().Count() != alphabet.Length)
        {
            throw new ArgumentException("Alphabet must not contains duplicate characters.");
        }

        this.alphabet = alphabet.ToLowerInvariant();
        uppercase = alphabet.ToUpperInvariant();
    }

    public int AlphabetLength() => alphabet.Length;

    public int GetIndex(char c) => alphabet.IndexOf(GetLowerInvariant(c));
    public char GetChar(int index) => alphabet[MyMath.Math.Mod(index, alphabet.Length)];

    public char GetUpperInvariant(char c) => char.ToUpperInvariant(c);

    public char GetLowerInvariant(char c) => char.ToLowerInvariant(c);

    public string GetAlphabet(bool uppercase = false) => uppercase ? this.uppercase : alphabet;

    public bool Contains(char c) => alphabet.Contains(char.ToLowerInvariant(c));

    public bool IsLowercase(char c) => alphabet.Contains(c);

    public bool IsUppercase(char c) => uppercase.Contains(c);

    public bool IsLetter(char c) => IsLowercase(c) || IsUppercase(c);

    // override object.Equals
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        CustomAlphabet other = (CustomAlphabet)obj;

        string sortedAlphabet = string.Concat(alphabet.OrderBy(c => c));
        string sortedOtherAlphabet = string.Concat(other.alphabet.OrderBy(c => c));
        
        return sortedAlphabet.Equals(sortedOtherAlphabet);
    }
    
    // override object.GetHashCode
    public override int GetHashCode()
    {
        return alphabet.GetHashCode();
    }
}
