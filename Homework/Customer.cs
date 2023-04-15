using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    internal class Customer
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public Address Address { get; set; }
        public int PhoneNumber { get; set; }
        public Customer(string firstName, string lastName, Address address, int phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            PhoneNumber = phoneNumber;
        }
    }
    
}
