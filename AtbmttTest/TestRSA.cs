using Atbmtt.PublicKeyCryptography;

namespace AtbmttTest;

[TestClass]
public sealed class TestRSA
{

    [TestMethod]
    public void TestRSAa1()
    {
        long p = 3;
        long q = 11;
        long e = 7;
        long M = 5;

        (long, long) expectedPU = (7, 33);
        (long, long) expectedPR = (3, 33);
        long expectedC = 26;

        (long, long) actualPU = RSA.GetPublicKey(p, q, e);
        (long, long) actualPR = RSA.GetPrivateKey(p, q, e);
        long actualC = RSA.Encript(M, actualPR);
        long decryptC = RSA.Decrypt(actualC, actualPU);

        Assert.AreEqual(expectedPU, actualPU, "Public key is not correct.");
        Assert.AreEqual(expectedPR, actualPR, "Private key is not correct.");
        Assert.AreEqual(expectedC, actualC, "Ciphertext is not correct.");
        Assert.AreEqual(M, decryptC, "Decrypted value is not correct.");
    }

    [TestMethod]
    public void TestRSAa2()
    {
        long p = 5;
        long q = 11;
        long e = 3;
        long M = 9;

        (long, long) expectedPU = (3, 55);
        (long, long) expectedPR = (27, 55);
        long expectedC = 4;

        (long, long) actualPU = RSA.GetPublicKey(p, q, e);
        (long, long) actualPR = RSA.GetPrivateKey(p, q, e);
        long actualC = RSA.Encript(M, actualPR);
        long decryptC = RSA.Decrypt(actualC, actualPU);

        Assert.AreEqual(expectedPU, actualPU, "Public key is not correct.");
        Assert.AreEqual(expectedPR, actualPR, "Private key is not correct.");
        Assert.AreEqual(expectedC, actualC, "Ciphertext is not correct.");
        Assert.AreEqual(M, decryptC, "Decrypted value is not correct.");
    }

    [TestMethod]
    public void TestRSAa3()
    {
        long p = 7;
        long q = 11;
        long e = 13;
        long M = 3;

        (long, long) expectedPU = (13, 77);
        (long, long) expectedPR = (37, 77);
        long expectedC = 31;

        (long, long) actualPU = RSA.GetPublicKey(p, q, e);
        (long, long) actualPR = RSA.GetPrivateKey(p, q, e);
        long actualC = RSA.Encript(M, actualPR);
        long decryptC = RSA.Decrypt(actualC, actualPU);

        Assert.AreEqual(expectedPU, actualPU, "Public key is not correct.");
        Assert.AreEqual(expectedPR, actualPR, "Private key is not correct.");
        Assert.AreEqual(expectedC, actualC, "Ciphertext is not correct.");
        Assert.AreEqual(M, decryptC, "Decrypted value is not correct.");
    }

    [TestMethod]
    public void TestRSAa4()
    {
        long p = 11;
        long q = 13;
        long e = 17;
        long M = 8;

        (long, long) expectedPU = (17, 143);
        (long, long) expectedPR = (113, 143);
        long expectedC = 138;

        (long, long) actualPU = RSA.GetPublicKey(p, q, e);
        (long, long) actualPR = RSA.GetPrivateKey(p, q, e);
        long actualC = RSA.Encript(M, actualPR);
        long decryptC = RSA.Decrypt(actualC, actualPU);

        Assert.AreEqual(expectedPU, actualPU, "Public key is not correct.");
        Assert.AreEqual(expectedPR, actualPR, "Private key is not correct.");
        Assert.AreEqual(expectedC, actualC, "Ciphertext is not correct.");
        Assert.AreEqual(M, decryptC, "Decrypted value is not correct.");
    }

    [TestMethod]
    public void TestRSAa5()
    {
        long p = 19;
        long q = 23;
        long e = 41;
        long M = 15;

        (long, long) expectedPU = (41, 437);
        (long, long) expectedPR = (29, 437);
        long expectedC = 402;

        (long, long) actualPU = RSA.GetPublicKey(p, q, e);
        (long, long) actualPR = RSA.GetPrivateKey(p, q, e);
        long actualC = RSA.Encript(M, actualPR);
        long decryptC = RSA.Decrypt(actualC, actualPU);

        Assert.AreEqual(expectedPU, actualPU, "Public key is not correct.");
        Assert.AreEqual(expectedPR, actualPR, "Private key is not correct.");
        Assert.AreEqual(expectedC, actualC, "Ciphertext is not correct.");
        Assert.AreEqual(M, decryptC, "Decrypted value is not correct.");
    }


