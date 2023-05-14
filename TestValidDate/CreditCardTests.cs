using Homework.PaymentMeans.PaymentCards;
using Homework;

namespace HomeworkTests;

[TestClass]
public class CreditCardTests
{
    [TestMethod]
    public void TestMethodToString()
    {
        var address1 = new Address("BY", "Minsk", "Voli", 1, 1);
        var customer = new Customer("Ivan", "Petrov", address1, 123456789);
        var date = new ValidDate(11, 11);
        var creditCard = new CreditCard(1, date, customer, 1, 10, 100);

        string expectedResult = "CreditCardNumber = 1, CreditCardPercent = 10, CreditCardLimit = 100";
        string actualResult = creditCard.ToString();

        Assert.IsTrue(expectedResult == actualResult);
    }

    [TestMethod]
    public void TestMethodEqualsPositive()
    {
        var address1 = new Address("BY", "Minsk", "Voli", 1, 1);
        var customer = new Customer("Ivan", "Petrov", address1, 123456789);
        var date = new ValidDate(11, 11);
        var creditCard1 = new CreditCard(1, date, customer, 1, 10, 100);
        var creditCard2 = new CreditCard(1, date, customer, 1, 10, 100);

        Assert.AreEqual(creditCard1, creditCard2);
    }

    [TestMethod]
    public void TestMethodMakePayment()
    {
        var address1 = new Address("BY", "Minsk", "Voli", 1, 1);
        var customer = new Customer("Ivan", "Petrov", address1, 123456789);
        var date = new ValidDate(11, 11);
        var creditCard1 = new CreditCard(1, date, customer, 1,10, 100);

        var expectedResult = 89;
        var actualResult = creditCard1.MakePayment(10);

        Assert.IsTrue(expectedResult == actualResult);
    }

    [TestMethod]
    public void TestMethodTopUp()
    {
        var address1 = new Address("BY", "Minsk", "Voli", 1, 1);
        var customer = new Customer("Ivan", "Petrov", address1, 123456789);
        var date = new ValidDate(11, 11);
        var creditCard1 = new CreditCard(1, date, customer, 1,10, 100);

        var expectedResult = 90;
        var actualResult = creditCard1.TopUp(10);

        Assert.IsTrue(expectedResult == actualResult);
    }

    [TestMethod]
    public void TestMethodGetFullInfo()
    {
        var address1 = new Address("BY", "Minsk", "Voli", 1, 1);
        var customer = new Customer("Ivan", "Petrov", address1, 123456789);
        var date = new ValidDate(11, 11);
        var creditCard = new CreditCard(1, date, customer, 1, 10, 100);

        string expectedResult = "CreditCardNumber: 1, CardValidity: 11/11, CreditCardHolder: Petrov, CCV: 1, CreditCardPercent: 10, CreditCardLimit: 100";
        string actualResult = creditCard.GetFullInformation();

        Assert.AreEqual(expectedResult, actualResult);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void NegativePercentTest()
    {
        var address1 = new Address("BY", "Minsk", "Voli", 1, 1);
        var customer = new Customer("Ivan", "Petrov", address1, 123456789);
        var date = new ValidDate(11, 11);
        _ = new CreditCard(1, date, customer, 1, 0, 100);
    }
}

