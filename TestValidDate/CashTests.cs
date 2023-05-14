using Homework.PaymentMeans;

namespace HomeworkTests;

[TestClass]
public class CashTests
{

    [TestMethod]
    public void TestMethodToString()
    {
        var cash = new Cash(100);

        string expectedResult = "Cash balance is 100";
        string actualResult = cash.ToString();

        Assert.IsTrue(expectedResult == actualResult);
    }

    [TestMethod]
    public void TestMethodEqualsPositive()
    {
        var cash1 = new Cash(100);
        var cash2 = new Cash(100);

        Assert.AreEqual(cash1, cash2);
    }

    [TestMethod]
    public void TestMethodEqualsNegative()
    {
         var cash1 = new Cash(100);
         var cash2 = new Cash(101);

         Assert.AreNotEqual(cash1, cash2);
    }

    [TestMethod]
    public void TestMethodMakePayment()
    {
        var cash = new Cash(100);

        var expectedResult = 90;
        var actualResult = cash.MakePayment(10);

        Assert.IsTrue(expectedResult==actualResult);
    }

    [TestMethod]
    public void TestMethodTopUp()
    {
        var cash = new Cash(100);

        var expectedResult = 110;
        var actualResult = cash.TopUp(10);

        Assert.IsTrue(expectedResult == actualResult);
    }







}

