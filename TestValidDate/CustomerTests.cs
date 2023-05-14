using Homework;
using Homework.Exceptions;

namespace HomeworkTests;

[TestClass]
public class CustomerTests
{
    [TestMethod]
    public void TestMethodEqualsPositive()
    {
        var address1 = new Address("BY", "Minsk", "Voli", 1, 1);
        var customer1 = new Customer("Ivan", "Petrov", address1, 123456789);
        var customer2 = new Customer("Ivan", "Petrov", address1, 123456789);

        Assert.AreEqual(customer1, customer2);
    }

    [TestMethod]
    [DataRow("ivan", "Petrov", "BY", "Minsk", "Voli", 1, 1, 123456789)]
    [DataRow("Ivan", "petrov", "BY", "Minsk", "Voli", 1, 1, 123456789)]
    [DataRow("Ivan", "Petrov ", "pl", "minsk", "voli", 2, 2, 123456789)]

    public void TestMethodEqualsNegative(string firstName, string lastName, string country, string city, string street, int houseNumber,
        int flatNumber, int phoneNumber)
    {
        var address = new Address(country, city, street, houseNumber, flatNumber);
        var customer1 = new Customer("Ivan", "Petrov", address, 123456789);
        var customer2 = new Customer(firstName, lastName, address, phoneNumber);

        Assert.AreNotEqual(customer1, customer2);
    }

    [TestMethod]
    [ExpectedException(typeof(WrongPhoneNumber))]
    public void NegativePhoneNumberTest()
    {
        var address1 = new Address("BY", "Minsk", "Voli", 1, 1);
        _ = new Customer("Ivan", "Petrov", address1, 0);
    }

    [TestMethod]
    [ExpectedException(typeof(Exception))]
    public void LastNameNullTest()
    {
        var address1 = new Address("BY", "Minsk", "Voli", 1, 1);
        _ = new Customer("Ivan", null, address1, 123456789);
    }

    [TestMethod]
    [ExpectedException(typeof(Exception))]
    public void LastNameLengthTest()
    {
        var address1 = new Address("BY", "Minsk", "Voli", 1, 1);
        _ = new Customer("Ivan", "PetrovPetrovPetrovPetrovPetrovPetrovPetrovPetrovPet", address1, 123456789);
    }

    [TestMethod]
    [ExpectedException(typeof(Exception))]
    public void FirstNameNullTest()
    {
        var address1 = new Address("BY", "Minsk", "Voli", 1, 1);
        _ = new Customer(null, "Petrov", address1, 123456789);
    }

    [TestMethod]
    [ExpectedException(typeof(Exception))]
    public void FirstNameLengthTest()
    {
        var address1 = new Address("BY", "Minsk", "Voli", 1, 1);
        _ = new Customer("IvanIvanIvanIvanIvanIvanIvanIvanIvanIvanIvanIvanIvan", "Petrov", address1, 123456789);
    }

    [TestMethod]
    [ExpectedException(typeof(Exception))]
    public void AddressNullTest()
    {
        _ = new Customer("Ivan", "Petrov", null, 123456789);
    }
}