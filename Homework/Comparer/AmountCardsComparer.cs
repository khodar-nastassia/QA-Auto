namespace Homework.Comparer;

internal class AmountCardsComparer : IComparer<BankClient>
{
    public int Compare(BankClient? x, BankClient? y)
    {
        Helper.CheckData(x, y);
        return x.PaymentMeans.Count.CompareTo(y.PaymentMeans.Count);
    }
}

