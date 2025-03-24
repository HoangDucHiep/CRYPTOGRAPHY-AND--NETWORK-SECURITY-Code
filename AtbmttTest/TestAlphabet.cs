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
            CustomAlphabet alphabet = new CustomAlphabet();
            string actual = alphabet.GetAlphabet();
            string expected = "abcdefghijklmnopqrstuvwxyz";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Default_Alphabet_UpperCase()
        {
            CustomAlphabet alphabet = new CustomAlphabet();
            string actual = alphabet.GetAlphabet(true);
            string expected = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Vietnamese_Alphabet_LowerCase()
        {
            CustomAlphabet alphabet = new CustomAlphabet("aăâbcdđeêghiklmnoôơpqrstuưvxy");
            string actual = alphabet.GetAlphabet();
            string expected = "aăâbcdđeêghiklmnoôơpqrstuưvxy";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Vietnamese_Alphabet_UpperCase()
        {
            CustomAlphabet alphabet = new CustomAlphabet("aăâbcdđeêghiklmnoôơpqrstuưvxy");
            string actual = alphabet.GetAlphabet(true);
            string expected = "AĂÂBCDĐEÊGHIKLMNOÔƠPQRSTUƯVXY";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Custom_Alphabet_IsLower()
        {
            CustomAlphabet alphabet = new CustomAlphabet("abcשלוםÂĂƯ");
            string actual = alphabet.GetAlphabet();
            string expected = "abcשלוםâăư";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Custom_Alphabet_IsUpper()
        {
            CustomAlphabet alphabet = new CustomAlphabet("abcשלוםÂĂƯ");
            string actual = alphabet.GetAlphabet(true);
            string expected = "ABCשלוםÂĂƯ";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Uppercase_Char()
        {
            CustomAlphabet alphabet = new CustomAlphabet("aăâbcdđeêghiklmnoôơpqrstuưvxy");
            char actual = alphabet.GetUpperInvariant('á');
            char expected = 'Á';
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Lowercase_Char()
        {
            CustomAlphabet alphabet = new CustomAlphabet("aăâbcdđeêghiklmnoôơpqrstuưvxy");
            char actual = alphabet.GetLowerInvariant('Á');
            char expected = 'á';
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Contains_Char1()
        {
            CustomAlphabet alphabet = new CustomAlphabet("aăâbdđeêghiklmnoôơpqrstuưvxy");
            bool actual = alphabet.Contains('c');
            bool expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Contains_Char2()
        {
            CustomAlphabet alphabet = new CustomAlphabet("aăâbdđeêghiklmnoôơpqrstuưvxy");
            bool actual = alphabet.Contains('C');
            bool expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Contains_Char3()
        {
            CustomAlphabet alphabet = new CustomAlphabet("aăâbCdđeêghiklmnoôơpqrstuưvxy");
            bool actual = alphabet.Contains('c');
            bool expected = true;
            Assert.AreEqual(expected, actual);
        }
    }
}
