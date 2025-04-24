using System.Security.Principal;
using Atbmtt.ClassicalEncription;
using Atbmtt.MyMath;

namespace AtbmttTest;

[TestClass]
public sealed class TestMath
{
    [TestMethod]
    public void Test_ModExp()
    {
        int a = 443;
        int m = 6373;
        int n = 6373;

        int expected = 443;

        int actual = Atbmtt.MyMath.Math.ModExp(a, m, n);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_ModExp2()
    {
        int a = 101;
        int m = 597;
        int n = 323;

        int expected = 254;

        int actual = Atbmtt.MyMath.Math.ModExp(a, m, n);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_ModExp3()
    {
        int a = 2167;
        int m = 817;
        int n = 356;

        int expected = 15;

        int actual = Atbmtt.MyMath.Math.ModExp(a, m, n);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_ModExp4()
    {
        int a = 0;
        int m = 0;
        int n = 1;

        int expected = 0;

        int actual = Atbmtt.MyMath.Math.ModExp(a, m, n);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_ModExp5()
    {
        int a = 0;
        int m = 0;
        int n = 0;

        Assert.ThrowsException<DivideByZeroException>(() => Atbmtt.MyMath.Math.ModExp(a, m, n));
    }

    [TestMethod]
    public void Test_ModExp6()
    {
        int a = 0;
        int m = 0;
        int n = -1;

        Assert.ThrowsException<ArgumentException>(() => Atbmtt.MyMath.Math.ModExp(a, m, n));
    }

    [TestMethod]
    public void Test_ModExp7()
    {
        int a = 0;
        int m = -1;
        int n = 1;

        Assert.ThrowsException<ArgumentException>(() => Atbmtt.MyMath.Math.ModExp(a, m, n));
    }

    [TestMethod]
    public void Test_ExtEuclid()
    {
        int a = 1392;
        int b = 5639;

        int expectedGCD = 1;
        int expectedInverseA = 3018;

        int actualGCD = 0;
        int? actualInverseA = 0;

        (actualGCD, actualInverseA) = Atbmtt.MyMath.Math.ExtendedEuclidean(a, b);

        Assert.AreEqual(expectedGCD, actualGCD);
        Assert.AreEqual(expectedInverseA, actualInverseA);
    }

    [TestMethod]
    public void Test_Fermat()
    {
        int baseValue = 443;
        int exponent = 6373;
        int modulus = 6373;

        int expected = 443;

        int? actual = Atbmtt.MyMath.Math.Fermat(baseValue, exponent, modulus);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_Fermat2()
    {
        int baseValue = 5;
        int exponent = 102;
        int modulus = 11;

        int expected = 3;

        int? actual = Atbmtt.MyMath.Math.Fermat(baseValue, exponent, modulus);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_Fermat3()
    {
        int baseValue = 159;
        int exponent = 30;
        int modulus = 31;
        int expected = 1;

        int? actual = Atbmtt.MyMath.Math.Fermat(baseValue, exponent, modulus);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_Fermat4()
    {
        int baseValue = 159;
        int exponent = 157;
        int modulus = 31;
        int expected = 16;

        int? actual = Atbmtt.MyMath.Math.Fermat(baseValue, exponent, modulus);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_Modex()
    {
        int baseValue = 15;
        int exponent = 39;
        int modulus = 51;
        int expected = 42;

        int? actual = Atbmtt.MyMath.Math.ModExp(baseValue, exponent, modulus);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_IsPrime()
    {
        int number = 7;

        bool expected = true;

        bool actual = Atbmtt.MyMath.Math.IsPrime(number);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_IsPrime2()
    {
        int number = 10;

        bool expected = false;

        bool actual = Atbmtt.MyMath.Math.IsPrime(number);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_IsPrime3()
    {
        int number = 1;

        bool expected = false;

        bool actual = Atbmtt.MyMath.Math.IsPrime(number);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_EulerTotient()
    {
        int n = 37;

        int expected = 36;

        int actual = Atbmtt.MyMath.Math.EulerTotient(n);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_EulerTotient2()
    {
        int n = 8;

        int expected = 4;

        int actual = Atbmtt.MyMath.Math.EulerTotient(n);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_EulerTotient3()
    {
        int n = 21;

        int expected = 12;

        int actual = Atbmtt.MyMath.Math.EulerTotient(n);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_EulerTotient4()
    {
        int n = 1;

        int expected = 1;

        int actual = Atbmtt.MyMath.Math.EulerTotient(n);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_EulerTotient5()
    {
        int n = 0;

        Assert.ThrowsException<ArgumentException>(() => Atbmtt.MyMath.Math.EulerTotient(n));
    }

    [TestMethod]
    public void Test_EulerTotient6()
    {
        int n = 72;

        int expected = 24;

        int actual = Atbmtt.MyMath.Math.EulerTotient(n);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_EulerTotient7()
    {
        int n = 300;

        int expected = 80;

        int actual = Atbmtt.MyMath.Math.EulerTotient(n);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_EulerTotient9()
    {
        int n = 108;

        int expected = 36;

        int actual = Atbmtt.MyMath.Math.EulerTotient(n);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_EulerTotient10()
    {
        int n = 2905;

        int expected = 1968;

        int actual = Atbmtt.MyMath.Math.EulerTotient(n);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_Euler()
    {
        int baseValue = 3;
        int exponent = 4;
        int modulus = 10;

        int expected = 1;

        int? actual = Atbmtt.MyMath.Math.Euler(baseValue, exponent, modulus);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_Euler2()
    {
        int baseValue = 24;
        int exponent = 3919;
        int modulus = 200;

        int expected = 24;

        int? actual = Atbmtt.MyMath.Math.Euler(baseValue, exponent, modulus);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_Euler3()
    {
        int baseValue = 6;
        int exponent = 9;
        int modulus = 15;

        int expected = 6;

        int? actual = Atbmtt.MyMath.Math.Euler(baseValue, exponent, modulus);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_Euler4()
    {
        int baseValue = 283;
        int exponent = 110;
        int modulus = 242;

        int expected = 1;

        int? actual = Atbmtt.MyMath.Math.Euler(baseValue, exponent, modulus);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_Euler5()
    {
        int baseValue = 283;
        int exponent = 1821;
        int modulus = 242;

        int expected = 19;

        int? actual = Atbmtt.MyMath.Math.Euler(baseValue, exponent, modulus);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_Euler6()
    {
        int baseValue = 4;
        int exponent = 8;
        int modulus = 15;

        int expected = 1;

        int? actual = Atbmtt.MyMath.Math.Euler(baseValue, exponent, modulus);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_Euler7()
    {
        int baseValue = 11;
        int exponent = 9;
        int modulus = 20;

        int expected = 11;

        int? actual = Atbmtt.MyMath.Math.Euler(baseValue, exponent, modulus);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_Euler8()
    {
        int baseValue = 12;
        int exponent = 402;
        int modulus = 25;

        int expected = 19;

        int? actual = Atbmtt.MyMath.Math.Euler(baseValue, exponent, modulus);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_ModExp8()
    {
        int baseValue = 12;
        int exponent = 402;
        int modulus = 25;

        int expected = 19;

        int? actual = Atbmtt.MyMath.Math.ModExp(baseValue, exponent, modulus);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_ModExp10()
    {
        int baseValue = 95;
        int exponent = 783;
        int modulus = 323;

        int expected = 114;

        int? actual = Atbmtt.MyMath.Math.ModExp(baseValue, exponent, modulus);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_ModChineseTheorem1()
    {
        int baseValue = 95;
        int exponent = 783;
        int modulus = 323;

        int expected = 114;

        int actual = Atbmtt.MyMath.Math.ModExpChineseRemainder(baseValue, exponent, modulus);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_ModChineseTheorem2()
    {
        int baseValue = 101;
        int exponent = 59;
        int modulus = 323;

        int expected = 271;

        int actual = Atbmtt.MyMath.Math.ModExpChineseRemainder(baseValue, exponent, modulus);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void ChineseRemainderTheorem1()
    {
        int[] asValue = [6, 2, 4];
        int[] msValue = [11, 13, 487];

        int expected = 14614;

        int actual = Atbmtt.MyMath.Math.ChineseRemainderTheorem(msValue, asValue);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void ChineseRemainderTheorem2()
    {
        int[] asValue = [2, 3, 2];
        int[] msValue = [3, 5, 7];

        int expected = 23;

        int actual = Atbmtt.MyMath.Math.ChineseRemainderTheorem(msValue, asValue);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void ChineseRemainderTheorem3()
    {
        int[] asValue = [7, 15, 11];
        int[] msValue = [13, 17, 19];

        int expected = 2633;

        int actual = Atbmtt.MyMath.Math.ChineseRemainderTheorem(msValue, asValue);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestIsPrimitiveRoot1()
    {
        int a = 2;
        int n = 353;

        bool expected = false;

        bool actual = Atbmtt.MyMath.Math.IsPrimitiveRoot(a, n);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestIsPrimitiveRoot2()
    {
        int a = 3;
        int n = 353;

        bool expected = true;

        bool actual = Atbmtt.MyMath.Math.IsPrimitiveRoot(a, n);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestIsPrimitiveRoot3()
    {
        int a = 3;
        int n = 499;

        bool expected = false;

        bool actual = Atbmtt.MyMath.Math.IsPrimitiveRoot(a, n);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestIsPrimitiveRoot4()
    {
        int a = 3;
        int n = 311;

        bool expected = false;

        bool actual = Atbmtt.MyMath.Math.IsPrimitiveRoot(a, n);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestDiscreteLogarithm1()
    {
        int baseVal = 3;
        int elem = 5;
        int mod = 7;
        int expected = 5;

        int actual = Atbmtt.MyMath.Math.DiscreteLogarithm(baseVal, elem, mod);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestDiscreteLogarithm2()
    {
        int baseVal = 3;
        int elem = 6;
        int mod = 7;
        int expected = 3;

        int actual = Atbmtt.MyMath.Math.DiscreteLogarithm(baseVal, elem, mod);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestDiscreteLogarithm3()
    {
        int baseVal = 2;
        int elem = 9;
        int mod = 13;
        int expected = 8;

        int actual = Atbmtt.MyMath.Math.DiscreteLogarithm(baseVal, elem, mod);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestDiscreteLogarithm4()
    {
        int baseVal = 2;
        int elem = 5;
        int mod = 13;
        int expected = 9;

        int actual = Atbmtt.MyMath.Math.DiscreteLogarithm(baseVal, elem, mod);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestDiscreteLogarithm5()
    {
        int baseVal = 5;
        int elem = 2;
        int mod = 17;
        int expected = 6;

        int actual = Atbmtt.MyMath.Math.DiscreteLogarithm(baseVal, elem, mod);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestA()
    {
        int a = 73;
        int b = 67;
        int x = 498;
        int y = 582;
        int n = 269;

        int expectedA1 = 148;
        int expectedA2 = 102;
        int expectedA3 = 185;
        int expectedA4 = 117;   
        int expectedA5 = 99;

        int actualA1 = Atbmtt.MyMath.Math.A1(a, b, x, y, n);
        int actualA2 = Atbmtt.MyMath.Math.A2(a, b, x, y, n);
        int actualA3 = Atbmtt.MyMath.Math.A3(a, b, x, y, n);
        int actualA4 = Atbmtt.MyMath.Math.A4(b, y, n);
        int actualA5 = Atbmtt.MyMath.Math.A5(a, b, x, y, n);


        Assert.AreEqual(expectedA1, actualA1);
        Assert.AreEqual(expectedA2, actualA2);
        Assert.AreEqual(expectedA3, actualA3);
        Assert.AreEqual(expectedA4, actualA4);
        Assert.AreEqual(expectedA5, actualA5);
    }
}
