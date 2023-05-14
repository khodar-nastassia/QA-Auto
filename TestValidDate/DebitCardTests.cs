using Homework.PaymentMeans.PaymentCards;
using Homework;

namespace HomeworkTests;

[TestClass]
public class DebitCardTests
{
    [TestMethod]
    public void TestMethodToString()
    {
        var address1 = new Address("BY", "Minsk", "Voli", 1, 1);
        var customer = new Customer("Ivan", "Petrov", address1, 123456789);
        var date = new ValidDate(11, 11);
        var debitCard = new DebitCard(1,date,customer,1,100);

        string expectedResult = "DebetCardNumber = 1, DebetCardBalance = 100";
        string actualResult = debitCard.ToString();

        Assert.IsTrue(expectedResult == actualResult);
    }

    [TestMethod]
    public void TestMethodEqualsPositive()
    {
        var address1 = new Address("BY", "Minsk", "Voli", 1, 1);
        var customer = new Customer("Ivan", "Petrov", address1, 123456789);
        var date = new ValidDate(11, 11);
        var debitCard1 = new DebitCard(1, date, customer, 1, 100);
        var debitCard2 = new DebitCard(1, date, customer, 1, 100);

        Assert.AreEqual(debitCard1, debitCard2);
    }

    [TestMethod]
    public void TestMethodMakePayment()
    {
        var address1 = new Address("BY", "Minsk", "Voli", 1, 1);
        var customer = new Customer("Ivan", "Petrov", address1, 123456789);
        var date = new ValidDate(11, 11);
        var debitCard1 = new DebitCard(1, date, customer, 1, 100);

        var expectedResult = 90;
        var actualResult = debitCard1.MakePayment(10);

        Assert.IsTrue(expectedResult == actualResult);
    }

    [TestMethod]
    public void TestMethodTopUp()
    {
        var address1 = new Address("BY", "Minsk", "Voli", 1, 1);
        var customer = new Customer("Ivan", "Petrov", address1, 123456789);
        var date = new ValidDate(11, 11);
        var debitCard1 = new DebitCard(1, date, customer, 1, 100);

        var expectedResult = 110;
        var actualResult = debitCard1.TopUp(10);

        Assert.IsTrue(expectedResult == actualResult);
    }

    [TestMethod]
    public void TestMethodGetFullInfo()
    {
        var address1 = new Address("BY", "Minsk", "Voli", 1, 1);
        var customer = new Customer("Ivan", "Petrov", address1, 123456789);
        var date = new ValidDate(11, 11);
        var debitCard = new DebitCard(1, date, customer, 1, 100);

        string expectedResult = "DebetCardNumber: 1, CardValidity: 11/11, DebetCardHolder: Petrov, CCV: 1, DebetCardBalance: 100";
        string actualResult = debitCard.GetFullInformation();

        Assert.AreEqual(expectedResult,actualResult);
    }
}
