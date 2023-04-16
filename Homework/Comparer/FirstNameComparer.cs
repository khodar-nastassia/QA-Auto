using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Comparer
{
    internal class FirstNameComparer : IComparer<BankClient>
    {
        public int Compare(BankClient? x, BankClient? y)
        {
            return x.Customer.FirstName.CompareTo(y.Customer.FirstName);
        }
    }
}
