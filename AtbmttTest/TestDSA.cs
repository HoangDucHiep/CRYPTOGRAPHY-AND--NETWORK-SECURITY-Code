using Atbmtt.PublicKeyCryptography;

namespace AtbmttTest;

[TestClass]
public sealed class TestDSA
{
    [TestMethod]
    public void TestDSA1()
    {
        long p = 23;
        long q = 11;
        long h = 6;
        long xA = 8;
        long k = 9;
        long H = 10;

        (long g, long y) expectedPU = (13, 2);
        (long r, long s) expectedS = (3, 5);

        (long g, long y) actualPU = Atbmtt.DigitalSignature.DSA.GetPublicKey(p, q, h, xA);
        (long r, long s) actualS = Atbmtt.DigitalSignature.DSA.Sign(p, q, xA, actualPU.g, k, H);

        Assert.AreEqual(expectedPU.g, actualPU.g);
        Assert.AreEqual(expectedPU.y, actualPU.y);
        Assert.AreEqual(expectedS.r, actualS.r);
        Assert.AreEqual(expectedS.s, actualS.s);
        Assert.IsTrue(Atbmtt.DigitalSignature.DSA.Verify(p, q, actualPU.g, actualPU.y, H, actualS));
    }

    [TestMethod]
    public void TestDSA2()
    {
        long p = 47;
        long q = 23;
        long h = 7;
        long xA = 13;
        long k = 5;
        long H = 11;

        (long g, long y) expectedPU = (2, 14);
        (long r, long s) expectedS = (9, 21);

        (long g, long y) actualPU = Atbmtt.DigitalSignature.DSA.GetPublicKey(p, q, h, xA);
        (long r, long s) actualS = Atbmtt.DigitalSignature.DSA.Sign(p, q, xA, actualPU.g, k, H);

        Assert.AreEqual(expectedPU.g, actualPU.g);
        Assert.AreEqual(expectedPU.y, actualPU.y);
        Assert.AreEqual(expectedS.r, actualS.r);
        Assert.AreEqual(expectedS.s, actualS.s);
        Assert.IsTrue(Atbmtt.DigitalSignature.DSA.Verify(p, q, actualPU.g, actualPU.y, H, actualS));
    }

    [TestMethod]
    public void TestDSA3()
    {
        long p = 139;
        long q = 23;
        long h = 12;
        long xA = 14;
        long k = 8;
        long H = 18;

        (long g, long y) expectedPU = (125, 55);
        (long r, long s) expectedS = (17, 9);

        (long g, long y) actualPU = Atbmtt.DigitalSignature.DSA.GetPublicKey(p, q, h, xA);
        (long r, long s) actualS = Atbmtt.DigitalSignature.DSA.Sign(p, q, xA, actualPU.g, k, H);

        Assert.AreEqual(expectedPU.g, actualPU.g);
        Assert.AreEqual(expectedPU.y, actualPU.y);
        Assert.AreEqual(expectedS.r, actualS.r);
        Assert.AreEqual(expectedS.s, actualS.s);
        Assert.IsTrue(Atbmtt.DigitalSignature.DSA.Verify(p, q, actualPU.g, actualPU.y, H, actualS));
    }

    [TestMethod]
    public void TestDSA4()
    {
        long p = 607;
        long q = 101;
        long h = 11;
        long xA = 19;
        long k = 8;
        long H = 14;

        (long g, long y) expectedPU = (335, 369);
        (long r, long s) expectedS = (14, 35);

        (long g, long y) actualPU = Atbmtt.DigitalSignature.DSA.GetPublicKey(p, q, h, xA);
        (long r, long s) actualS = Atbmtt.DigitalSignature.DSA.Sign(p, q, xA, actualPU.g, k, H);

        Assert.AreEqual(expectedPU.g, actualPU.g);
        Assert.AreEqual(expectedPU.y, actualPU.y);
        Assert.AreEqual(expectedS.r, actualS.r);
        Assert.AreEqual(expectedS.s, actualS.s);
        Assert.IsTrue(Atbmtt.DigitalSignature.DSA.Verify(p, q, actualPU.g, actualPU.y, H, actualS));
    }

    [TestMethod]
    public void TestDSA5()
    {
        long p = 809;
        long q = 101;
        long h = 20;
        long xA = 16;
        long k = 24;
        long H = 31;

        (long g, long y) expectedPU = (764, 739);
        (long r, long s) expectedS = (98, 54);

        (long g, long y) actualPU = Atbmtt.DigitalSignature.DSA.GetPublicKey(p, q, h, xA);
        (long r, long s) actualS = Atbmtt.DigitalSignature.DSA.Sign(p, q, xA, actualPU.g, k, H);

        Assert.AreEqual(expectedPU.g, actualPU.g);
        Assert.AreEqual(expectedPU.y, actualPU.y);
        Assert.AreEqual(expectedS.r, actualS.r);
        Assert.AreEqual(expectedS.s, actualS.s);
        Assert.IsTrue(Atbmtt.DigitalSignature.DSA.Verify(p, q, actualPU.g, actualPU.y, H, actualS));
    }
}
