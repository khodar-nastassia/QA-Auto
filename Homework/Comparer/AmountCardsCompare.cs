using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Comparer
{
    internal class AmountCardsCompare : IComparer<BankClient>
    {
        public int Compare(BankClient? x, BankClient? y)
        {
            return x.PaymentMeans.Count.CompareTo(y.PaymentMeans.Count);
        }
    }
}
    
