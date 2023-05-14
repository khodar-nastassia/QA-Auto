namespace Homework.Exceptions;

public class WrongDate: Exception
{
    public WrongDate(string message)
        : base(message) { }
}
