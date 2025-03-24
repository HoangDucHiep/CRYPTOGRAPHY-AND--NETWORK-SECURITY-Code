using System.Text;
using Atbmtt.Utils;
using Atbmtt.MyMath;

namespace Atbmtt.ClassicalEncription;

public class ExtendedCaesarCipher
{
    private readonly CustomAlphabet alphabet;

    public ExtendedCaesarCipher(string alphabet = "abcdefghijklmnopqrstuvwxyz")
    {
        this.alphabet = new CustomAlphabet(alphabet);
    }

    public string Encode(byte key, string plainText)
    {
        StringBuilder cipher = new StringBuilder();

        foreach (char c in plainText)
        {
            if (alphabet.IsLetter(c))
            {
                var currentPlainIndex = alphabet.GetIndex(c);
                var encodedIndex = MyMath.Math.Mod(
                    currentPlainIndex + key,
                    alphabet.AlphabetLength()
                );
                var encodedChar = alphabet.GetChar(encodedIndex);

                _ = cipher.Append(
                    alphabet.IsLowercase(c) ? encodedChar : alphabet.GetUpperInvariant(encodedChar)
                );
            }
            else
            {
                _ = cipher.Append(c);
            }
        }

        return cipher.ToString();
    }

    public string Decode(byte key, string plainText)
    {
        StringBuilder cipher = new StringBuilder();

        foreach (char c in plainText)
        {
            if (alphabet.IsLetter(c))
            {
                var currentCipherIndex = alphabet.GetIndex(c);
                var encodedIndex = MyMath.Math.Mod(
                    currentCipherIndex - key,
                    alphabet.AlphabetLength()
                );
                var decodedChar = alphabet.GetChar(encodedIndex);

                _ = cipher.Append(
                    alphabet.IsLowercase(c) ? decodedChar : alphabet.GetUpperInvariant(decodedChar)
                );
            }
            else
            {
                _ = cipher.Append(c);
            }
        }

        return cipher.ToString();
    }
}
