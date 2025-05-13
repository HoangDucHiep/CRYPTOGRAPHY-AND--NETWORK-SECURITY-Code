using Atbmtt.MyMath;

namespace Atbmtt.DigitalSignature;

public class DSA
{
    public static (long g, long y) GetPublicKey(long p, long q, long h, long x)
    {
        if (!ModulusMath.IsPrime(p))
        {
            throw new ArgumentException("p must be a prime number.");
        }

        if (ModulusMath.Mod(p - 1, q) != 0 || !ModulusMath.IsPrime(q))
        {
            throw new ArgumentException("p must be a multiple of q and q must be prime.");
        }

        if (h < 1 || h > p - 1)
        {
            throw new ArgumentException("h must be between 1 and p - 1.");
        }

        if (x < 1 || x > q - 1)
        {
            throw new ArgumentException("x must be between 1 and q - 1.");
        }

        long g = ModulusMath.ModExp(h, (p - 1) / q, p);

        long y = ModulusMath.ModExp(g, x, p);

        return (g, y);
    }

    public static (long r, long s) Sign(long p, long q, long x, long g, long k, long H)
    {
        if (!ModulusMath.IsPrime(p))
        {
            throw new ArgumentException("p must be a prime number.");
        }

        if (ModulusMath.Mod(p - 1, q) != 0 || !ModulusMath.IsPrime(q))
        {
            throw new ArgumentException("p must be a multiple of q and q must be prime.");
        }

        if (k < 1 || k > q - 1)
        {
            throw new ArgumentException("k must be between 1 and q - 1.");
        }

        if (H < 0 || H >= q)
        {
            throw new ArgumentException("H must be between 0 and q - 1.");
        }

        if (x < 1 || x > q - 1)
        {
            throw new ArgumentException("x must be between 1 and q - 1.");
        }

        long r = ModulusMath.Mod(ModulusMath.ModExp(g, k, p), q);
        long? kIInverse;
        (_, kIInverse) = ModulusMath.ExtendedEuclidean(k, q);

        if (kIInverse == null)
        {
            throw new ArgumentException("k has no modular inverse with respect to q.");
        }

        long s = ModulusMath.Mod((long)(kIInverse * (H + x * r)), q);
        return (r, s);
    }

    public static bool Verify(long p, long q, long g, long y, long H, (long r, long s) signature)
    {
        if (!ModulusMath.IsPrime(p))
        {
            throw new ArgumentException("p must be a prime number.");
        }

        if (ModulusMath.Mod(p - 1, q) != 0 || !ModulusMath.IsPrime(q))
        {
            throw new ArgumentException("p must be a multiple of q and q must be prime.");
        }

        if (signature.r < 1 || signature.r > q - 1)
        {
            throw new ArgumentException("r must be between 1 and q - 1.");
        }

        if (signature.s < 1 || signature.s > q - 1)
        {
            throw new ArgumentException("s must be between 1 and q - 1.");
        }

        if (H < 0 || H >= q)
        {
            throw new ArgumentException("H must be between 0 and q - 1.");
        }

        long? sInverse;
        (_, sInverse) = ModulusMath.ExtendedEuclidean(signature.s, q);
        if (sInverse == null)
        {
            throw new ArgumentException("s has no modular inverse with respect to q.");
        }

        long w = (long)sInverse;
        long u1 = ModulusMath.Mod((long)(H * w), q);
        long u2 = ModulusMath.Mod((long)(signature.r * w), q);
        long v = ModulusMath.Mod(ModulusMath.ModExp(g, u1, p) * ModulusMath.ModExp(y, u2, p), p);
        v = ModulusMath.Mod(v, q);

        return v == signature.r;
    }
}
