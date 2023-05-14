using Homework;

namespace HomeworkTests;

[TestClass]
public class AddressTests
{
    [TestMethod]
    public void TestMethodToString()
    {
        var address = new Address("BY", "Minsk", "Voli", 1, 1);

        string expectedResult = "BY, Minsk, Voli, 1, 1";
        string actualResult = address.ToString();

        Assert.AreEqual(expectedResult, actualResult);
    }

    [TestMethod]
    public void TestMethodEqualsPositive()
    {
        var address1 = new Address("BY", "Minsk", "Voli", 1, 1);
        var address2 = new Address("BY", "Minsk", "Voli", 1, 1);

        Assert.AreEqual(address1, address2);
    }

    [TestMethod]
    [DataRow("BY", "Minsk", "Voli", 1, 2)]
    [DataRow("BY", "Minsk", "Voli", 2, 1)]
    [DataRow("BY", "Minsk", "VolI", 1, 1)]
    [DataRow("BY", "Minsk ", "Voli", 1, 1)]
    [DataRow("By", "Minsk", "Voli", 1, 1)]
    public void TestMethodEqualsNegative(string state, string city, string street, int house, int flat)
    {
        var address1 = new Address("BY", "Minsk", "Voli", 1, 1);
        var address2 = new Address(state, city, street, house, flat);

        Assert.AreNotEqual(address1, address2);
    }

    [TestMethod]
    [ExpectedException(typeof(Exception))]
    public void StateNullTest()
    {
        _ = new Address(null, "Minsk", "Voli", 1, 1);
    }

    [TestMethod]
    [ExpectedException(typeof(Exception))]
    public void CityNullTest()
    {
        _ = new Address("BY", null, "Voli", 1, 1);
    }

    [TestMethod]
    [ExpectedException(typeof(Exception))]
    public void StreetNullTest()
    {
        _ = new Address("By", "Minsk", null, 1, 1);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void NegativeHouseTest()
    {
        _ = new Address("By", "Minsk", "Voli", -1, 1);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void NegativeFlatTest()
    {
        _ = new Address("By", "Minsk", "Voli", 1, -1);
    }
}