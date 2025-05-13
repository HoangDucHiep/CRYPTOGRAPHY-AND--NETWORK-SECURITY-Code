using Atbmtt.MyMath;

namespace Atbmtt.PublicKeyCryptography;

public class DiffieHellman
{
    public static long GetPublicKey(long privateKey, long q, long a)
    {
        if (!MyMath.ModulusMath.IsPrime(q))
        {
            throw new ArgumentException("q must be prime.");
        }

        if (!MyMath.ModulusMath.IsPrimitiveRoot(a, q))
        {
            throw new ArgumentException("a must be a primitive root of q.");
        }

        if (a > q)
        {
            throw new ArgumentException("a must be less than q.");
        }

        return MyMath.ModulusMath.ModExp(a, privateKey, q);
    }

    public static long GetSharedKey(long privateKey, long publicKey, long q)
    {
        if (!MyMath.ModulusMath.IsPrime(q))
        {
            throw new ArgumentException("q must be prime.");
        }

        return MyMath.ModulusMath.ModExp(publicKey, privateKey, q);
    }
}