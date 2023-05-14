using Homework;
using Homework.PaymentMeans;
using Homework.PaymentMeans.PaymentCards;
using System.Security.Cryptography.X509Certificates;

namespace HomeworkTests;

[TestClass]
public class BankClientTests
{
    [TestMethod]
    public void TestMethodEqualsPositive()
    {
        var address = new Address("BY", "Minsk", "Voli", 1, 1);
        var customer = new Customer("Ivan", "Petrov", address, 123456789);
        var bitCoin = new BitCoin(10);
        var debitCard = new DebitCard(123, null, customer, 111, 100);
        var cashBackCard = new CashBackCard(1, null, customer, 1, 1, 40);

        var paymentMeans = new List<PaymentMean> {
        bitCoin,
        debitCard,
        cashBackCard };

        var client1 = new BankClient(customer, "individual", paymentMeans);
        var client2 = new BankClient(customer, "individual", paymentMeans);

        Assert.AreEqual(client1, client2);
    }
    [TestMethod]
    public void TestMethodToString()
    {
        var address = new Address("BY", "Minsk", "Voli", 1, 1);
        var customer = new Customer("Ivan", "Petrov", address, 123456789);
        var bitCoin = new BitCoin(10);
        var debitCard = new DebitCard(123, null, customer, 111, 100);
        var cashBackCard = new CashBackCard(1, null, customer, 1, 1, 40);
        var paymentMeans = new List<PaymentMean> {
        bitCoin,
        debitCard,
        cashBackCard };
        var client = new BankClient(customer, "individual", paymentMeans);

        string expectedResult = "Petrov- 3";
        string actualResult = client.ToString();

        Assert.AreEqual(expectedResult, actualResult);
    }

    [TestMethod]
    public void TestMethodPayPositive()
    {
        var address = new Address("BY", "Minsk", "Voli", 1, 1);
        var customer = new Customer("Ivan", "Petrov", address, 123456789);
        var bitCoin = new BitCoin(10);
        var debitCard = new DebitCard(123, null, customer, 111, 100);
        var cashBackCard = new CashBackCard(1, null, customer, 1, 1, 40);
        var paymentMeans = new List<PaymentMean> {
        bitCoin,
        debitCard,
        cashBackCard };
        var client = new BankClient(customer, "individual", paymentMeans);
        bool expectedResult = true;
        bool actualResult = client.Pay(20);

        //Assert.AreEqual(expectedResult, actualResult);
        Assert.IsTrue(expectedResult == actualResult);
    }

    [TestMethod]
    public void TestMethodPayNegative()
    {
        var address = new Address("BY", "Minsk", "Voli", 1, 1);
        var customer = new Customer("Ivan", "Petrov", address, 123456789);
        var bitCoin = new BitCoin(10);
        var debitCard = new DebitCard(123, null, customer, 111, 100);
        var cashBackCard = new CashBackCard(1, null, customer, 1, 1, 40);
        var paymentMeans = new List<PaymentMean>
        {
            bitCoin,
            debitCard,
            cashBackCard };

        var client = new BankClient(customer, "individual", paymentMeans);

        bool expectedResult = false;
        bool actualResult = client.Pay(200);

        //Assert.AreEqual(expectedResult, actualResult);
        Assert.IsTrue(expectedResult == actualResult);

    }

    [TestMethod]
    public void TestMethodGetMaxBalance()
    {
        var address = new Address("BY", "Minsk", "Voli", 1, 1);
        var customer = new Customer("Ivan", "Petrov", address, 123456789);
        var bitCoin = new BitCoin(10);
        var debitCard = new DebitCard(123, null, customer, 111, 100);
        var cashBackCard = new CashBackCard(1, null, customer, 1, 1, 40);
        var paymentMeans = new List<PaymentMean>
        {
            bitCoin,
            debitCard,
            cashBackCard };

        var client = new BankClient(customer, "individual", paymentMeans);

        float expectedResult = 100;
        float actualResult = client.GetMaxBalance();

        //Assert.AreEqual(expectedResult, actualResult);
        Assert.IsTrue(expectedResult == actualResult);
    }

    [TestMethod]
    public void TestMethodGetAllMoney()
    {
        var address = new Address("BY", "Minsk", "Voli", 1, 1);
        var customer = new Customer("Ivan", "Petrov", address, 123456789);
        var bitCoin = new BitCoin(10);
        var debitCard = new DebitCard(123, null, customer, 111, 100);
        var cashBackCard = new CashBackCard(1, null, customer, 1, 1, 40);
        var paymentMeans = new List<PaymentMean>
        {
            bitCoin,
            debitCard,
            cashBackCard };

        var client = new BankClient(customer, "individual", paymentMeans);

        float expectedResult = 150;
        float actualResult = client.GetAllMoney();

        //Assert.AreEqual(expectedResult, actualResult);
        Assert.IsTrue(expectedResult == actualResult);
    }

    [TestMethod]
    [ExpectedException(typeof(Exception))]
    public void ClientInfoNullTest()
    {

        var address = new Address("BY", "Minsk", "Voli", 1, 1);
        var customer = new Customer("Ivan", "Petrov", address, 123456789);
        var bitCoin = new BitCoin(10);
        var debitCard = new DebitCard(123, null, customer, 111, 100);
        var cashBackCard = new CashBackCard(1, null, customer, 1, 1, 40);
        var paymentMeans = new List<PaymentMean>
        {
            bitCoin,
            debitCard,
            cashBackCard };

        _ = new BankClient(customer, null, paymentMeans);
    }
}