namespace Homework.Exceptions;

public class WrongPhoneNumber: Exception
{
    public WrongPhoneNumber(string message)
    : base(message) { }
}
