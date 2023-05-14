namespace Homework.Comparer;

internal class FirstNameComparer : IComparer<BankClient>
{
    public int Compare(BankClient? x, BankClient? y)
    {
        Helper.CheckData(x, y);
        return x.Customer.FirstName.CompareTo(y.Customer.FirstName);
    }
}
