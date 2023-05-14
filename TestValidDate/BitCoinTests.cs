using Homework.PaymentMeans;

namespace HomeworkTests;

[TestClass]
public class BitCoinTests
{
    [TestMethod]
    public void TestMethodToString()
    {
        var bitCoin = new BitCoin(100);

        string expectedResult = "BitCoin balance is 100";
        string actualResult = bitCoin.ToString();

        Assert.IsTrue(expectedResult == actualResult);
    }

    [TestMethod]
    public void TestMethodEqualsPositive()
    {
        var bitCoin1 = new BitCoin(100);
        var bitCoin2 = new BitCoin(100);

        Assert.AreEqual(bitCoin1, bitCoin2);
    }

    [TestMethod]
    public void TestMethodEqualsNegative()
    {
        var bitCoin1 = new BitCoin(100);
        var bitCoin2 = new BitCoin(101);

        Assert.AreNotEqual(bitCoin1, bitCoin2);
    }

    [TestMethod]
    public void TestMethodMakePayment()
    {
        var bitCoin = new BitCoin(100);

        var expectedResult = 90;
        var actualResult = bitCoin.MakePayment(10);

        Assert.IsTrue(expectedResult == actualResult);
    }

    [TestMethod]
    public void TestMethodTopUp()
    {
        var bitCoin = new BitCoin(100);

        var expectedResult = 110;
        var actualResult = bitCoin.TopUp(10);

        Assert.IsTrue(expectedResult == actualResult);
    }
}
