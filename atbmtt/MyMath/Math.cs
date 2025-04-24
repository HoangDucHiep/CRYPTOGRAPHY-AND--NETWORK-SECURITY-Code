namespace Atbmtt.MyMath;

public class Math
{
    public static int ModExpChineseRemainder(int baseValue, int exponent, int modulus)
    {
        int M = modulus;
        int[] msValue = PrimeFactorize(M).Select(f => Power(f.Key, f.Value)).ToArray();

        if (ArePairwiseRelativelyPrime(msValue) == false)
        {
            throw new ArgumentException(
                "Modulus must be a product of pairwise relatively prime numbers."
            );
        }

        int[] csValue = new int[msValue.Length];
        int[] asValue = new int[msValue.Length];
        int[] MsValue = new int[msValue.Length];

        for (int i = 0; i < msValue.Length; i++)
        {
            MsValue[i] = M / msValue[i];
            int gcd;
            int? inverse;
            (gcd, inverse) = ExtendedEuclidean(MsValue[i], msValue[i]);

            if (inverse == null)
            {
                throw new ArgumentException("Inverse does not exist");
            }

            csValue[i] = MsValue[i] * inverse.Value;
            asValue[i] = ModExp(baseValue, exponent, msValue[i]);
        }

        int result = 0;

        for (int i = 0; i < msValue.Length; i++)
        {
            result += Mod(asValue[i] * csValue[i], M);
        }

        return Mod(result, M);
    }

    public static int ChineseRemainderTheorem(int[] msValue, int[] asValue)
    {
        if (msValue.Length != asValue.Length)
        {
            throw new ArgumentException("msValue and asValue must have the same length");
        }

        if (ArePairwiseRelativelyPrime(msValue) == false)
        {
            throw new ArgumentException("Ms must be pairwise relatively prime.");
        }

        int M = 1;

        foreach (int m in msValue)
        {
            M *= m;
        }

        int[] csValue = new int[msValue.Length];
        int[] MsValue = new int[msValue.Length];

        for (int i = 0; i < msValue.Length; i++)
        {
            MsValue[i] = M / msValue[i];
            int gcd;
            int? inverse;
            (gcd, inverse) = ExtendedEuclidean(MsValue[i], msValue[i]);

            if (inverse == null)
            {
                throw new ArgumentException("Inverse does not exist, can't solve the equation.");
            }

            csValue[i] = MsValue[i] * inverse.Value;
        }

        int result = 0;

        for (int i = 0; i < msValue.Length; i++)
        {
            result += Mod(asValue[i] * csValue[i], M);
        }

        return Mod(result, M);
    }

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

        a = Mod(a, n);

        if (m == 1)
        {
            return a;
        }

        if (m >= n)
        {
            try
            {
                int? tryFermat = Math.Fermat(a, m, n);
                if (tryFermat != null)
                {
                    return tryFermat.Value;
                }
            }
            catch
            {
                // ignore
            }

            try
            {
                int? tryEuler = Math.Euler(a, m, n);
                if (tryEuler != null)
                {
                    return tryEuler.Value;
                }
            }
            catch
            {
                // ignore
            }
        }

        int result = 1;

        int baseValue = a;

        int exponent = m;

        int tableSize = (int)System.Math.Ceiling(System.Math.Log2(m) + 1);
        int[] mulTable = new int[tableSize];

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

    public static int GCD(int a, int b)
    {
        if (b == 0)
        {
            return a;
        }

        return GCD(b, a % b);
    }

    public static (int GDC, int? Inverse) ExtendedEuclidean(int val, int mod)
    {
        val = Mod(val, mod);

        int Q,
            A1,
            A2,
            B1,
            B2,
            T1,
            T2;

        A1 = 0;
        A2 = mod;
        B1 = 1;
        B2 = val;

        while (B2 != 0 && B2 != 1)
        {
            Q = A2 / B2;
            T1 = A1 - Q * B1;
            T2 = A2 - Q * B2;
            A1 = B1;
            A2 = B2;
            B1 = T1;
            B2 = T2;
        }

        if (B2 == 0)
        {
            return (A2, null);
        }

        if (B2 == 1)
        {
            while (B1 < 0)
            {
                B1 += mod;
            }

            return (B2, B1);
        }
        throw new Exception("Unexpected case in Extended Euclidean algorithm.");
    }

    public static bool IsRelativelyPrime(int a, int b)
    {
        return GCD(a, b) == 1;
    }

