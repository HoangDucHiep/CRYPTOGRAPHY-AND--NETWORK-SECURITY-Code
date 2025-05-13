namespace Atbmtt.MyMath;

public class ModulusMath
{
    public static long ModExpChineseRemainder(long baseValue, long exponent, long modulus)
    {
        long M = modulus;
        long[] msValue = PrimeFactorize(M).Select(f => Power(f.Key, f.Value)).ToArray();

        if (ArePairwiseRelativelyPrime(msValue) == false)
        {
            throw new ArgumentException(
                "Modulus must be a product of pairwise relatively prime numbers."
            );
        }

        long[] csValue = new long[msValue.Length];
        long[] asValue = new long[msValue.Length];
        long[] MsValue = new long[msValue.Length];

        for (long i = 0; i < msValue.Length; i++)
        {
            MsValue[i] = M / msValue[i];
            long gcd;
            long? inverse;
            (gcd, inverse) = ExtendedEuclidean(MsValue[i], msValue[i]);

            if (inverse == null)
            {
                throw new ArgumentException("Inverse does not exist");
            }

            csValue[i] = MsValue[i] * inverse.Value;
            asValue[i] = ModExp(baseValue, exponent, msValue[i]);
        }

        long result = 0;

        for (long i = 0; i < msValue.Length; i++)
        {
            result += Mod(asValue[i] * csValue[i], M);
        }

        return Mod(result, M);
    }

    public static long ChineseRemainderTheorem(long[] msValue, long[] asValue)
    {
        if (msValue.Length != asValue.Length)
        {
            throw new ArgumentException("msValue and asValue must have the same length");
        }

        if (ArePairwiseRelativelyPrime(msValue) == false)
        {
            throw new ArgumentException("Ms must be pairwise relatively prime.");
        }

        long M = 1;

        foreach (long m in msValue)
        {
            M *= m;
        }

        long[] csValue = new long[msValue.Length];
        long[] MsValue = new long[msValue.Length];

        for (long i = 0; i < msValue.Length; i++)
        {
            MsValue[i] = M / msValue[i];
            long gcd;
            long? inverse;
            (gcd, inverse) = ExtendedEuclidean(MsValue[i], msValue[i]);

            if (inverse == null)
            {
                throw new ArgumentException("Inverse does not exist, can't solve the equation.");
            }

            csValue[i] = MsValue[i] * inverse.Value;
        }

        long result = 0;

        for (long i = 0; i < msValue.Length; i++)
        {
            result += Mod(asValue[i] * csValue[i], M);
        }

        return Mod(result, M);
    }

    public static long Mod(long a, long b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException("Modulus by zero.");
        }

