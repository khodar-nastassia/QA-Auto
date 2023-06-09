﻿namespace Homework.Comparer;

internal class TotalBalanceComparer : IComparer<BankClient>
{
    public int Compare(BankClient? x, BankClient? y)
    {
        Helper.CheckData(x, y);
        return x.GetAllMoney().CompareTo(y.GetAllMoney());
    }
}
