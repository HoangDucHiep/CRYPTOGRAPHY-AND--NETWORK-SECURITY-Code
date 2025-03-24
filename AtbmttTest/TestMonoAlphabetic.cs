using Atbmtt.ClassicalEncription;

namespace AtbmttTest;

[TestClass]
public sealed class TestMonoAlphabetic
{
    [TestMethod]
    public void Test_TestMonoAlphabetic_English_Alphabet_Encode()
    {
        string plainText = "If he had anything confidential to say, he wrote it in cipher, that is, by so changing the order of the letters of the alphabet, that not a word could be made out.";
        string alphabet = "abcdefghijklmnopqrstuvwxyz";
        string key = "zyxwvutsrqponmlkjihgfedcba";
        string expected = "Ru sv szw zmbgsrmt xlmurwvmgrzo gl hzb, sv dilgv rg rm xrksvi, gszg rh, yb hl xszmtrmt gsv liwvi lu gsv ovggvih lu gsv zokszyvg, gszg mlg z dliw xlfow yv nzwv lfg.";
        MonoAlphabetic ma = new(alphabet, key);
        string actual = ma.Encrypt(plainText);
        Assert.AreEqual(expected, actual);
    }


    [TestMethod]
    public void Test_TestMonoAlphabetic_English_Alphabet_Decode()
    {
        string expected = "If he had anything confidential to say, he wrote it in cipher, that is, by so changing the order of the letters of the alphabet, that not a word could be made out.";
        string alphabet = "abcdefghijklmnopqrstuvwxyz";
        string key = "zyxwvutsrqponmlkjihgfedcba";
        string cipher = "Ru sv szw zmbgsrmt xlmurwvmgrzo gl hzb, sv dilgv rg rm xrksvi, gszg rh, yb hl xszmtrmt gsv liwvi lu gsv ovggvih lu gsv zokszyvg, gszg mlg z dliw xlfow yv nzwv lfg.";
        MonoAlphabetic ma = new(alphabet, key);
        string actual = ma.Decrypt(cipher);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_TestMonoAlphabetic_Vietnamese_Alphabet_Encode()
    {
        string plainText = "Đây là một đoạn tin nhắn gì gì đó. 123123";
        string alphabet = "aăâbcdđeêghiklmnoôơpqrstuưvxy";
        string key = "yxvưutsrqpơôonmlkihgêeđdcbâăa";
        string expected = "Sva nà mộd skạl dôl lơắl pì pì só. 123123";
        MonoAlphabetic ma = new(alphabet, key);
        string actual = ma.Encrypt(plainText);
        Assert.AreEqual(expected, actual);
    }


    [TestMethod]
    public void Test_TestMonoAlphabetic_Vietnamese_Alphabet_Decode()
    {
        string expected = "Đây là một đoạn tin nhắn gì gì đó. 123123";
        string alphabet = "aăâbcdđeêghiklmnoôơpqrstuưvxy";
        string key = "yxvưutsrqpơôonmlkihgêeđdcbâăa";
        string cipher = "Sva nà mộd skạl dôl lơắl pì pì só. 123123";
        MonoAlphabetic ma = new(alphabet, key);
        string actual = ma.Decrypt(cipher);
        Assert.AreEqual(expected, actual);
    }
}
