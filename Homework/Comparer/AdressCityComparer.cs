namespace Homework.Comparer;

internal class AdressCityComparer : IComparer<BankClient>
{
    public int Compare(BankClient? x, BankClient? y)
    {
        Helper.CheckData(x, y);
        return x.Customer.Address.City.CompareTo(y.Customer.Address.City);
    }
}
