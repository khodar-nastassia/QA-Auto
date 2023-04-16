using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Comparer
{
    internal class LastNameComparer : IComparer<BankClient>
    {
        public int Compare(BankClient? x, BankClient? y)
        {
            return x.Customer.LastName.CompareTo(y.Customer.LastName);
        }
    }
}
