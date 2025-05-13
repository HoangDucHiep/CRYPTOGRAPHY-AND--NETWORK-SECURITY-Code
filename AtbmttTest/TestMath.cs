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
        long a = 443;
        long m = 6373;
        long n = 6373;

        long expected = 443;

        long actual = Atbmtt.MyMath.ModulusMath.ModExp(a, m, n);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_ModExp2()
    {
        long a = 101;
        long m = 597;
        long n = 323;

        long expected = 254;

        long actual = Atbmtt.MyMath.ModulusMath.ModExp(a, m, n);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_ModExp3()
    {
        long a = 2167;
        long m = 817;
        long n = 356;

        long expected = 15;

        long actual = Atbmtt.MyMath.ModulusMath.ModExp(a, m, n);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_ModExp4()
    {
        long a = 0;
        long m = 0;
        long n = 1;

        long expected = 0;

        long actual = Atbmtt.MyMath.ModulusMath.ModExp(a, m, n);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_ModExp5()
    {
        long a = 0;
        long m = 0;
        long n = 0;

        Assert.ThrowsException<DivideByZeroException>(() => Atbmtt.MyMath.ModulusMath.ModExp(a, m, n));
    }

    [TestMethod]
    public void Test_ModExp6()
    {
        long a = 0;
        long m = 0;
        long n = -1;

        Assert.ThrowsException<ArgumentException>(() => Atbmtt.MyMath.ModulusMath.ModExp(a, m, n));
    }

    [TestMethod]
    public void Test_ModExp7()
    {
        long a = 0;
        long m = -1;
        long n = 1;

        Assert.ThrowsException<ArgumentException>(() => Atbmtt.MyMath.ModulusMath.ModExp(a, m, n));
    }

    [TestMethod]
    public void Test_ExtEuclid()
    {
        long a = 1392;
        long b = 5639;

        long expectedGCD = 1;
        long expectedInverseA = 3018;

        long actualGCD = 0;
        long? actualInverseA = 0;

        (actualGCD, actualInverseA) = Atbmtt.MyMath.ModulusMath.ExtendedEuclidean(a, b);

        Assert.AreEqual(expectedGCD, actualGCD);
        Assert.AreEqual(expectedInverseA, actualInverseA);
    }

    [TestMethod]
    public void Test_Fermat()
    {
        long baseValue = 443;
        long exponent = 6373;
        long modulus = 6373;

        long expected = 443;

        long? actual = Atbmtt.MyMath.ModulusMath.Ferma(baseValue, exponent, modulus);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_Fermat2()
    {
        long baseValue = 5;
        long exponent = 102;
        long modulus = 11;

        long expected = 3;

        long? actual = Atbmtt.MyMath.ModulusMath.Ferma(baseValue, exponent, modulus);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_Fermat3()
    {
        long baseValue = 159;
        long exponent = 30;
        long modulus = 31;
        long expected = 1;

        long? actual = Atbmtt.MyMath.ModulusMath.Ferma(baseValue, exponent, modulus);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_Fermat4()
    {
        long baseValue = 159;
        long exponent = 157;
        long modulus = 31;
        long expected = 16;

        long? actual = Atbmtt.MyMath.ModulusMath.Ferma(baseValue, exponent, modulus);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_Modex()
    {
        long baseValue = 15;
        long exponent = 39;
        long modulus = 51;
        long expected = 42;

        long? actual = Atbmtt.MyMath.ModulusMath.ModExp(baseValue, exponent, modulus);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_IsPrime()
    {
        long number = 7;

        bool expected = true;

        bool actual = Atbmtt.MyMath.ModulusMath.IsPrime(number);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_IsPrime2()
    {
        long number = 10;

        bool expected = false;

        bool actual = Atbmtt.MyMath.ModulusMath.IsPrime(number);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_IsPrime3()
    {
        long number = 1;

        bool expected = false;

        bool actual = Atbmtt.MyMath.ModulusMath.IsPrime(number);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_EulerTotient()
    {
        long n = 37;

        long expected = 36;

        long actual = Atbmtt.MyMath.ModulusMath.EulerTotient(n);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_EulerTotient2()
    {
        long n = 8;

        long expected = 4;

        long actual = Atbmtt.MyMath.ModulusMath.EulerTotient(n);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_EulerTotient3()
    {
        long n = 21;

        long expected = 12;

        long actual = Atbmtt.MyMath.ModulusMath.EulerTotient(n);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_EulerTotient4()
    {
        long n = 1;

        long expected = 1;

        long actual = Atbmtt.MyMath.ModulusMath.EulerTotient(n);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_EulerTotient5()
    {
        long n = 0;

        Assert.ThrowsException<ArgumentException>(() => Atbmtt.MyMath.ModulusMath.EulerTotient(n));
    }

    [TestMethod]
    public void Test_EulerTotient6()
    {
        long n = 72;

        long expected = 24;

        long actual = Atbmtt.MyMath.ModulusMath.EulerTotient(n);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_EulerTotient7()
    {
        long n = 300;

        long expected = 80;

        long actual = Atbmtt.MyMath.ModulusMath.EulerTotient(n);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_EulerTotient9()
    {
        long n = 108;

        long expected = 36;

        long actual = Atbmtt.MyMath.ModulusMath.EulerTotient(n);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_EulerTotient10()
    {
        long n = 2905;

        long expected = 1968;

        long actual = Atbmtt.MyMath.ModulusMath.EulerTotient(n);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_Euler()
    {
        long baseValue = 3;
        long exponent = 4;
        long modulus = 10;

        long expected = 1;

        long? actual = Atbmtt.MyMath.ModulusMath.Euler(baseValue, exponent, modulus);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_Euler2()
    {
        long baseValue = 24;
        long exponent = 3919;
        long modulus = 200;

        long expected = 24;

        long? actual = Atbmtt.MyMath.ModulusMath.Euler(baseValue, exponent, modulus);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_Euler3()
    {
        long baseValue = 6;
        long exponent = 9;
        long modulus = 15;

        long expected = 6;

        long? actual = Atbmtt.MyMath.ModulusMath.Euler(baseValue, exponent, modulus);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_Euler4()
    {
        long baseValue = 283;
        long exponent = 110;
        long modulus = 242;

        long expected = 1;

        long? actual = Atbmtt.MyMath.ModulusMath.Euler(baseValue, exponent, modulus);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_Euler5()
    {
        long baseValue = 283;
        long exponent = 1821;
        long modulus = 242;

        long expected = 19;

        long? actual = Atbmtt.MyMath.ModulusMath.Euler(baseValue, exponent, modulus);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_Euler6()
    {
        long baseValue = 4;
        long exponent = 8;
        long modulus = 15;

        long expected = 1;

        long? actual = Atbmtt.MyMath.ModulusMath.Euler(baseValue, exponent, modulus);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_Euler7()
    {
        long baseValue = 11;
        long exponent = 9;
        long modulus = 20;

        long expected = 11;

        long? actual = Atbmtt.MyMath.ModulusMath.Euler(baseValue, exponent, modulus);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_Euler8()
    {
        long baseValue = 12;
        long exponent = 402;
        long modulus = 25;

        long expected = 19;

        long? actual = Atbmtt.MyMath.ModulusMath.Euler(baseValue, exponent, modulus);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_ModExp8()
    {
        long baseValue = 12;
        long exponent = 402;
        long modulus = 25;

        long expected = 19;

        long? actual = Atbmtt.MyMath.ModulusMath.ModExp(baseValue, exponent, modulus);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_ModExp10()
    {
        long baseValue = 95;
        long exponent = 783;
        long modulus = 323;

        long expected = 114;

        long? actual = Atbmtt.MyMath.ModulusMath.ModExp(baseValue, exponent, modulus);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_ModChineseTheorem1()
    {
        long baseValue = 95;
        long exponent = 783;
        long modulus = 323;

        long expected = 114;

        long actual = Atbmtt.MyMath.ModulusMath.ModExpChineseRemainder(baseValue, exponent, modulus);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test_ModChineseTheorem2()
    {
        long baseValue = 101;
        long exponent = 59;
        long modulus = 323;

        long expected = 271;

        long actual = Atbmtt.MyMath.ModulusMath.ModExpChineseRemainder(baseValue, exponent, modulus);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void ChineseRemainderTheorem1()
    {
        long[] asValue = [6, 2, 4];
        long[] msValue = [11, 13, 487];

        long expected = 14614;

        long actual = Atbmtt.MyMath.ModulusMath.ChineseRemainderTheorem(msValue, asValue);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void ChineseRemainderTheorem2()
    {
        long[] asValue = [2, 3, 2];
        long[] msValue = [3, 5, 7];

        long expected = 23;

        long actual = Atbmtt.MyMath.ModulusMath.ChineseRemainderTheorem(msValue, asValue);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void ChineseRemainderTheorem3()
    {
        long[] asValue = [7, 15, 11];
        long[] msValue = [13, 17, 19];

        long expected = 2633;

        long actual = Atbmtt.MyMath.ModulusMath.ChineseRemainderTheorem(msValue, asValue);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestIsPrimitiveRoot1()
    {
        long a = 2;
        long n = 353;

        bool expected = false;

        bool actual = Atbmtt.MyMath.ModulusMath.IsPrimitiveRoot(a, n);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestIsPrimitiveRoot2()
    {
        long a = 3;
        long n = 353;

        bool expected = true;

        bool actual = Atbmtt.MyMath.ModulusMath.IsPrimitiveRoot(a, n);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestIsPrimitiveRoot3()
    {
        long a = 3;
        long n = 499;

        bool expected = false;

        bool actual = Atbmtt.MyMath.ModulusMath.IsPrimitiveRoot(a, n);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestIsPrimitiveRoot4()
    {
        long a = 3;
        long n = 311;

        bool expected = false;

        bool actual = Atbmtt.MyMath.ModulusMath.IsPrimitiveRoot(a, n);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestDiscreteLogarithm1()
    {
        long baseVal = 3;
        long elem = 5;
        long mod = 7;
        long expected = 5;

        long actual = Atbmtt.MyMath.ModulusMath.DiscreteLogarithm(baseVal, elem, mod);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestDiscreteLogarithm2()
    {
        long baseVal = 3;
        long elem = 6;
        long mod = 7;
        long expected = 3;

        long actual = Atbmtt.MyMath.ModulusMath.DiscreteLogarithm(baseVal, elem, mod);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestDiscreteLogarithm3()
    {
        long baseVal = 2;
        long elem = 9;
        long mod = 13;
        long expected = 8;

        long actual = Atbmtt.MyMath.ModulusMath.DiscreteLogarithm(baseVal, elem, mod);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestDiscreteLogarithm4()
    {
        long baseVal = 2;
        long elem = 5;
        long mod = 13;
        long expected = 9;

        long actual = Atbmtt.MyMath.ModulusMath.DiscreteLogarithm(baseVal, elem, mod);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestDiscreteLogarithm5()
    {
        long baseVal = 5;
        long elem = 2;
        long mod = 17;
        long expected = 6;

        long actual = Atbmtt.MyMath.ModulusMath.DiscreteLogarithm(baseVal, elem, mod);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestA()
    {
        long a = 73;
        long b = 67;
        long x = 498;
        long y = 582;
        long n = 269;

        long expectedA1 = 148;
        long expectedA2 = 102;
        long expectedA3 = 185;
        long expectedA4 = 117;   
        long expectedA5 = 99;

        long actualA1 = Atbmtt.MyMath.ModulusMath.A1(a, b, x, y, n);
        long actualA2 = Atbmtt.MyMath.ModulusMath.A2(a, b, x, y, n);
        long actualA3 = Atbmtt.MyMath.ModulusMath.A3(a, b, x, y, n);
        long actualA4 = Atbmtt.MyMath.ModulusMath.A4(b, y, n);
        long actualA5 = Atbmtt.MyMath.ModulusMath.A5(a, b, x, y, n);


        Assert.AreEqual(expectedA1, actualA1);
        Assert.AreEqual(expectedA2, actualA2);
        Assert.AreEqual(expectedA3, actualA3);
        Assert.AreEqual(expectedA4, actualA4);
        Assert.AreEqual(expectedA5, actualA5);
    }
}
