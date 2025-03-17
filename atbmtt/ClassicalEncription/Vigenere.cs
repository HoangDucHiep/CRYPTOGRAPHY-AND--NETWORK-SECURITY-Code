using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Text;
using Atbmtt.Utils;

namespace Atbmtt.ClassicalEncription;

public enum VigenereMode
{
    REPEAT_KEY,
    AUTOKEY,
}

public class VigenereCipher
{
    public static string Encode(
        string plainText,
        string key,
        VigenereMode mode = VigenereMode.REPEAT_KEY
    )
    {
        if (!isValidKey(key))
        {
            throw new ArgumentException("Key must contain only letters.");
        }

        StringBuilder cipher = new StringBuilder();

        string processedKey = ProcessKey(key, plainText, mode);

        for (int i = 0; i < plainText.Length; i++)
        {
            char currentPlainChar = plainText[i];
            char currentKeyChar = processedKey[i];
            if (currentPlainChar.IsLetter())
            {
                char plainBaseChar = char.IsUpper(currentPlainChar) ? 'A' : 'a';
                char keyBaseChar = char.IsUpper(currentKeyChar) ? 'A' : 'a';
                char cipherChar = (char)(
                    (currentPlainChar - plainBaseChar + currentKeyChar - keyBaseChar) % 26
                    + plainBaseChar
                );
                cipher.Append(cipherChar);
            }
            else
            {
                cipher.Append(currentPlainChar);
            }
        }

        return cipher.ToString();
    }

    public static string Decode(
        string cipherText,
        string key,
        VigenereMode mode = VigenereMode.REPEAT_KEY
    )
    {
        return mode == VigenereMode.REPEAT_KEY
            ? RepeatDecode(cipherText, key)
            : AutoKeyDecode(cipherText, key);
    }

    private static string RepeatDecode(string cipherText, string key)
    {
        StringBuilder plain = new StringBuilder();

        string processedKey = ProcessKey(key, cipherText, VigenereMode.REPEAT_KEY);

        for (int i = 0; i < cipherText.Length; i++)
        {
            char currentCipherChar = cipherText[i];
            char currentKeyChar = processedKey[i];
            if (currentCipherChar.IsLetter())
            {
                char cipherBaseChar = char.IsUpper(currentCipherChar) ? 'A' : 'a';
                char keyBaseChar = char.IsUpper(currentKeyChar) ? 'A' : 'a';

                char decoded = (char)(
                    ((currentCipherChar - cipherBaseChar) - (currentKeyChar - keyBaseChar) + 26)
                        % 26
                    + cipherBaseChar
                );

                plain.Append(decoded);
            }
            else
            {
                plain.Append(currentCipherChar);
            }
        }

        return plain.ToString();
    }

    private static string AutoKeyDecode(string cipherText, string key)
    {
        StringBuilder plain = new StringBuilder();
        // StringBuilder temp = new StringBuilder();

        int cIndex = 0;
        int cipherLength = cipherText.Length;

        while (cIndex < cipherLength)
        {
            string restoredKey = autoKeyRetoreKey(key + plain.ToString(), cipherText);
            int restoredKeyLength = restoredKey.Length;

            for (; cIndex < restoredKeyLength; cIndex++)
            {
                char currentCipherChar = cipherText[cIndex];
                char currentKeyChar = restoredKey[cIndex];
                if (currentCipherChar.IsLetter())
                {
                    char cipherBaseChar = char.IsUpper(currentCipherChar) ? 'A' : 'a';
                    char keyBaseChar = char.IsUpper(currentKeyChar) ? 'A' : 'a';

                    char decoded = (char)(
                        ((currentCipherChar - cipherBaseChar) - (currentKeyChar - keyBaseChar) + 26)
                            % 26
                        + cipherBaseChar
                    );

                    plain.Append(decoded);
                }
                else
                {
                    plain.Append(currentCipherChar);
                }
            }
        }


        return plain.ToString();
    }

    public static string autoKeyRetoreKey(string key, string cipherText)
    {
        StringBuilder result = new();
        int keyLength = key.Length;
        int cipherLength = cipherText.Length;

        int i = 0;
        int j = 0;

        while (i < keyLength && j < cipherLength)
        {
            if (!cipherText[j].IsLetter())
            {
                result.Append(cipherText[j]);
            }
            else
            {
                result.Append(key[i]);
                do i++;
                while (i < keyLength && !key[i].IsLetter());
            }
            j++;
        }

        return result.ToString();
    }

    private static string ProcessKey(string key, string plainText, VigenereMode mode)
    {
        return mode == VigenereMode.REPEAT_KEY
            ? RepeatKey(key, plainText)
            : AutoKey(key, plainText);
    }

    private static string RepeatKey(string key, string plainText)
    {
        StringBuilder result = new StringBuilder();
        int keyLength = key.Length;
        int plainTextLength = plainText.Length;
        int i = 0,
            j = 0;

        while (i < plainTextLength)
        {
            if (plainText.Length > 0 && (plainText[i] == ' ' || !plainText[i].IsLetter()))
            {
                result.Append(plainText[i]);
                i++;
            }
            else
            {
                result.Append(key[j]);
                i++;
                j = (j + 1) % keyLength;
            }
        }
        return result.ToString();
    }

    private static string AutoKey(string key, string plainText)
    {
        StringBuilder result = new StringBuilder();
        int keyLength = key.Length;
        int plainTextLength = plainText.Length;

        int i = 0;
        int j = 0;

        while (i < keyLength)
        {
            if (plainText.Length > 0 && !plainText[j].IsLetter())
            {
                result.Append(' ');
            }
            else
            {
                result.Append(key[i]);
                i++;
            }
            j++;
        }

        i = 0;
        while (j < plainTextLength)
        {
            if (!plainText[j].IsLetter())
            {
                result.Append(plainText[j]);
            }
            else
            {
                result.Append(plainText[i % plainTextLength]);
                do i++;
                while (i < plainTextLength && !plainText[i].IsLetter());
            }
            j++;
        }

        return result.ToString();
    }

    private static bool isValidKey(string key)
    {
        foreach (char c in key)
        {
            if (!c.IsLetter())
            {
                return false;
            }
        }
        return true;
    }
}