    public static int? Fermat(int baseValue, int exponent, int modulus)
    {
        if (IsPrime(modulus) == false)
        {
            throw new ArgumentException("Modulus must be a prime number.");
        }

        if (baseValue < 0 || modulus <= 0)
        {
            throw new ArgumentException(
                "Base and modulus must be non-negative, and modulus must be positive."
            );
        }

        if (exponent < 0)
        {
            throw new ArgumentException("Exponent must be non-negative.");
        }

        baseValue = Mod(baseValue, modulus); // reduce baseValue modulo modulus

        if (IsRelativelyPrime(baseValue, modulus))
        {
            int temp = Mod(exponent, modulus - 1);
            if (temp == 0)
            {
                return 1;
            }
            else if (temp == 1)
            {
                return Mod(baseValue, modulus);
            }
            else
            {
                return ModExp(baseValue, temp, modulus);
            }
        }
        else
        {
            if (exponent < modulus)
            {
                throw new ArgumentException(
                    "Fermat theorem is not applicable for the given parameters."
                );
            }
            int temp = Mod(exponent, modulus);

            if (temp == 0)
            {
                return Mod(baseValue, modulus);
            }
            else if (temp == 1)
            {
                return Mod(baseValue, modulus);
            }
            else
            {
                long part1 = ModExp(
                    baseValue,
                    (int)System.Math.Floor((double)exponent / modulus),
                    modulus
                );

                long part2 = ModExp(baseValue, temp, modulus);
                long result = Mod((int)(part1 * part2), modulus);
                return (int)result;
            }
        }
    }

    public static int? Euler(int baseValue, int exponent, int modulus)
    {
        if (baseValue < 0 || modulus <= 0)
        {
            throw new ArgumentException(
                "Base and modulus must be non-negative, and modulus must be positive."
            );
        }

        if (exponent < 0)
        {
            throw new ArgumentException("Exponent must be non-negative.");
        }

        baseValue = Mod(baseValue, modulus);

        int eulerTotient = EulerTotient(modulus);

        if (IsRelativelyPrime(baseValue, modulus))
        {
            if (exponent < eulerTotient)
            {
                throw new ArgumentException(
                    "Euler theorem is not applicable for the given parameters."
                );
            }
            int temp = Mod(exponent, eulerTotient);

            if (temp == 0)
            {
                return 1;
            }
            else if (temp == 1)
            {
                return Mod(baseValue, modulus);
            }
            else
            {
                return ModExp(baseValue, temp, modulus);
            }
        }
        else
        {
            if (exponent < eulerTotient + 1)
            {
                throw new ArgumentException(
                    "Euler theorem is not applicable for the given parameters."
                );
            }
            int temp = Mod(exponent, eulerTotient + 1);

            if (temp == 0)
            {
                return Mod(baseValue, modulus);
            }
            else
            {
                long part1 = ModExp(
                    baseValue,
                    (int)System.Math.Floor((double)exponent / (eulerTotient + 1)),
                    modulus
                );
                long part2 = ModExp(baseValue, temp, modulus);
                long result = Mod((int)(part1 * part2), modulus);
                return (int)result;
            }
        }
    }

    public static bool IsPrime(int number)
    {
        if (number <= 3)
        {
            return number > 1;
        }

        if (number % 2 == 0 || number % 3 == 0)
        {
            return false;
        }

        for (int i = 5; i * i <= number; i += 6)
        {
            if (number % i == 0 || number % (i + 2) == 0)
            {
                return false;
            }
        }
        return true;
    }

    public static int EulerTotient(int n)
    {
        if (n < 1)
        {
            throw new ArgumentException("n must be a positive integer.");
        }

        if (n == 1)
        {
            return 1;
        }

        if (IsPrime(n))
        {
            return n - 1;
        }

        int[] primes = EratosthenesSieve(n);

        Dictionary<int, int> primeFactors = PrimeFactorize(n);

        if (primeFactors.Count == 1 && IsPrime(primeFactors.Keys.First()))
        {
            int num = primeFactors.Keys.First();
            int exponent = primeFactors[num];
            return Power(num, exponent) - Power(num, exponent - 1);
        }

        bool IsPrimeFactors = true;

        foreach (int prime in primeFactors.Keys)
        {
            if (primeFactors[prime] > 1)
            {
                IsPrimeFactors = false;
                break;
            }
        }

        if (IsPrimeFactors)
        {
            int result = 1;
            foreach (int prime in primeFactors.Keys)
            {
                result *= prime - 1;
            }
            return result;
        }

        int res = 1;
        foreach (int key in primeFactors.Keys)
        {
            int num = Power(key, primeFactors[key]);
            res *= EulerTotient(num);
        }

        return res;
    }

