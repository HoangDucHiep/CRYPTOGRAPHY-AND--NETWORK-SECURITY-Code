using System;
using System.Collections.Generic;
using System.Linq;

namespace Atbmtt.Utils
{
    public class Alphabet
    {
        private readonly Dictionary<char, char> lowerToUpper;
        private readonly Dictionary<char, char> upperToLower;

        public Alphabet(string lowercase = "abcdefghijklmnopqrstuvwxyz", string? uppercase = null)
        {
            lowerToUpper = new Dictionary<char, char>();
            upperToLower = new Dictionary<char, char>();

            if (string.IsNullOrEmpty(lowercase))
            {
                throw new ArgumentException("Lowercase alphabet must not be empty.");
            }

            // can't contains duplicate characters
            if (lowercase.Distinct().Count() != lowercase.Length)
            {
                throw new ArgumentException(
                    "Lowercase alphabet must not contains duplicate characters."
                );
            }

            if (uppercase == null)
            {
                uppercase = new string(lowercase.Select(c => char.ToUpperInvariant(c)).ToArray());
            }

            // can't contains duplicate characters
            if (uppercase != null && uppercase.Distinct().Count() != uppercase.Length)
            {
                throw new ArgumentException(
                    "Uppercase alphabet must not contains duplicate characters."
                );
            }

            if (lowercase.Length != uppercase!.Length)
                throw new ArgumentException(
                    "Lowercase and Uppercase alphabets must have the same length."
                );

            for (int i = 0; i < lowercase.Length; i++)
            {
                lowerToUpper[lowercase[i]] = uppercase[i];
                upperToLower[uppercase[i]] = lowercase[i];
            }
        }

        public string GetAlphabet(bool uppercase = false) =>
            string.Join("", uppercase ? upperToLower.Keys : lowerToUpper.Keys);

        public bool IsLower(char c) => lowerToUpper.ContainsKey(c);

        public bool IsUpper(char c) => upperToLower.ContainsKey(c);

        public bool IsLetter(char c) => IsLower(c) || IsUpper(c);

        public char GetUpperChar(char c)
        {
            if (lowerToUpper.ContainsKey(c))
                return lowerToUpper[c];

            return char.ToUpperInvariant(c);
        }

        public char GetLowerChar(char c)
        {
            if (upperToLower.ContainsKey(c))
                return upperToLower[c];

            return char.ToLowerInvariant(c);
        }

        public string GetUpperString(string text)
        {
            return new string(text.Select(GetUpperChar).ToArray());
        }

        public string GetLowerString(string text)
        {
            return new string(text.Select(GetLowerChar).ToArray());
        }
    }
}
