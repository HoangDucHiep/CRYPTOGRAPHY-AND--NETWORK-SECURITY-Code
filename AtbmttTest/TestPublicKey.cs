using Atbmtt.PublicKeyCryptography;

namespace AtbmttTest;

[TestClass]
public sealed class TestDiffieHellman
{
    [TestMethod]
    public void TestDiffieHellman1()
    {
        long q = 11;
        long a = 2;

        long xA = 9;
        long xB = 3;
        long yA = DiffieHellman.GetPublicKey(xA, q, a);
        long yB = DiffieHellman.GetPublicKey(xB, q, a);

        long k = DiffieHellman.GetSharedKey(xA, yB, q);

        long expectedYA = 6;
        long expectedYB = 8;
        long expectedK = 7;

        Assert.AreEqual(expectedYA, yA, "yA is not correct.");
        Assert.AreEqual(expectedYB, yB, "yB is not correct.");
        Assert.AreEqual(expectedK, k, "k is not correct.");
    }

    [TestMethod]
    public void TestDiffieHellman2()
    {
        long q = 13;
        long a = 6;

        long xA = 5;
        long xB = 7;
        long yA = DiffieHellman.GetPublicKey(xA, q, a);
        long yB = DiffieHellman.GetPublicKey(xB, q, a);

        long k = DiffieHellman.GetSharedKey(xA, yB, q);

        long expectedYA = 2;
        long expectedYB = 7;
        long expectedK = 11;

        Assert.AreEqual(expectedYA, yA, "yA is not correct.");
        Assert.AreEqual(expectedYB, yB, "yB is not correct.");
        Assert.AreEqual(expectedK, k, "k is not correct.");
    }

    [TestMethod]
    public void TestDiffieHellman3()
    {
        long q = 43;
        long a = 3;

        long xA = 13;
        long xB = 37;
        long yA = DiffieHellman.GetPublicKey(xA, q, a);
        long yB = DiffieHellman.GetPublicKey(xB, q, a);

        long k = DiffieHellman.GetSharedKey(xA, yB, q);

        long expectedYA = 12;
        long expectedYB = 20;
        long expectedK = 19;

        Assert.AreEqual(expectedYA, yA, "yA is not correct.");
        Assert.AreEqual(expectedYB, yB, "yB is not correct.");
        Assert.AreEqual(expectedK, k, "k is not correct.");
    }

    [TestMethod]
    public void TestDiffieHellman4()
    {
        long q = 17;
        long a = 10;

        long xA = 7;
        long xB = 5;
        long yA = DiffieHellman.GetPublicKey(xA, q, a);
        long yB = DiffieHellman.GetPublicKey(xB, q, a);

        long k = DiffieHellman.GetSharedKey(xA, yB, q);

        long expectedYA = 5;
        long expectedYB = 6;
        long expectedK = 14;

        Assert.AreEqual(expectedYA, yA, "yA is not correct.");
        Assert.AreEqual(expectedYB, yB, "yB is not correct.");
        Assert.AreEqual(expectedK, k, "k is not correct.");
    }

    [TestMethod]
    public void TestDiffieHellman5()
    {
        long q = 809;
        long a = 3;

        long xA = 343;
        long xB = 257;
        long yA = DiffieHellman.GetPublicKey(xA, q, a);
        long yB = DiffieHellman.GetPublicKey(xB, q, a);

        long k = DiffieHellman.GetSharedKey(xA, yB, q);

        long expectedYA = 626;
        long expectedYB = 253;
        long expectedK = 58;

        Assert.AreEqual(expectedYA, yA, "yA is not correct.");
        Assert.AreEqual(expectedYB, yB, "yB is not correct.");
        Assert.AreEqual(expectedK, k, "k is not correct.");
    }

    [TestMethod]
    public void TestDiffieHellman6()
    {
        long q = 23;
        long a = 10;

        long xA = 8;
        long xB = 12;
        long yA = DiffieHellman.GetPublicKey(xA, q, a);
        long yB = DiffieHellman.GetPublicKey(xB, q, a);

        long k = DiffieHellman.GetSharedKey(xA, yB, q);

        long expectedYA = 2;
        long expectedYB = 13;
        long expectedK = 2;

        Assert.AreEqual(expectedYA, yA, "yA is not correct.");
        Assert.AreEqual(expectedYB, yB, "yB is not correct.");
        Assert.AreEqual(expectedK, k, "k is not correct.");
    }
}