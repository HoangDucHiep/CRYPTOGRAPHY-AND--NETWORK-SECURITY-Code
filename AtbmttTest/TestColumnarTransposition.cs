using Atbmtt.ClassicalEncription;

namespace AtbmttTest;

[TestClass]
public sealed class TestColumnarTransposition
{
    [TestMethod]
    public void Test_Parse_Key()
    {
        string key = "53214";
        Dictionary<int, int> expected = new()
        {
            {5, 0},
            {3, 1},
            {2, 2},
            {1, 3},
            {4, 4}
        };

        Dictionary<int, int> actual = ColumnarTransposition.ParseKey(key);

        CollectionAssert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_Parse_InvalidKey()
    {
        string key = "63214";

        Assert.ThrowsException<ArgumentException>(() => ColumnarTransposition.ParseKey(key));
    }

    [TestMethod]
    public void Test_Encrypt()
    {
        string plainText = "attack postponed until two am";
        string key = "4312567";
        string expected = "ttnaaptmtsuoaodwcoixknlypetz";

        string actual = ColumnarTransposition.Encrypt(plainText, key);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_Encrypt2()
    {
        string plainText = "ATTACK POSTPONED UNTIL TWO AM";
        string key = "4312567";
        string expected = "TTNAAPTMTSUOAODWCOIXKNLYPETZ";

        string actual = ColumnarTransposition.Encrypt(plainText, key);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_Decript()
    {
        string cipherText = "TTNAAPTMTSUOAODWCOIXKNLYPETZ";
        string key = "4312567";
        string expected = "ATTACKPOSTPONEDUNTILTWOAMXYZ";

        string actual = ColumnarTransposition.Decrypt(cipherText, key);

        Assert.AreEqual(expected, actual);
    }
}