    [TestMethod]
    public void TestRSAb1()
    {
        long p = 3;
        long q = 11;
        long e = 7;
        long M = 5;

        (long, long) expectedPU = (7, 33);
        (long, long) expectedPR = (3, 33);
        long expectedC = 14;

        (long, long) actualPU = RSA.GetPublicKey(p, q, e);
        (long, long) actualPR = RSA.GetPrivateKey(p, q, e);
        long actualC = RSA.Encript(M, actualPU);
        long decryptC = RSA.Decrypt(actualC, actualPR);

        Assert.AreEqual(expectedPU, actualPU, "Public key is not correct.");
        Assert.AreEqual(expectedPR, actualPR, "Private key is not correct.");
        Assert.AreEqual(expectedC, actualC, "Ciphertext is not correct.");
        Assert.AreEqual(M, decryptC, "Decrypted value is not correct.");
    }

    [TestMethod]
    public void TestRSAb2()
    {
        long p = 5;
        long q = 11;
        long e = 3;
        long M = 9;

        (long, long) expectedPU = (3, 55);
        (long, long) expectedPR = (27, 55);
        long expectedC = 14;

        (long, long) actualPU = RSA.GetPublicKey(p, q, e);
        (long, long) actualPR = RSA.GetPrivateKey(p, q, e);
        long actualC = RSA.Encript(M, actualPU);
        long decryptC = RSA.Decrypt(actualC, actualPR);

        Assert.AreEqual(expectedPU, actualPU, "Public key is not correct.");
        Assert.AreEqual(expectedPR, actualPR, "Private key is not correct.");
        Assert.AreEqual(expectedC, actualC, "Ciphertext is not correct.");
        Assert.AreEqual(M, decryptC, "Decrypted value is not correct.");
    }

    [TestMethod]
    public void TestRSAb3()
    {
        long p = 7;
        long q = 11;
        long e = 13;
        long M = 3;

        (long, long) expectedPU = (13, 77);
        (long, long) expectedPR = (37, 77);
        long expectedC = 38;

        (long, long) actualPU = RSA.GetPublicKey(p, q, e);
        (long, long) actualPR = RSA.GetPrivateKey(p, q, e);
        long actualC = RSA.Encript(M, actualPU);
        long decryptC = RSA.Decrypt(actualC, actualPR);

        Assert.AreEqual(expectedPU, actualPU, "Public key is not correct.");
        Assert.AreEqual(expectedPR, actualPR, "Private key is not correct.");
        Assert.AreEqual(expectedC, actualC, "Ciphertext is not correct.");
        Assert.AreEqual(M, decryptC, "Decrypted value is not correct.");
    }

    [TestMethod]
    public void TestRSAb4()
    {
        long p = 11;
        long q = 13;
        long e = 17;
        long M = 8;

        (long, long) expectedPU = (17, 143);
        (long, long) expectedPR = (113, 143);
        long expectedC = 112;

        (long, long) actualPU = RSA.GetPublicKey(p, q, e);
        (long, long) actualPR = RSA.GetPrivateKey(p, q, e);
        long actualC = RSA.Encript(M, actualPU);
        long decryptC = RSA.Decrypt(actualC, actualPR);

        Assert.AreEqual(expectedPU, actualPU, "Public key is not correct.");
        Assert.AreEqual(expectedPR, actualPR, "Private key is not correct.");
        Assert.AreEqual(expectedC, actualC, "Ciphertext is not correct.");
        Assert.AreEqual(M, decryptC, "Decrypted value is not correct.");
    }

    [TestMethod]
    public void TestRSAb5()
    {
        long p = 19;
        long q = 23;
        long e = 41;
        long M = 15;

        (long, long) expectedPU = (41, 437);
        (long, long) expectedPR = (29, 437);
        long expectedC = 249;

        (long, long) actualPU = RSA.GetPublicKey(p, q, e);
        (long, long) actualPR = RSA.GetPrivateKey(p, q, e);
        long actualC = RSA.Encript(M, actualPU);
        long decryptC = RSA.Decrypt(actualC, actualPR);

        Assert.AreEqual(expectedPU, actualPU, "Public key is not correct.");
        Assert.AreEqual(expectedPR, actualPR, "Private key is not correct.");
        Assert.AreEqual(expectedC, actualC, "Ciphertext is not correct.");
        Assert.AreEqual(M, decryptC, "Decrypted value is not correct.");
    }
}