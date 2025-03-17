using Atbmtt.ClassicalEncription;

namespace AtbmttTest
{
    [TestClass]
    public sealed class TestCaesarCipher
    {
        [TestMethod]
        public void Test_CaesarCipher_Encode_Hello_Key_3()
        {
            string plainText = "HELLO";
            byte key = 3;
            string expected = "KHOOR";
            string actual = CaesarCipher.Encode(plainText, key);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_CaesarCipher_Encode_LOVEISBLINDLOVEI_Key_21()
        {
            string cipherText = "LOVEISBLINDLOVEI";
            byte key = 21;
            string expected = "GJQZDNWGDIYGJQZD";
            string actual = CaesarCipher.Encode(cipherText, key);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_CaesarCipher_Encode_hiepasdqASDDASqwe_Key_16()
        {
            string cipherText = "hiepasdqASDDASqwe";
            byte key = 16;
            string expected = "xyufqitgQITTQIgmu";
            string actual = CaesarCipher.Encode(cipherText, key);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_CaesarCipher_Decode_Khoor_Key_3()
        {
            string cipherText = "KHOOR";
            byte key = 3;
            string expected = "HELLO";
            string actual = CaesarCipher.Decode(cipherText, key);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_CaesarCipher_Decode_LOVEISBLINDLOVEI_Key_21()
        {
            string cipherText = "GJQZDNWGDIYGJQZD";
            byte key = 21;
            string expected = "LOVEISBLINDLOVEI";
            string actual = CaesarCipher.Decode(cipherText, key);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_CaesarCipher_Decode_xyufqitgQITTQIgmu_Key_16()
        {
            string cipherText = "xyufqitgQITTQIgmu";
            byte key = 16;
            string expected = "hiepasdqASDDASqwe";
            string actual = CaesarCipher.Decode(cipherText, key);
            Assert.AreEqual(expected, actual);
        }
    }
}
