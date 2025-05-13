using Atbmtt.MyMath;

namespace Atbmtt.PublicKeyCryptography;

public class ElGamal
{
    public static (long q, long a, long Y) GetPublicKey(long q, long a, long x)
    {
        if (!ModulusMath.IsPrime(q))
        {
            throw new ArgumentException("q must be a prime number.");
        }

        if (!ModulusMath.IsPrimitiveRoot(a, q))
        {
            throw new ArgumentException("a must be a primitive root of q.");
        }

        if (a < 1 || a >= q)
        {
            throw new ArgumentException("a must be between 1 and q - 1.");
        }

        if (x < 1 || x > q - 1)
        {
            throw new ArgumentException("x must be between 1 and q - 1.");
        }


        long Y = ModulusMath.ModExp(a, x, q);

        return (q, a, Y);
    }

    public static (long C1, long C2) Encript(long M, long k, (long q, long a, long Y) key)
    {
        if (M < 0 || M > key.q - 1)
        {
            throw new ArgumentException("M must be between 0 and q - 1.");
        }

        if (!ModulusMath.IsPrime(key.q))
        {
            throw new ArgumentException("q must be a prime number.");
        }

        if (!ModulusMath.IsPrimitiveRoot(key.a, key.q))
        {
            throw new ArgumentException("a must be a primitive root of q.");
        }

        long K = ModulusMath.ModExp(key.Y, k, key.q);
        long C1 = ModulusMath.ModExp(key.a, k, key.q);
        long C2 = ModulusMath.Mod(M * K, key.q);

        return (C1, C2);
    }


    public static long Decrypt((long C1, long C2) cipher, long q, long xKey)
    {
        if (!ModulusMath.IsPrime(q))
        {
            throw new ArgumentException("q must be a prime number.");
        }

        if (cipher.C1 < 0 || cipher.C1 >= q)
        {
            throw new ArgumentException("C1 must be between 0 and q - 1.");
        }

        if (cipher.C2 < 0 || cipher.C2 >= q)
        {
            throw new ArgumentException("C2 must be between 0 and q - 1.");
        }

        long K = ModulusMath.ModExp(cipher.C1, xKey, q);
        long? KInverse;
        (_, KInverse) = ModulusMath.ExtendedEuclidean(K, q);
        if (KInverse == null)
        {
            throw new ArgumentException("K has no modular inverse with respect to q.");
        }

        long M = ModulusMath.Mod(cipher.C2 * (long)KInverse, q);
        return M;
    }
}