    public static Dictionary<int, int> PrimeFactorize(int n)
    {
        if (n < 2)
            throw new ArgumentException("n must be greater than 1.");

        int limit = (int)System.Math.Floor(System.Math.Sqrt(n));
        int[] primes = EratosthenesSieve(limit);

        Dictionary<int, int> factors = new();
        int temp = n;

        foreach (int p in primes)
        {
            while (temp % p == 0)
            {
                if (factors.ContainsKey(p))
                    factors[p]++;
                else
                    factors[p] = 1;
                temp /= p;
            }
            if (temp == 1)
                break;
        }

        if (temp > 1)
        {
            factors[temp] = 1;
        }

        return factors;
    }

    public static bool ArePairwiseRelativelyPrime(int[] numbers)
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            for (int j = i + 1; j < numbers.Length; j++)
            {
                if (GCD(numbers[i], numbers[j]) != 1)
                {
                    return false;
                }
            }
        }
        return true;
    }

    public static int[] EratosthenesSieve(int n)
    {
        if (n < 2)
        {
            return Array.Empty<int>();
        }

        bool[] isPrime = new bool[n + 1];
        for (int i = 2; i <= n; i++)
        {
            isPrime[i] = true;
        }

        for (int i = 2; i * i <= n; i++)
        {
            if (isPrime[i])
            {
                for (int j = i * i; j <= n; j += i)
                {
                    isPrime[j] = false;
                }
            }
        }

        List<int> primes = new();
        for (int i = 2; i <= n; i++)
        {
            if (isPrime[i])
            {
                primes.Add(i);
            }
        }

        return primes.ToArray();
    }

    public static bool IsPrimitiveRoot(int a, int n)
    {
        if (a < 1 || n < 2)
        {
            return false;
        }

        if (IsRelativelyPrime(a, n) == false)
        {
            return false;
        }

        int phi = EulerTotient(n);
        int[] primeFactors = PrimeFactorize(phi).Keys.ToArray();
        List<int> allDividers = new List<int>(primeFactors);

        for (int i = 0; i < primeFactors.Length; i++)
        {
            allDividers.Add(phi / primeFactors[i]);
        }

        allDividers.Sort();
        allDividers = allDividers.Distinct().ToList();

        foreach (int d in allDividers)
        {
            if (ModExp(a, d, n) == 1)
            {
                return false;
            }
        }

        return true;
    }

    public static int DiscreteLogarithm(int baseVal, int elem, int mod)
    {
        if (baseVal < 1 || elem < 1 || mod < 2)
        {
            throw new ArgumentException("Base, element, and modulus must be positive integers.");
        }

        if (baseVal >= mod || elem >= mod)
        {
            throw new ArgumentException("Base and element must be less than modulus.");
        }

        if (!IsPrime(mod))
        {
            throw new ArgumentException("Modulus must be a prime number.");
        }

        int i = 1;
        do
        {
            if (ModExp(baseVal, i, mod) == elem)
            {
                return i;
            }
            i++;
        } while (i < mod - 1);

        throw new ArgumentException("No discrete logarithm found.");
    }

    public static int A1(int a, int b, int x, int y, int n)
    {
        int first = ModExp(a, x, n);
        int second = ModExp(b, y, n);

        return Mod(first + second, n);
    }

    public static int A2(int a, int b, int x, int y, int n)
    {
        int first = ModExp(a, x, n);
        int second = ModExp(b, y, n);

        return Mod(first - second, n);
    }

    public static int A3(int a, int b, int x, int y, int n)
    {
        int first = ModExp(a, x, n);
        int second = ModExp(b, y, n);

        return Mod(first * second, n);
    }

    public static int A4(int b, int y, int n)
    {
        int first = ModExp(b, y, n);

        int gcd;
        int? inverse;
        (gcd, inverse) = ExtendedEuclidean(first, n);
        if (inverse == null)
        {
            throw new ArgumentException("Inverse does not exist.");
        }

        return inverse.Value;
    }

    public static int A5(int a, int b, int x, int y, int n)
    {
        int first = ModExp(a, x, n);
        int second = A4(b, y, n);

        return Mod(first * second, n);
    }
}
