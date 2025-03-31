namespace Atbmtt.MyMath;

public class Math
{
    public static int Mod(int a, int b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException("Modulus by zero.");
        }

        return (a % b + b) % b;
    }

    public static bool isPermutation<T>(IList<T> a, IList<T> b)
    {
        if (ReferenceEquals(a, b))
        {
            return true;
        }

        if (a == null || b == null || a.Count != b.Count)
        {
            return false;
        }

        Dictionary<T, int> elementCounts = new();

        foreach (T element in a)
        {
            if (elementCounts.ContainsKey(element))
            {
                elementCounts[element]++;
            }
            else
            {
                elementCounts[element] = 1;
            }
        }

        foreach (T element in b)
        {
            if (!elementCounts.ContainsKey(element))
            {
                return false;
            }

            elementCounts[element]--;

            if (elementCounts[element] < 0)
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Calculates the modular exponentiation of a number.
    /// This method computes (a^m) mod n using the method of exponentiation by squaring.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="m"></param>
    /// <param name="n"></param>
    /// <returns></returns>
    public static int ModExp(int a, int m, int n)
    {
        if (n == 0)
        {
            throw new DivideByZeroException("Modulus by zero.");
        }

        if (m < 0)
        {
            throw new ArgumentException("Exponent must be non-negative.");
        }

        if (a < 0 || n < 0)
        {
            throw new ArgumentException("Base and modulus must be non-negative.");
        }

        if (n == 1 || a == 0)
        {
            return 0;
        }

        if (m == 0)
        {
            return 1;
        }




        a = Mod(a, n); // reduce a modulo n

        int result = 1;

        int baseValue = a;

        int exponent = m;

        int tableSize = (int)System.Math.Ceiling(System.Math.Log2(m));
        int[] mulTable = new int[tableSize + 1];

        mulTable[0] = baseValue;

        for (int i = 1; i < tableSize; i++)
        {
            mulTable[i] = Mod(mulTable[i - 1] * mulTable[i - 1], n);
        }

        for (int i = tableSize - 1; i >= 0; i--)
        {
            if (exponent == 0)
            {
                break;
            }

            int power = Power(2, i);

            if (exponent >= power)
            {
                result = Mod(result * mulTable[i], n);
                exponent -= power;
            }
        }

        return result;
    }

    public static int Power(int baseNum, int exp)
    {
        if (exp < 0)
        {
            throw new ArgumentException("Exponent must be non-negative.");
        }

        int result = 1;

        for (int i = 0; i < exp; i++)
        {
            result *= baseNum;
        }

        return result;
    }
}
