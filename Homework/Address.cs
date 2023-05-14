namespace Homework;

public class Address
{
    private string _state;
    private string _city;
    private string _street;

    public string State {
        get => _state;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new Exception("State cannot be null or empty");
            }
            _state = value;
        }
    }

    public string City {
        get => _city;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new Exception("City cannot be null or empty");
            }
            _city = value;
        }
    }

    public string Street {
        get => _street;
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new Exception("Street cannot be null or empty");
            }
            _street = value;
        }
    }
    public int HouseNumber { get; set; }
    public int FlatNumber { get; set; }

    public Address(string state, string city, string street, int house, int flat)
    {
        State = state;
        City = city;
        Street = street;
        if (house <= 0 || flat <= 0)
        {
            throw new ArgumentException("Wrong numbers of house and/or of flat ");
        }
        HouseNumber = house;
        FlatNumber = flat;
    }

    public override string ToString() => State + ", " + City + ", " + Street + ", " + HouseNumber + ", " + FlatNumber;

    public override bool Equals(object? obj)
    {
        if (obj is Address address)
        {
            return address.State == State &&
                   address.City == City &&
                   address.Street == Street &&
                   address.HouseNumber == HouseNumber&&
                   address.FlatNumber == FlatNumber; ;
        }
        return false;
    }
}
