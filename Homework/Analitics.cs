using Homework.Comparer;

namespace Homework;

internal class Analitics
{
    public List<BankClient> BankClients { get; set; }

    public Analitics(List <BankClient> bankClients)
    {
        BankClients = bankClients;
    }

    public void SortBankClients(string comparer)
    {
        BankClients.Sort(GetComparer(comparer));
    }

    private IComparer<BankClient> GetComparer(string comparer)
    {
        IComparer<BankClient> result;
        result = comparer switch
        {
            "City" => new AdressCityComparer(),
            "Amount of cards" => new AmountCardsComparer(),
            "LastName" => new LastNameComparer(),
            "TotalBalance" => new TotalBalanceComparer(),
            "MaxBalance" => new MaxBalanceComparer(),
            _ => new FirstNameComparer()
        };
        return result;
    }
}
