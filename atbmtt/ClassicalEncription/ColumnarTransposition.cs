using System.Text;

namespace Atbmtt.ClassicalEncription;

public class ColumnarTransposition
{
    public static string Encrypt(string plainText, string key)
    {
        Dictionary<int, int> orderMap = ParseKey(key);
        int column = key.Length;

        string removedSpace = plainText.Replace(" ", "");

        int row = (int)Math.Ceiling((double)removedSpace.Length / column);
        char[,] matrix = new char[row, column];

        int index = 0;
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < column; j++)
            {
                if (index < removedSpace.Length)
                {
                    matrix[i, j] = removedSpace[index++];
                }
                else
                {
                    int lastIndex = row * column - 1;
                    int current = column * i + j;
                    int offset = lastIndex - current;
                    matrix[i, j] = (char)(
                        (removedSpace[index - 1] is >= 'a' and <= 'z') ? 'z' - offset : 'Z' - offset
                    );
                }
            }
        }

        StringBuilder result = new();

        for (int col = 1; col <= column; col++)
        {
            int currentCol = orderMap[col];
            for (int i = 0; i < row; i++)
            {
                result.Append(matrix[i, currentCol]);
            }
        }

        return result.ToString();
    }

    public static string Decrypt(string cipherText, string key)
    {
        Dictionary<int, int> orderMap = ParseKey(key);
        int columns = key.Length;

        string removedSpace = cipherText.Replace(" ", "");

        if (removedSpace.Length % columns != 0)
        {
            throw new ArgumentException("Ciphertext length must be divisible by key length.");
        }

        int rows = (int)Math.Ceiling((double)removedSpace.Length / columns);

        char[,] matrix = new char[rows, columns];

        int index = 0;

        for (int col = 1; col <= columns; col++)
        {
            int currentOrder = orderMap[col];

            for (int row = 0; row < rows; row++)
            {
                matrix[row, currentOrder] = removedSpace[index++];
            }
        }

        StringBuilder result = new();

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                result.Append(matrix[row, col]);
            }
        }

        return result.ToString();

    }

    public static Dictionary<int, int> ParseKey(string key)
    {
        HashSet<int> set = new();
        int max = 0;

        foreach (char c in key)
        {
            if (!char.IsDigit(c))
            {
                throw new ArgumentException("Key must contain only numbers");
            }

            int num = c - '0';

            if (num < 1 || num > key.Length)
            {
                throw new ArgumentException("Key must contain numbers from 1 to key.Length");
            }

            set.Add(num);
            max = Math.Max(max, num);
        }

        if (set.Count != key.Length)
        {
            throw new ArgumentException("Key must not contain duplicate numbers");
        }

        if (max != key.Length)
        {
            throw new ArgumentException("Key must contain all numbers from 1 to key.Length");
        }

        Dictionary<int, int> result = new();

        for (int i = 0; i < key.Length; i++)
        {
            result.Add(set.ElementAt(i), i);
        }

        return result;
    }
}
