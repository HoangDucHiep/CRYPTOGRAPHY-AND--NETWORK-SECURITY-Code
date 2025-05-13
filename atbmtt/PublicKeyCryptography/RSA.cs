using Atbmtt.MyMath;

namespace Atbmtt.PublicKeyCryptography;

public class RSA
{
    public static (long e, long n) GetPublicKey(long p, long q, long e)
    {
        if (!ModulusMath.IsPrime(p) || !ModulusMath.IsPrime(q))
        {
            throw new ArgumentException("p and q must be prime numbers.");
        }

        long n = p * q;
        long phi = (p - 1) * (q - 1);

        if (ModulusMath.GCD(e, phi) != 1)
        {
            throw new ArgumentException("e must be coprime to (p-1)(q-1).");
        }

        return (e, n);
    }

    public static (long d, long n) GetPrivateKey(long p, long q, long e)
    {
        if (!ModulusMath.IsPrime(p) || !ModulusMath.IsPrime(q))
        {
            throw new ArgumentException("p and q must be prime numbers.");
        }

        long n = p * q;
        long phi = (p - 1) * (q - 1);

        if (ModulusMath.GCD(e, phi) != 1)
        {
            throw new ArgumentException("e must be coprime to (p-1)(q-1).");
        }

        long? inverse;
        (_, inverse) = ModulusMath.ExtendedEuclidean(e, phi);

        if (inverse == null)
        {
            throw new ArgumentException("e has no modular inverse with respect to phi.");
        }

        long d = (long)inverse;
        if (d < 0)
        {
            d += phi;
        }

        return (d, n);
    }

    public static long Encript(long M, (long a, long n) key)
    {
        if (M < 0 || M >= key.n)
        {
            throw new ArgumentException("M must be in the range [0, n).");
        }

        return ModulusMath.ModExp(M, key.a, key.n);
    }

    public static long Decrypt(long C, (long a, long n) key)
    {
        if (C < 0 || C >= key.n)
        {
            throw new ArgumentException("C must be in the range [0, n).");
        }

        return ModulusMath.ModExp(C, key.a, key.n);
    }
}