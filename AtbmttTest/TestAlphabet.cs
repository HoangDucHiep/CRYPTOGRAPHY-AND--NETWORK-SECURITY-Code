using Atbmtt.ClassicalEncription;
using Atbmtt.Utils;

namespace AtbmttTest
{
    [TestClass]
    public sealed class TestAlphabet
    {
        [TestMethod]
        public void Test_Default_Alphabet_LowerCase()
        {
            Alphabet alphabet = new Alphabet();
            string actual = alphabet.GetAlphabet();
            string expected = "abcdefghijklmnopqrstuvwxyz";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Default_Alphabet_UpperCase()
        {
            Alphabet alphabet = new Alphabet();
            string actual = alphabet.GetAlphabet(true);
            string expected = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Vietnamese_Alphabet_LowerCase()
        {
            Alphabet alphabet = new Alphabet("aăâbcdđeêghiklmnoôơpqrstuưvxy");
            string actual = alphabet.GetAlphabet();
            string expected = "aăâbcdđeêghiklmnoôơpqrstuưvxy";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Vietnamese_Alphabet_UpperCase()
        {
            Alphabet alphabet = new Alphabet("aăâbcdđeêghiklmnoôơpqrstuưvxy");
            string actual = alphabet.GetAlphabet(true);
            string expected = "AĂÂBCDĐEÊGHIKLMNOÔƠPQRSTUƯVXY";
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void Test_Custom_Alphabet_IsLower()
        {
            Alphabet alphabet = new Alphabet("abcשלוםÂĂƯ");
            string actual = alphabet.GetAlphabet();
            string expected = "abcשלוםÂĂƯ";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Custom_Alphabet_IsUpper()
        {
            Alphabet alphabet = new Alphabet("abcשלוםÂĂƯ");
            string actual = alphabet.GetAlphabet(true);
            string expected = "ABCשלוםÂĂƯ";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Uppercase_Char()
        {
            Alphabet alphabet = new Alphabet("aăâbcdđeêghiklmnoôơpqrstuưvxy");
            char actual = alphabet.GetUpperChar('á');
            char expected = 'Á';
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Lowercase_Char()
        {
            Alphabet alphabet = new Alphabet("aăâbcdđeêghiklmnoôơpqrstuưvxy");
            char actual = alphabet.GetLowerChar('Á');
            char expected = 'á';
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Lowercase_String()
        {
            Alphabet alphabet = new Alphabet("aăâbcdđeêghiklmnoôơpqrstuưvxy");
            string actual = alphabet.GetLowerString("ÁBCD");
            string expected = "ábcd";
            Assert.AreEqual(expected, actual.ToLowerInvariant());
        }

        [TestMethod]
        public void Test_Uppercase_String()
        {
            Alphabet alphabet = new Alphabet("aăâbcdđeêghiklmnoôơpqrstuưvxy");
            string actual = alphabet.GetUpperString("áBcd");
            string expected = "ÁBCD";
            Assert.AreEqual(expected, actual.ToUpperInvariant());
        }
    }
}
