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
}
