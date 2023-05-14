using System;
using System.Collections.Generic;
using System.Linq;
namespace Homework.Comparer;

internal class MaxBalanceComparer : IComparer<BankClient>
{
    public int Compare(BankClient? x, BankClient? y)
    {
        Helper.CheckData(x, y);
        return x.GetMaxBalance().CompareTo(y.GetMaxBalance());
    }
}
