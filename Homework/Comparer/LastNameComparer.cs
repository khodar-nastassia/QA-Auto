namespace Homework.Comparer;

internal class LastNameComparer : IComparer<BankClient>
{
    public int Compare(BankClient? x, BankClient? y)
    {
        Helper.CheckData(x, y);
        return x.Customer.LastName.CompareTo(y.Customer.LastName);
    }
}
