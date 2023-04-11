using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    internal class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Adress Adress { get; set; }
        public int PhoneNumber { get; set; }

        public Customer(string firstname, string lastname, Adress adress, int phonenumber)
        {
            FirstName = firstname;
            LastName = lastname;
            Adress = adress;
            PhoneNumber = phonenumber;
        }
        public override string ToString()
        {
            return FirstName + " " + LastName + "," + Adress + ", " + PhoneNumber;
        }
    }
}
