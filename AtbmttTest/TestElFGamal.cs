using Atbmtt.PublicKeyCryptography;

namespace AtbmttTest;

[TestClass]
public sealed class TestElGamal
{

    [TestMethod]
    public void TestElGamal1()
    {
        long q = 809;
        long a = 3;
        long xA = 57;
        long xB = 65;
        long M = 270;
        long k = 150;

        (long, long, long) expectedPUa = (809, 3, 31);
        (long, long, long) expectedPUb = (809, 3, 332);

        (long, long) expectedC = (665, 477);

        (long, long, long) actualPUa = ElGamal.GetPublicKey(q, a, xA);
        (long, long, long) actualPUb = ElGamal.GetPublicKey(q, a, xB);

        (long, long) actualC = ElGamal.Encript(M, k, actualPUa);
        long decryptC = ElGamal.Decrypt(actualC, q, xA);

        Assert.AreEqual(M, decryptC, "Decrypted message should match the original message.");
        Assert.AreEqual(expectedPUa, actualPUa, "Public key A is not correct.");
        Assert.AreEqual(expectedPUb, actualPUb, "Public key B is not correct.");
        Assert.AreEqual(expectedC, actualC, "Ciphertext is not correct.");
        Assert.AreEqual(M, decryptC, "Decrypted value is not correct.");
    }

    [TestMethod]
    public void TestElGamal2()
    {
        long q = 809;
        long a = 6;
        long xA = 31;
        long xB = 71;
        long M = 723;
        long k = 53;

        (long, long, long) expectedPUa = (809, 6, 391);
        (long, long, long) expectedPUb = (809, 6, 340);

        (long, long) expectedC = (715, 220);

        (long, long, long) actualPUa = ElGamal.GetPublicKey(q, a, xA);
        (long, long, long) actualPUb = ElGamal.GetPublicKey(q, a, xB);

        (long, long) actualC = ElGamal.Encript(M, k, actualPUa);
        long decryptC = ElGamal.Decrypt(actualC, q, xA);

        Assert.AreEqual(M, decryptC, "Decrypted message should match the original message.");
        Assert.AreEqual(expectedPUa, actualPUa, "Public key A is not correct.");
        Assert.AreEqual(expectedPUb, actualPUb, "Public key B is not correct.");
        Assert.AreEqual(expectedC, actualC, "Ciphertext is not correct.");
        Assert.AreEqual(M, decryptC, "Decrypted value is not correct.");
    }

    [TestMethod]
    public void TestElGamal3()
    {
        long q = 43;
        long a = 3;
        long xA = 25;
        long xB = 17;
        long M = 30;
        long k = 16;

        (long, long, long) expectedPUa = (43, 3, 5);
        (long, long, long) expectedPUb = (43, 3, 26);

        (long, long) expectedC = (23, 39);

        (long, long, long) actualPUa = ElGamal.GetPublicKey(q, a, xA);
        (long, long, long) actualPUb = ElGamal.GetPublicKey(q, a, xB);

        (long, long) actualC = ElGamal.Encript(M, k, actualPUa);
        long decryptC = ElGamal.Decrypt(actualC, q, xA);

        Assert.AreEqual(M, decryptC, "Decrypted message should match the original message.");
        Assert.AreEqual(expectedPUa, actualPUa, "Public key A is not correct.");
        Assert.AreEqual(expectedPUb, actualPUb, "Public key B is not correct.");
        Assert.AreEqual(expectedC, actualC, "Ciphertext is not correct.");
        Assert.AreEqual(M, decryptC, "Decrypted value is not correct.");
    }

    [TestMethod]
    public void TestElGamal4()
    {
        long q = 47;
        long a = 5;
        long xA = 13;
        long xB = 21;
        long M = 10;
        long k = 12;

        (long, long, long) expectedPUa = (47, 5, 43);
        (long, long, long) expectedPUb = (47, 5, 15);

        (long, long) expectedC = (18, 20);

        (long, long, long) actualPUa = ElGamal.GetPublicKey(q, a, xA);
        (long, long, long) actualPUb = ElGamal.GetPublicKey(q, a, xB);

        (long, long) actualC = ElGamal.Encript(M, k, actualPUa);
        long decryptC = ElGamal.Decrypt(actualC, q, xA);

        Assert.AreEqual(M, decryptC, "Decrypted message should match the original message.");
        Assert.AreEqual(expectedPUa, actualPUa, "Public key A is not correct.");
        Assert.AreEqual(expectedPUb, actualPUb, "Public key B is not correct.");
        Assert.AreEqual(expectedC, actualC, "Ciphertext is not correct.");
        Assert.AreEqual(M, decryptC, "Decrypted value is not correct.");
    }

    [TestMethod]
    public void TestElGamal5()
    {
        long q = 607;
        long a = 21;
        long xA = 29;
        long xB = 34;
        long M = 18;
        long k = 24;

        (long, long, long) expectedPUa = (607, 21, 90);
        (long, long, long) expectedPUb = (607, 21, 240);

        (long, long) expectedC = (489, 375);

        (long, long, long) actualPUa = ElGamal.GetPublicKey(q, a, xA);
        (long, long, long) actualPUb = ElGamal.GetPublicKey(q, a, xB);

        (long, long) actualC = ElGamal.Encript(M, k, actualPUa);
        long decryptC = ElGamal.Decrypt(actualC, q, xA);

        Assert.AreEqual(M, decryptC, "Decrypted message should match the original message.");
        Assert.AreEqual(expectedPUa, actualPUa, "Public key A is not correct.");
        Assert.AreEqual(expectedPUb, actualPUb, "Public key B is not correct.");
        Assert.AreEqual(expectedC, actualC, "Ciphertext is not correct.");
        Assert.AreEqual(M, decryptC, "Decrypted value is not correct.");
    }
}