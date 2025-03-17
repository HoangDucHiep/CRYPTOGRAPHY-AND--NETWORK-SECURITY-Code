using System.Text;
using Atbmtt.Utils;

namespace Atbmtt.ClassicalEncription;

/// <summary>
/// Specifies the mode of operation for the Vigenere cipher.
/// </summary>
public enum VigenereMode
{
    /// <summary>
    /// Uses the key repeatedly to encrypt/decrypt the entire message.
    /// </summary>
    REPEAT_KEY,

    /// <summary>
    /// Uses the key concatenated with the plaintext as the encryption key.
    /// </summary>
    AUTOKEY,
}

/// <summary>
/// Provides methods for encrypting and decrypting text using the Vigenere cipher.
/// </summary>
public class VigenereCipher
{
    /// <summary>
    /// Encrypts the plaintext using the Vigenere cipher.
    /// </summary>
    /// <param name="plainText">The text to encrypt.</param>
    /// <param name="key">The encryption key (must contain only letters).</param>
    /// <param name="mode">The cipher mode (REPEAT_KEY or AUTOKEY).</param>
    /// <returns>The encrypted text.</returns>
    /// <exception cref="ArgumentException">Thrown when the key contains non-letter characters.</exception>
    public static string Encode(
        string plainText,
        string key,
        VigenereMode mode = VigenereMode.REPEAT_KEY
    )
    {
        if (!IsValidKey(key))
        {
            throw new ArgumentException("Key must contain only letters.");
        }

        if (string.IsNullOrEmpty(plainText) || string.IsNullOrEmpty(key))
        {
            return plainText;
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

    /// <summary>
    /// Decrypts the ciphertext using the Vigenere cipher.
    /// </summary>
    /// <param name="cipherText">The text to decrypt.</param>
    /// <param name="key">The decryption key (must contain only letters).</param>
    /// <param name="mode">The cipher mode (REPEAT_KEY or AUTOKEY).</param>
    /// <returns>The decrypted text.</returns>
    /// <exception cref="ArgumentException">Thrown when the key contains non-letter characters.</exception>
    public static string Decode(
        string cipherText,
        string key,
        VigenereMode mode = VigenereMode.REPEAT_KEY
    )
    {
        if (!IsValidKey(key))
        {
            throw new ArgumentException("Key must contain only letters.");
        }

        if (string.IsNullOrEmpty(cipherText) || string.IsNullOrEmpty(key))
        {
            return cipherText;
        }

        return mode == VigenereMode.REPEAT_KEY
            ? RepeatDecode(cipherText, key)
            : AutoKeyDecode(cipherText, key);
    }

    /// <summary>
    /// Generates the encryption key base on the mode.
    /// </summary>
    /// <param name="key"></param>
    /// <param name="plainText"></param>
    /// <param name="mode">The cipher mode (REPEAT_KEY or AUTOKEY).</param>
    /// <returns>Processed key</returns>
    private static string ProcessKey(string key, string plainText, VigenereMode mode)
    {
        return mode == VigenereMode.REPEAT_KEY
            ? RepeatKey(key, plainText)
            : AutoKey(key, plainText);
    }

    /// <summary>
    /// Repeats the key to match the length of the plaintext.
    /// </summary>
    /// <param name="key">The key to repeat.</param>
    /// <param name="plainText">The plaintext to match the length.</param>
    /// <returns>The repeated key.</returns>
    /// <remarks>
    /// This method skips non-letter characters in the plaintext.
    /// </remarks>
    private static string RepeatKey(string key, string plainText)
    {
        StringBuilder result = new StringBuilder();
        int keyLength = key.Length;
        int plainTextLength = plainText.Length;
        int i = 0,
            j = 0;

        while (i < plainTextLength)
        {
            if (plainText.Length > 0 && !plainText[i].IsLetter())
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

    /// <summary>
    /// Generates the key based on the plaintext.
    /// </summary>
    /// <param name="key">The key to start with.</param>
    /// <param name="plainText">The plaintext to generate the key.</param>
    /// <returns>The generated key.</returns>
    /// <remarks>
    /// This method skips non-letter characters in the plaintext.
    /// </remarks>
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

    /// <summary>
    /// Decrypts the ciphertext using the repeat key mode.
    /// </summary>
    /// <param name="cipherText">The text to decrypt.</param>
    /// <param name="key">The decryption key (must contain only letters).</param>
    /// <returns>The decrypted text.</returns>
    private static string RepeatDecode(string cipherText, string key)
    {
        StringBuilder plain = new StringBuilder();
        // cuz the key is just repeated, we can just use the ProcessKey method to make key
        string processedKey = ProcessKey(key, cipherText, VigenereMode.REPEAT_KEY);

        for (int i = 0; i < cipherText.Length; i++)
        {
            char currentCipherChar = cipherText[i];
            char currentKeyChar = processedKey[i];
            if (currentCipherChar.IsLetter())
            {
                plain.Append(DecodeChar(currentCipherChar, currentKeyChar));
            }
            else
            {
                plain.Append(currentCipherChar);
            }
        }

        return plain.ToString();
    }

    /// <summary>
    /// Decrypts the ciphertext using the auto key mode.
    /// </summary>
    /// <param name="cipherText">The text to decrypt.</param>
    /// <param name="key">The decryption key (must contain only letters).</param>
    /// <returns>The decrypted text.</returns>
    private static string AutoKeyDecode(string cipherText, string key)
    {
        StringBuilder plain = new StringBuilder();
        // StringBuilder temp = new StringBuilder();

        int cIndex = 0;
        int cipherLength = cipherText.Length;

        //now the processed key to decrypt the cipher text contain the key and the plain text
        // we need to restore the key and the plain text simultaneously
        while (cIndex < cipherLength)
        {
            string restoredKey = AutoKeyRetoreKey(key + plain.ToString(), cipherText);

            for (; cIndex < restoredKey.Length && cIndex < cipherText.Length; cIndex++)
            {
                char currentCipherChar = cipherText[cIndex];
                char currentKeyChar = restoredKey[cIndex];
                if (currentCipherChar.IsLetter())
                {
                    plain.Append(DecodeChar(currentCipherChar, currentKeyChar));
                }
                else
                {
                    plain.Append(currentCipherChar);
                }
            }
        }

        return plain.ToString();
    }

    /// <summary>
    /// Restores the key and the plain text from the cipher text.
    /// </summary>
    /// <param name="key">The key to restore.</param>
    /// <param name="cipherText">The cipher text to restore.</param>
    /// <returns>The restored key.</returns>
    private static string AutoKeyRetoreKey(string key, string cipherText)
    {
        StringBuilder result = new();
        int keyLength = key.Length;
        int cipherLength = cipherText.Length;

        int keyIndex = 0;
        int textIndex = 0;

        while (keyIndex < keyLength && textIndex < cipherLength)
        {
            if (!cipherText[textIndex].IsLetter())
            {
                result.Append(cipherText[textIndex]);
            }
            else
            {
                result.Append(key[keyIndex]);
                // skip non letter characters
                do keyIndex++;
                while (keyIndex < keyLength && !key[keyIndex].IsLetter());
            }
            textIndex++;
        }

        return result.ToString();
    }

    private static bool IsValidKey(string key)
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


    /// <summary>
    /// Decodes a character using the Vigenere cipher.
    /// </summary>
    /// <param name="cipherChar">The character to decode.</param>
    /// <param name="keyChar">The key character to use for decoding.</param>
    /// <returns>The decoded character.</returns>
    /// <remarks>
    /// decode(cipherChar, keyChar) = (cipherChar - keyChar) mod 26
    /// </remarks>
    private static char DecodeChar(char cipherChar, char keyChar)
    {
        if (cipherChar.IsLetter())
        {
            char cipherBaseChar = char.IsUpper(cipherChar) ? 'A' : 'a';
            char keyBaseChar = char.IsUpper(keyChar) ? 'A' : 'a';

            char decoded = (char)(
                ((cipherChar - cipherBaseChar) - (keyChar - keyBaseChar) + 26) % 26 + cipherBaseChar
            );

            return decoded;
        }
        return cipherChar;
    }
}
