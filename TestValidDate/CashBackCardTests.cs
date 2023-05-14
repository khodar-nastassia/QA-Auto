using Homework.PaymentMeans.PaymentCards;
using Homework;

namespace HomeworkTests;

[TestClass]
public class CashBackCardTests
{
    [TestMethod]
    public void TestMethodToString()
    {
        var address1 = new Address("BY", "Minsk", "Voli", 1, 1);
        var customer = new Customer("Ivan", "Petrov", address1, 123456789);
        var date = new ValidDate(11, 11);
        var cashBackCard = new CashBackCard(1, date, customer, 1, 10, 100);

        string expectedResult = "CashBackCardNumber = 1, CashBackCardPercent = 10, CashBackCardBalance = 100";
        string actualResult = cashBackCard.ToString();

        Assert.IsTrue(expectedResult == actualResult);
    }

    [TestMethod]
    public void TestMethodEqualsPositive()
    {
        var address1 = new Address("BY", "Minsk", "Voli", 1, 1);
        var customer = new Customer("Ivan", "Petrov", address1, 123456789);
        var date = new ValidDate(11, 11);
        var cashBackCard1 = new CashBackCard(1, date, customer, 1, 10, 100);
        var cashBackCard2 = new CashBackCard(1, date, customer, 1, 10, 100);

        Assert.AreEqual(cashBackCard1, cashBackCard2);
    }

    [TestMethod]
    public void TestMethodMakePayment()
    {
        var address1 = new Address("BY", "Minsk", "Voli", 1, 1);
        var customer = new Customer("Ivan", "Petrov", address1, 123456789);
        var date = new ValidDate(11, 11);
        var cashBackCard1 = new CashBackCard(1, date, customer, 1, 10, 100);

        var expectedResult = 91;
        var actualResult = cashBackCard1.MakePayment(10);

        Assert.IsTrue(expectedResult == actualResult);
    }

    [TestMethod]
    public void TestMethodTopUp()
    {
        var address1 = new Address("BY", "Minsk", "Voli", 1, 1);
        var customer = new Customer("Ivan", "Petrov", address1, 123456789);
        var date = new ValidDate(11, 11);
        var cashBackCard1 = new CashBackCard(1, date, customer, 1, 10, 100);

        var expectedResult = 110;
        var actualResult = cashBackCard1.TopUp(10);

        Assert.IsTrue(expectedResult == actualResult);
    }

    [TestMethod]
    public void TestMethodGetFullInfo()
    {
        var address1 = new Address("BY", "Minsk", "Voli", 1, 1);
        var customer = new Customer("Ivan", "Petrov", address1, 123456789);
        var date = new ValidDate(11, 11);
        var cashBackCard = new CashBackCard(1, date, customer, 1, 10, 100);

        string expectedResult = "CashBackCardNumber: 1, CardValidity: 11/11, CashBackCardHolder: Petrov, CCV: 1, CashBackCardPercent: 10, CashBackCardBalance: 100";
        string actualResult = cashBackCard.GetFullInformation();

        Assert.AreEqual(expectedResult, actualResult);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void NegativePercentTest()
    {
        var address1 = new Address("BY", "Minsk", "Voli", 1, 1);
        var customer = new Customer("Ivan", "Petrov", address1, 123456789);
        var date = new ValidDate(11, 11);
        _ = new CashBackCard(1, date, customer, 1, 0, 100);
    }
}


