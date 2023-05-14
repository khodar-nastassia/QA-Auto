using Homework.Exceptions;

namespace Homework;

public class ValidDate
{
    public int Year { get; private set; }
    public int Month { get; private set; }

    public ValidDate(int month, int year)
    {
        if (year <= 0 || (month <= 0 || month >= 13))
        {
            throw new WrongDate("Wrong parametrs in ValidDate");
        }
        Year = year;
        Month = month;
    }

    public override string ToString() => Month + "/" + Year;

    public override bool Equals(object? obj)
    {
        if (obj is ValidDate date)
        {
            return date.Month == Month &&
                   date.Year == Year;
        }
        return false;
    }
}
