using System.Security.Principal;
using System.Text;

namespace Atbmtt.ClassicalEncription;

public class Playfair
{
    private string key;
    public char[,] matrix { get; }
    public Dictionary<char, (int, int)> charToIndex { get; }


    public Playfair(string key)
    {
        this.key = key.ToUpper();
        this.matrix = new char[5, 5];
        this.charToIndex = new Dictionary<char, (int, int)>();
        this.GenerateMatrix();
    }

    public string Encrypt(string plainText)
    {
        string removedJ = plainText.ToUpper().Replace("J", "I");
        List<string> splittedText = this.SplitText(removedJ);

        StringBuilder result = new();

        foreach (string pair in splittedText)
        {
            (int, int) firstIndex = this.charToIndex[pair[0]];
            (int, int) secondIndex = this.charToIndex[pair[1]];

            if (firstIndex.Item1 == secondIndex.Item1)
            {
                result.Append(this.matrix[firstIndex.Item1, (firstIndex.Item2 + 1) % 5]);
                result.Append(this.matrix[secondIndex.Item1, (secondIndex.Item2 + 1) % 5]);
            }
            else if (firstIndex.Item2 == secondIndex.Item2)
            {
                result.Append(this.matrix[(firstIndex.Item1 + 1) % 5, firstIndex.Item2]);
                result.Append(this.matrix[(secondIndex.Item1 + 1) % 5, secondIndex.Item2]);
            }
            else
            {
                result.Append(this.matrix[firstIndex.Item1, secondIndex.Item2]);
                result.Append(this.matrix[secondIndex.Item1, firstIndex.Item2]);
            }
        }

        return result.ToString();
    }


    public string Decrypt(string cipherText)
    {
        string removedJ = cipherText.ToUpper().Replace("J", "I");
        List<string> splittedText = this.SplitText(removedJ);

        StringBuilder result = new();

        foreach (string pair in splittedText)
        {
            (int, int) firstIndex = this.charToIndex[pair[0]];
            (int, int) secondIndex = this.charToIndex[pair[1]];

            if (firstIndex.Item1 == secondIndex.Item1)
            {
                result.Append(this.matrix[firstIndex.Item1, (firstIndex.Item2 - 1) % 5]);
                result.Append(this.matrix[secondIndex.Item1, (secondIndex.Item2 - 1) % 5]);
            }
            else if (firstIndex.Item2 == secondIndex.Item2)
            {
                result.Append(this.matrix[(firstIndex.Item1 - 1) % 5, firstIndex.Item2]);
                result.Append(this.matrix[(secondIndex.Item1 - 1) % 5, secondIndex.Item2]);
            }
            else
            {
                result.Append(this.matrix[firstIndex.Item1, secondIndex.Item2]);
                result.Append(this.matrix[secondIndex.Item1, firstIndex.Item2]);
            }
        }

        return result.ToString();
    }

    public List<string> SplitText(string text)
    {
        List<string> result = new();
        int i = 0;
        while (i < text.Length)
        {
            if ((i + 1 < text.Length && text[i] == text[i + 1]) || i + 1 == text.Length)
            {
                result.Add(text[i] + "X");
                i++;
            }
            else
            {
                result.Add(text[i].ToString() + text[i + 1].ToString());
                i += 2;
            }
        }

        return result;
    }

    private void GenerateMatrix()
    {
        string alphabet = "ABCDEFGHIKLMNOPQRSTUVWXYZ";
        string key = this.key.ToUpper().Replace("J", "I"); // keep inly I
        string keyWithAlphabet = key + alphabet;

        HashSet<char> uniqueChars = new();
        foreach (char c in keyWithAlphabet)
        {
            if (!uniqueChars.Contains(c))
            {
                uniqueChars.Add(c);
            }
        }

        int i = 0;
        int j = 0;
        foreach (char c in uniqueChars)
        {
            this.matrix[i, j] = c;
            this.charToIndex[c] = (i, j);
            j++;
            if (j == 5)
            {
                j = 0;
                i++;
            }
        }
    }
}
