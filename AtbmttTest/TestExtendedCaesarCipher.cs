using Atbmtt.ClassicalEncription;

namespace AtbmttTest
{
    [TestClass]
    public sealed class TestExtendedCaesarCipher
    {
        [TestMethod]
        public void Test_CaesarCipher_Encode_Hello_Key_3()
        {
            string plainText = "HELLO";
            byte key = 3;
            string expected = "KHOOR";
            ExtendedCaesarCipher cs = new();
            string actual = cs.Encode(key, plainText);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_CaesarCipher_Encode_LOVEISBLINDLOVEI_Key_21()
        {
            string plainText = "LOVEISBLINDLOVEI";
            byte key = 21;
            string expected = "GJQZDNWGDIYGJQZD";
            ExtendedCaesarCipher cs = new();
            string actual = cs.Encode(key, plainText);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_CaesarCipher_Encode_hiepasdqASDDASqwe_Key_16()
        {
            string plainText = "hiepasdqASDDASqwe";
            byte key = 16;
            string expected = "xyufqitgQITTQIgmu";
            ExtendedCaesarCipher cs = new();
            string actual = cs.Encode(key, plainText);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_CaesarCipher_Encode_vietnameseAlphabet_Key_16()
        {
            string plainText = "Đây là một đoạn văn";
            string alphabet = "aăâbcdđeêghijklmnoôơpqrstuưvxyz";
            byte key = 16;
            string expected = "Rôl zà aộg râạă joă";
            ExtendedCaesarCipher cs = new(alphabet);
            string actual = cs.Encode(key, plainText);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_CaesarCipher_Encode_ChineseCharacters_Key_5()
        {
            string plainText = "你好世界";
            string alphabet = "你好世界";
            byte key = 5;
            string expected = "好世界你";
            ExtendedCaesarCipher cs = new(alphabet);
            string actual = cs.Encode(key, plainText);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_CaesarCipher_Decode_Khoor_Key_3()
        {
            string cipherText = "KHOOR";
            byte key = 3;
            string expected = "HELLO";
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            ExtendedCaesarCipher cs = new(alphabet);
            string actual = cs.Decode(key, cipherText);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_CaesarCipher_Decode_LOVEISBLINDLOVEI_Key_21()
        {
            string cipherText = "GJQZDNWGDIYGJQZD";
            byte key = 21;
            string expected = "LOVEISBLINDLOVEI";
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            ExtendedCaesarCipher cs = new(alphabet);
            string actual = cs.Decode(key, cipherText);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_CaesarCipher_Decode_xyufqitgQITTQIgmu_Key_16()
        {
            string cipherText = "xyufqitgQITTQIgmu";
            byte key = 16;
            string expected = "hiepasdqASDDASqwe";
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            ExtendedCaesarCipher cs = new(alphabet);
            string actual = cs.Decode(key, cipherText);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_CaesarCipher_Decode_vietnameseAlphabet_Key_16()
        {
            string cipherText = "Rôl zà aộg râạă joă";
            string alphabet = "aăâbcdđeêghijklmnoôơpqrstuưvxyz";
            byte key = 16;
            ExtendedCaesarCipher cs = new(alphabet);
            string expected = "Đây là một đoạn văn";
            string actual = cs.Decode(key, cipherText);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_CaesarCipher_Decode_ChineseCharacters_Key_5()
        {
            string cipherText = "好世界你";
            string alphabet = "你好世界";
            byte key = 5;
            string expected = "你好世界";
            ExtendedCaesarCipher cs = new(alphabet);
            string actual = cs.Decode(key, cipherText);
            Assert.AreEqual(expected, actual);
        }
    }
}
