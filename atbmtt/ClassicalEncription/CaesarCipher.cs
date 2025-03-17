using System.Text;
using Atbmtt.Utils;

namespace Atbmtt.ClassicalEncription;

public class CaesarCipher
{
    public static string Encode(string plainText, byte key = 3)
    {
        StringBuilder cipher = new StringBuilder();

        foreach (char c in plainText)
        {
            if (c.IsLetter())
            {
                var offset = c.IsUpperCase() ? 'A' : 'a';
                var encoded = (char)((c + key - offset) % 26 + offset);

                cipher.Append(encoded);
            }
            else
            {
                cipher.Append(c);
            }
        }

        return cipher.ToString();
    }

    public static string Decode(string cipherText, byte key = 3)
    {
        StringBuilder plain = new StringBuilder();

        foreach (char c in cipherText)
        {
            if (c.IsLetter())
            {
                var offset = c.IsUpperCase() ? 'A' : 'a';
                var decoded = (char)(((c - key - offset + 26) % 26) + offset);
                plain.Append(decoded);
            }
            else
            {
                plain.Append(c);
            }
        }

        return plain.ToString();
    }
}
