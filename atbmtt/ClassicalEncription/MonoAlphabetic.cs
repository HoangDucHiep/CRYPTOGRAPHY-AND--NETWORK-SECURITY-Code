using System.Text;
using Atbmtt.MyMath;
using Atbmtt.Utils;

namespace Atbmtt.ClassicalEncription;

public class MonoAlphabetic
{
    private readonly CustomAlphabet alphabet;
    private readonly CustomAlphabet cipherAlphabet;

    public MonoAlphabetic(string alphabet, string cipherAlphabet)
    {
        if (string.IsNullOrEmpty(alphabet))
        {
            throw new ArgumentException("Alphabet must not be empty.");
        }

        if (string.IsNullOrEmpty(cipherAlphabet))
        {
            throw new ArgumentException("Cipher alphabet must not be empty.");
        }

        if (!MyMath.ModulusMath.isPermutation([.. alphabet], [.. cipherAlphabet]))
        {
            throw new ArgumentException("Alphabet and cipher alphabet must be permutation of each other.");
        }

        this.alphabet = new(alphabet);
        this.cipherAlphabet = new(cipherAlphabet);
    }

    public string Encrypt(string plainText)
    {
        StringBuilder cipherText = new();

        foreach (char c in plainText)
        {
            if (alphabet.IsLetter(c))
            {
                char cipherChar = cipherAlphabet.GetChar(alphabet.GetIndex(c));
                if (alphabet.IsUppercase(c))
                {
                    cipherText.Append(cipherAlphabet.GetUpperInvariant(cipherChar));
                }
                else
                {
                    cipherText.Append(cipherChar);
                }
            }
            else
            {
                cipherText.Append(c);
            }
        }

        return cipherText.ToString();
    }

    public string Decrypt(string cipherText)
    {
        StringBuilder plainText = new();

        foreach (char c in cipherText)
        {
            if (cipherAlphabet.IsLetter(c))
            {
                char plainChar = alphabet.GetChar(cipherAlphabet.GetIndex(c));
                if (cipherAlphabet.IsUppercase(c))
                {
                    plainText.Append(alphabet.GetUpperInvariant(plainChar));
                }
                else
                {
                    plainText.Append(plainChar);
                }
            }
            else
            {
                plainText.Append(c);
            }
        }

        return plainText.ToString();
    }
}
