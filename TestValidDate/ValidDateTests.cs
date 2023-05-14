using Homework;
using Homework.Exceptions;

namespace HomeworkTests;

[TestClass]
public class ValidDateTests
{
    [TestMethod]
    public void TestMethodToString()
    {
        var date = new ValidDate(11, 23);

        string expectedResult = "11/23";
        string actualResult = date.ToString();

        Assert.AreEqual(expectedResult, actualResult);
    }

    [TestMethod]
    public void TestMethodEqualsPositive()
    {
        var date1 = new ValidDate(11, 23);
        var date2 = new ValidDate(11, 23);

        Assert.AreEqual(date1, date2);
    }

    [TestMethod]
    [DataRow(11, 24)]
    [DataRow(12, 23)]
    public void TestMethodEqualsNegative(int month,int year)
    {
        var date1 = new ValidDate(11, 23);
        var date2 = new ValidDate(month,year);

        Assert.AreNotEqual(date1, date2);
    }

    [TestMethod]
    [ExpectedException(typeof(WrongDate))]
    public void NegativeMonthTest()
    {
        _ = new ValidDate(13, 23);
    }

    [TestMethod]
    [ExpectedException(typeof(WrongDate))]
    public void NegativeYearTest()
    {
        _ = new ValidDate(11, -1);
    }
}