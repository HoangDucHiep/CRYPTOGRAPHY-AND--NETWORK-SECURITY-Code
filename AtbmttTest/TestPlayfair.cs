using Atbmtt.ClassicalEncription;

namespace AtbmttTest;

[TestClass]
public sealed class TestPlayfair
{
    [TestMethod]
    public void Test_Generate_Key_Matrix()
    {
        Playfair pf = new Playfair("ITSASMA");
        char[,] expected = new char[5, 5]
        {
            { 'I', 'T', 'S', 'A', 'M' },
            { 'B', 'C', 'D', 'E', 'F' },
            { 'G', 'H', 'K', 'L', 'N' },
            { 'O', 'P', 'Q', 'R', 'U' },
            { 'V', 'W', 'X', 'Y', 'Z' },
        };

        Assert.IsTrue(AreMatricesEqual(expected, pf.matrix));
    }

    [TestMethod]
    public void Test_Splitter()
    {
        Playfair pf = new Playfair("ITSASMA");
        List<string> actual = pf.SplitText("BEAUTYISINTHEE");
        List<string> expected = new List<string> { "BE", "AU", "TY", "IS", "IN", "TH", "EX", "EX" };

        Assert.IsTrue(expected.SequenceEqual(actual));
    }

    [TestMethod]
    public void Test_Encript()
    {
        Playfair pf = new Playfair("ITSASMA");
        string actual = pf.Encrypt("BEAUTYISINTHEE");
        string expected = "CFMRAWTAMGCPDYDY";
        Assert.IsTrue(expected.Equals(actual));
    }

    [TestMethod]
    public void Test_Decript()
    {
        Playfair pf = new Playfair("ITSASMA");
        string actual = pf.Decrypt("CFMRAWTAMGCPDYDY");
        string expected = "BEAUTYISINTHEXEX";
        Assert.IsTrue(expected.Equals(actual));
    }

    bool AreMatricesEqual(char[,] matrix1, char[,] matrix2)
    {
        if (
            matrix1.GetLength(0) != matrix2.GetLength(0)
            || matrix1.GetLength(1) != matrix2.GetLength(1)
        )
        {
            return false;
        }

        for (int i = 0; i < matrix1.GetLength(0); i++)
        {
            for (int j = 0; j < matrix1.GetLength(1); j++)
            {
                if (matrix1[i, j] != matrix2[i, j])
                {
                    return false;
                }
            }
        }

        return true;
    }

    
}