        return (a % b + b) % b;
    }

    public static bool isPermutation<T>(IList<T> a, IList<T> b)
        where T : notnull
    {
        if (ReferenceEquals(a, b))
        {
            return true;
        }

        if (a == null || b == null || a.Count != b.Count)
        {
            return false;
        }

        Dictionary<T, long> elementCounts = new();

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

    public static long ModExp(long a, long m, long n)
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

        /* if (m >= n)
        {
            try
            {
                long? tryFermat = ModulusMath.Ferma(a, m, n);
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
                long? tryEuler = ModulusMath.Euler(a, m, n);
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
        long[] msValue = PrimeFactorize(m).Select(f => Power(f.Key, f.Value)).ToArray();
        if (ArePairwiseRelativelyPrime(msValue))
        {
            try
            {
                long? tryCRT = ModulusMath.ModExpChineseRemainder(a, m, n);
                if (tryCRT != null)
                {
                    return tryCRT.Value;
                }
            }
            catch
            {
                // ignore
            }
        } */

        long result = 1;

        long baseValue = a;

        long exponent = m;

        long tableSize = (long)System.Math.Ceiling(System.Math.Log2(m) + 1);
        long[] mulTable = new long[tableSize];

        mulTable[0] = baseValue;

        for (long i = 1; i < tableSize; i++)
        {
            mulTable[i] = Mod(mulTable[i - 1] * mulTable[i - 1], n);
        }

        for (long i = tableSize - 1; i >= 0; i--)
        {
            if (exponent == 0)
            {
                break;
            }

            long power = Power(2, i);

            if (exponent >= power)
            {
                result = Mod(result * mulTable[i], n);
                exponent -= power;
            }
        }

        return result;
    }

    public static long Power(long baseNum, long exp)
    {
        if (exp < 0)
        {
            throw new ArgumentException("Exponent must be non-negative.");
        }

        long result = 1;

        for (long i = 0; i < exp; i++)
        {
            result *= baseNum;
        }

        return result;
    }

    public static long GCD(long a, long b)
    {
        if (b == 0)
        {
            return a;
        }

        return GCD(b, a % b);
    }

    public static (long GDC, long? Inverse) ExtendedEuclidean(long val, long mod)
    {
        val = Mod(val, mod);

        long Q,
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

    public static bool IsRelativelyPrime(long a, long b)
    {
        return GCD(a, b) == 1;
    }

    public static long? Ferma(long baseValue, long exponent, long modulus)
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

        baseValue = Mod(baseValue, modulus); 

        if (IsRelativelyPrime(baseValue, modulus))
        {
            long temp = Mod(exponent, modulus - 1);
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
            long temp = Mod(exponent, modulus);

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
                    (long)System.Math.Floor((double)exponent / modulus),
                    modulus
                );

                long part2 = ModExp(baseValue, temp, modulus);
                long result = Mod((long)(part1 * part2), modulus);
                return (long)result;
            }
        }
    }

    public static long? Euler(long baseValue, long exponent, long modulus)
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

        long eulerTotient = EulerTotient(modulus);

        if (IsRelativelyPrime(baseValue, modulus))
        {
            if (exponent < eulerTotient)
            {
                throw new ArgumentException(
                    "Euler theorem is not applicable for the given parameters."
                );
            }
            long temp = Mod(exponent, eulerTotient);

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
            long temp = Mod(exponent, eulerTotient + 1);

            if (temp == 0)
            {
                return Mod(baseValue, modulus);
            }
            else
            {
                long part1 = ModExp(
                    baseValue,
                    (long)System.Math.Floor((double)exponent / (eulerTotient + 1)),
                    modulus
                );
                long part2 = ModExp(baseValue, temp, modulus);
                long result = Mod((long)(part1 * part2), modulus);
                return (long)result;
            }
        }
    }

    public static bool IsPrime(long number)
    {
        if (number <= 3)
        {
            return number > 1;
        }

        if (number % 2 == 0 || number % 3 == 0)
        {
            return false;
        }

        for (long i = 5; i * i <= number; i += 6)
        {
            if (number % i == 0 || number % (i + 2) == 0)
            {
                return false;
            }
        }
        return true;
    }

    public static long EulerTotient(long n)
    {
        if (n < 1)
        {
            throw new ArgumentException("n must be a positive longeger.");
        }

        if (n == 1)
        {
            return 1;
        }

        if (IsPrime(n))
        {
            return n - 1;
        }

        long[] primes = EratosthenesSieve(n);

        Dictionary<long, long> primeFactors = PrimeFactorize(n);

        if (primeFactors.Count == 1 && IsPrime(primeFactors.Keys.First()))
        {
            long num = primeFactors.Keys.First();
            long exponent = primeFactors[num];
            return Power(num, exponent) - Power(num, exponent - 1);
        }

        bool IsPrimeFactors = true;

        foreach (long prime in primeFactors.Keys)
        {
            if (primeFactors[prime] > 1)
            {
                IsPrimeFactors = false;
                break;
            }
        }

        if (IsPrimeFactors)
        {
            long result = 1;
            foreach (long prime in primeFactors.Keys)
            {
                result *= prime - 1;
            }
            return result;
        }

        long res = 1;
        foreach (long key in primeFactors.Keys)
        {
            long num = Power(key, primeFactors[key]);
            res *= EulerTotient(num);
        }

        return res;
    }

    public static Dictionary<long, long> PrimeFactorize(long n)
    {
        if (n < 2)
            throw new ArgumentException("n must be greater than 1.");

        long limit = (long)System.Math.Floor(System.Math.Sqrt(n));
        long[] primes = EratosthenesSieve(limit);

        Dictionary<long, long> factors = new();
        long temp = n;

        foreach (long p in primes)
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

    public static bool ArePairwiseRelativelyPrime(long[] numbers)
    {
        for (long i = 0; i < numbers.Length; i++)
        {
            for (long j = i + 1; j < numbers.Length; j++)
            {
                if (GCD(numbers[i], numbers[j]) != 1)
                {
                    return false;
                }
            }
        }
        return true;
    }

    public static long[] EratosthenesSieve(long n)
    {
        if (n < 2)
        {
            return Array.Empty<long>();
        }

        bool[] isPrime = new bool[n + 1];
        for (long i = 2; i <= n; i++)
        {
            isPrime[i] = true;
        }

        for (long i = 2; i * i <= n; i++)
        {
            if (isPrime[i])
            {
                for (long j = i * i; j <= n; j += i)
                {
                    isPrime[j] = false;
                }
            }
        }

        List<long> primes = new();
        for (long i = 2; i <= n; i++)
        {
            if (isPrime[i])
            {
                primes.Add(i);
            }
        }

        return primes.ToArray();
    }

    public static bool IsPrimitiveRoot(long a, long n)
    {
        if (a < 1 || n < 2)
        {
            return false;
        }

        if (IsRelativelyPrime(a, n) == false)
        {
            return false;
        }

        long phi = EulerTotient(n);
        long[] primeFactors = PrimeFactorize(phi).Keys.ToArray();
        List<long> allDividers = new List<long>(primeFactors);

        for (long i = 0; i < primeFactors.Length; i++)
        {
            allDividers.Add(phi / primeFactors[i]);
        }

        allDividers.Sort();
        allDividers = allDividers.Distinct().ToList();

        foreach (long d in allDividers)
        {
            if (ModExp(a, d, n) == 1)
            {
                return false;
            }
        }

        return true;
    }

    public static long DiscreteLogarithm(long baseVal, long elem, long mod)
    {
        if (baseVal < 1 || elem < 1 || mod < 2)
        {
            throw new ArgumentException("Base, element, and modulus must be positive longegers.");
        }

        if (baseVal >= mod || elem >= mod)
        {
            throw new ArgumentException("Base and element must be less than modulus.");
        }

        if (!IsPrime(mod))
        {
            throw new ArgumentException("Modulus must be a prime number.");
        }

        long i = 1;
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

    public static long A1(long a, long b, long x, long y, long n)
    {
        long first = ModExp(a, x, n);
        long second = ModExp(b, y, n);

        return Mod(first + second, n);
    }

    public static long A2(long a, long b, long x, long y, long n)
    {
        long first = ModExp(a, x, n);
        long second = ModExp(b, y, n);

        return Mod(first - second, n);
    }

    public static long A3(long a, long b, long x, long y, long n)
    {
        long first = ModExp(a, x, n);
        long second = ModExp(b, y, n);

        return Mod(first * second, n);
    }

    public static long A4(long b, long y, long n)
    {
        long first = ModExp(b, y, n);

        long gcd;
        long? inverse;
        (gcd, inverse) = ExtendedEuclidean(first, n);
        if (inverse == null)
        {
            throw new ArgumentException("Inverse does not exist.");
        }

        return inverse.Value;
    }

    public static long A5(long a, long b, long x, long y, long n)
    {
        long first = ModExp(a, x, n);
        long second = A4(b, y, n);

        return Mod(first * second, n);
    }
}
