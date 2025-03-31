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
}