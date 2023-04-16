using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Comparer
{
    internal class AdressCityComparer : IComparer<BankClient>
    {
        public int Compare(BankClient? x, BankClient? y)
        {
            return x.Customer.Address.City.CompareTo(y.Customer.Address.City);

        }
    }
}
