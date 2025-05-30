using System.Text;
using Atbmtt.MyMath;
using Atbmtt.Utils;

namespace Atbmtt.ClassicalEncription;

public enum VigenereMode
{
    REPEAT_KEY,
    AUTOKEY,
}

public class ExtendedVinegereCipher
{
    private readonly string key;
    private readonly CustomAlphabet alphabet;

    public ExtendedVinegereCipher(string key, string alphabet = "abcdefghijklmnopqrstuvwxyz")
    {
        this.alphabet = new CustomAlphabet(alphabet);

        if (string.IsNullOrEmpty(key))
        {
            throw new ArgumentException("Key must not be empty.");
        }

        if (!IsValidKey(key))
        {
            throw new ArgumentException("Key must only contains letters in alphabet.");
        }

        this.key = key.ToLowerInvariant();
    }

    public string Encode(string plainText, VigenereMode mode = VigenereMode.REPEAT_KEY)
    {
        if (string.IsNullOrEmpty(plainText))
        {
            return "";
        }

        StringBuilder cipher = new StringBuilder();
        string processedKey = ProcessKey(plainText, mode);

        for (int i = 0; i < plainText.Length; i++)
        {
            char currentPlainChar = plainText[i];
            char currentKeyChar = processedKey[i];

            if (alphabet.IsLetter(currentPlainChar))
            {
                long currentPlainIndex = alphabet.GetIndex(currentPlainChar);
                long currentKeyIndex = alphabet.GetIndex(currentKeyChar);

                long encodedIndex = MyMath.ModulusMath.Mod(
                    currentPlainIndex + currentKeyIndex,
                    alphabet.AlphabetLength()
                );

                char encodedChar = alphabet.GetChar(encodedIndex);

                _ = cipher.Append(
                    alphabet.IsLowercase(currentPlainChar)
                        ? encodedChar
                        : alphabet.GetUpperInvariant(encodedChar)
                );
            }
            else
            {
                _ = cipher.Append(currentPlainChar);
            }
        }

        return cipher.ToString();
    }

    public string Decode(string cipherText, VigenereMode mode = VigenereMode.REPEAT_KEY)
    {
        if (string.IsNullOrEmpty(cipherText))
        {
            return "";
        }

        return mode == VigenereMode.REPEAT_KEY
            ? DecodeRepeatKey(cipherText)
            : DecodeAutoKey(cipherText);
    }

    private string DecodeRepeatKey(string cipherText)
    {
        StringBuilder plainText = new();

        string processedKey = ProcessKey(cipherText, VigenereMode.REPEAT_KEY);

        for (int i = 0; i < cipherText.Length; i++)
        {
            char currentCipherChar = cipherText[i];
            char currentKeyChar = processedKey[i];

            if (alphabet.IsLetter(currentCipherChar))
            {
                char decodedChar = DecodeChar(currentCipherChar, currentKeyChar);

                _ = plainText.Append(
                    alphabet.IsLowercase(currentCipherChar)
                        ? decodedChar
                        : alphabet.GetUpperInvariant(decodedChar)
                );
            }
            else
            {
                _ = plainText.Append(currentCipherChar);
            }
        }

        return plainText.ToString();
    }

    private string DecodeAutoKey(string cipherText)
    {
        StringBuilder plainText = new();

        int cIndex = 0;
        int cLength = cipherText.Length;

        while (cIndex < cLength)
        {
            string restoredKey = RestoreAutoKey(key + plainText.ToString(), cipherText);

            for (; cIndex < restoredKey.Length && cIndex < cLength; cIndex++)
            {
                char currentCipherChar = cipherText[cIndex];
                char currentKeyChar = restoredKey[cIndex];

                if (alphabet.IsLetter(currentCipherChar))
                {
                    char decodedChar = DecodeChar(currentCipherChar, currentKeyChar);

                    _ = plainText.Append(
                        alphabet.IsLowercase(currentCipherChar)
                            ? decodedChar
                            : alphabet.GetUpperInvariant(decodedChar)
                    );
                }
                else
                {
                    _ = plainText.Append(currentCipherChar);
                }
            }
        }

        return plainText.ToString();
    }

    private string RestoreAutoKey(string key, string cipherText)
    {
        StringBuilder result = new();
        int keyLength = key.Length;
        int cipherTextLength = cipherText.Length;

        int keyIndex = 0;
        int cipherIndex = 0;

        while (keyIndex < keyLength && cipherIndex < cipherTextLength)
        {
            if (alphabet.IsLetter(cipherText[cipherIndex]))
            {
                _ = result.Append(key[keyIndex]);
                do
                {
                    keyIndex++;
                } while (keyIndex < keyLength && !alphabet.IsLetter(key[keyIndex]));
            }
            else
            {
                _ = result.Append(cipherText[cipherIndex]);
            }

            cipherIndex++;
        }

        return result.ToString();
    }

    private char DecodeChar(char cipherChar, char keyChar)
    {
        long cipherIndex = alphabet.GetIndex(cipherChar);
        long keyIndex = alphabet.GetIndex(keyChar);

        long decodedIndex = MyMath.ModulusMath.Mod(
            cipherIndex - keyIndex,
            alphabet.AlphabetLength()
        );

        return alphabet.GetChar(decodedIndex);
    }

    private string ProcessKey(string plainText, VigenereMode mode = VigenereMode.REPEAT_KEY)
    {
        return mode == VigenereMode.REPEAT_KEY ? RepeatKey(plainText) : AutoKey(plainText);
    }

    private string RepeatKey(string plainText)
    {
        StringBuilder repeatedKey = new StringBuilder();
        int keyIndex = 0;

        foreach (char c in plainText)
        {
            if (alphabet.IsLetter(c))
            {
                _ = repeatedKey.Append(key[keyIndex]);
                keyIndex = (keyIndex + 1) % key.Length;
            }
            else
            {
                _ = repeatedKey.Append(c);
            }
        }

        return repeatedKey.ToString();
    }

    private string AutoKey(string plainText)
    {
        StringBuilder autoKey = new StringBuilder();

        int keyLength = key.Length;
        int plainTextLength = plainText.Length;

        int index = 0;
        int plainIndex = 0;

        while (index < keyLength)
        {
            if (alphabet.IsLetter(plainText[plainIndex]))
            {
                _ = autoKey.Append(key[index]);
                index++;
            }
            else
            {
                _ = autoKey.Append(plainText[plainIndex]);
            }

            plainIndex++;
        }

        index = 0;
        while (plainIndex < plainTextLength)
        {
            if (!alphabet.IsLetter(plainText[plainIndex]))
            {
                _ = autoKey.Append(plainText[plainIndex]);
            }
            else
            {
                autoKey.Append(plainText[index % plainTextLength]);
                do
                {
                    index++;
                } while (!alphabet.IsLetter(plainText[index % plainTextLength]));
            }

            plainIndex++;
        }

        return autoKey.ToString();
    }

    private bool IsValidKey(string key)
    {
        return key.All(c => alphabet.IsLetter(c));
    }
}
