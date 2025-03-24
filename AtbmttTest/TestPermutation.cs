using Atbmtt.ClassicalEncription;
using Atbmtt.Utils;
using Math = Atbmtt.MyMath.Math;

namespace AtbmttTest
{
    [TestClass]
    public sealed class TestPermutation
    {
        [TestMethod]
        public void Test_Number_Permutation1()
        {
            int[] a = { 1, 2, 3, 4, 5 };
            int[] b = { 1, 2, 3, 4, 5 };
            Assert.IsTrue(Math.isPermutation(a, b));
        }

        [TestMethod]
        public void Test_Number_Permutation2()
        {
            int[] a = { 1, 2, 3, 4, 5 };
            int[] b = { 1, 3, 4, 2, 5 };
            Assert.IsTrue(Math.isPermutation(a, b));
        }

        [TestMethod]
        public void Test_Number_Permutatio3()
        {
            int[] a = { 1, 2, 3, 4, 5 };
            int[] b = { 1, 3, 4, 2 };
            Assert.IsFalse(Math.isPermutation(a, b));
        }

        [TestMethod]
        public void Test_String_Permutation1()
        {
            string[] a = { "a", "b", "c", "d", "e" };
            string[] b = { "a", "b", "c", "d", "e" };
            Assert.IsTrue(Math.isPermutation(a, b));
        }

        [TestMethod]
        public void Test_String_Permutation2()
        {
            string[] a = { "a", "b", "c", "d", "e" };
            string[] b = { "a", "c", "d", "b", "e" };
            Assert.IsTrue(Math.isPermutation(a, b));
        }

        [TestMethod]
        public void Test_String_Permutation3()
        {
            string[] a = { "a", "b", "c", "d", "e" };
            string[] b = { "a", "c", "d", "b" };
            Assert.IsFalse(Math.isPermutation(a, b));
        }

        [TestMethod]
        public void Test_ReferenceType_Permutation1()
        {
            CustomAlphabet[] a = { new CustomAlphabet("abc"), new CustomAlphabet("def") };
            CustomAlphabet[] b = { new CustomAlphabet("abc"), new CustomAlphabet("def") };
            Assert.IsTrue(Math.isPermutation(a, b));
        }

        [TestMethod]
        public void Test_ReferenceType_Permutation2()
        {
            CustomAlphabet[] a = { new CustomAlphabet("abc"), new CustomAlphabet("def") };
            CustomAlphabet[] b = { new CustomAlphabet("def"), new CustomAlphabet("abc") };
            Assert.IsTrue(Math.isPermutation(a, b));
        }

        [TestMethod]
        public void Test_ReferenceType_Permutation3()
        {
            string a = "abcdefghijklmnopqrstuvwxyz";
            string b = "zyxwvutsrqponmlkjihgfedcba";
            Assert.IsTrue(Math.isPermutation<char>(a.ToArray(), b.ToArray()));
        }
    }
}
