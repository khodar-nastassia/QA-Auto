using Homework.PaymentMeans;
using Homework.PaymentMeans.PaymentCards;

namespace Homework;

public class BankClient
{
    private string _clientInfo;

    public Customer Customer { get; set; }
    public string ClientInfo { 
        get => _clientInfo;
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new Exception("ClientInfo cannot be null or empty");
            _clientInfo = value;
        }
    }
    public List<PaymentMean> PaymentMeans {get ;set;}

    public BankClient(Customer customer, string clientInfo, List<PaymentMean> paymentMeans)
    {
        Customer = customer;
        ClientInfo = clientInfo;
        PaymentMeans = paymentMeans;
    }

    public void AddPaymentMean(PaymentMean mean)
    {
        if (mean != null)
        {
            PaymentMeans.Add(mean);
        }
    }

    public float GetAllMoney()
    {
        float allMoney = 0;
        foreach (var item in PaymentMeans )
        {
            item.GetBalance();
            allMoney += item.GetBalance();
        }
        return allMoney;
    }

    public float GetMaxBalance()
    {
        float maxBalance = 0;
        foreach (var item in PaymentMeans)
        {
            if (item.GetBalance() > maxBalance)
            {
                maxBalance = item.GetBalance();
            }
        }
        return maxBalance;
    }

    public bool Pay(float amount)
    {
        List<Type> types = new List<Type>
        {
            typeof(Cash),
            typeof(CashBackCard),
            typeof(DebitCard),
            typeof(CreditCard),
            typeof(BitCoin)
        };

        foreach (var type in types)
        {
            var list = PaymentMeans.Where(x => x.GetType() == type).ToList(); //create list of type
            if (TryPay(list, amount))
            {
                return true;
            }
        }
        return false;
    }

    private static bool TryPay(List<PaymentMean> list, float amount)
    {
        foreach (PaymentMean item in list)
        {
            if (item.CheckBalanceSufficiency(amount))
            {
                item.MakePayment(amount);
                return true;
            }
        }
        return false;
    }

    public override string ToString()
    {
        return Customer.LastName + "- " + PaymentMeans.Count;
    }

    // Клиенты считаются равными, есть совпадают их имена, адреса и общее количество денег на всех счетах
    public override bool Equals(object? obj)
    {
        if (obj is BankClient client)
        {
            return client.Customer == Customer &&
                   client.GetAllMoney() == GetAllMoney();
        }
        return false;
    }
}
