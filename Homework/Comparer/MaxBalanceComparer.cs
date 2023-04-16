using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Comparer
{
    internal class MaxBalanceComparer : IComparer<BankClient>
    {
        public int Compare(BankClient? x, BankClient? y)
        {            
            return x.GetMaxBalance(x).CompareTo(y.GetMaxBalance(y));
        }
    }
}
