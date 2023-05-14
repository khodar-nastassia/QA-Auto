using Homework.Exceptions;

namespace Homework;

public class Customer
{
    private string _firstName;
    private string _lastName;
    private Address _address;

    //3. Добавить валидацию, имя клиента не могут быть null или пустыми, имя клиента не может превышать 50 символов.
    public string FirstName
    {
        get => _firstName;
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new Exception("First name cannot be null or empty");

            if (value.Length > 50)
                throw new Exception("First name cannot be longer than 50 characters");
            _firstName = value;

        }
    }
    public string LastName
    {
        get => _lastName;
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new Exception("Last name cannot be null or empty");

            if (value.Length > 50)
                throw new Exception("Last name cannot be longer than 50 characters");
            _lastName = value;
        }
    }
    public Address Address
    {
        get => _address;
        set
        {
            _address = value ?? throw new Exception("Address cannot be null");
        }
    }
    public int PhoneNumber { get;set; }

    public Customer(string firstName, string lastName, Address address, int phoneNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        Address = address;
        if (phoneNumber <= 0)
        {
            throw new WrongPhoneNumber("Wrong Phone number");
        }
        PhoneNumber = phoneNumber;
    }

    public override bool Equals(object? obj)
    {
        if (obj is Customer customer)
        {
            return customer.FirstName == FirstName &&
                   customer.LastName == LastName &&
                   customer.Address == Address;
        }
        return false;
    }
}

