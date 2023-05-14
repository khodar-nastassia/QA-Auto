namespace Homework.PaymentMeans.PaymentCards;

public class CashBackCard : PaymentCard
{
    private float _cashBackCardPercent;

    public float CashBackCardPercent
    {
        get => _cashBackCardPercent;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("CashBackCardPercent cannot be 0");
            }
            _cashBackCardPercent = value;
        }
    }

    public CashBackCard(long cardNumber, ValidDate validDate, Customer cardHolder, int cardCCV, float cashBackCardPercent, float balance) :
        base(cardNumber, validDate, cardHolder, cardCCV, balance)
    {
        CashBackCardPercent = cashBackCardPercent;
    }

    public override string ToString() => "CashBackCardNumber = " + CardNumber +
                                         ", CashBackCardPercent = " + CashBackCardPercent +
                                         ", CashBackCardBalance = " + Balance; 

    public string GetFullInformation()
    {
        return string.Format("CashBackCardNumber: {0}, CardValidity: {1}, CashBackCardHolder: {2}, CCV: {3}, CashBackCardPercent: {4}, CashBackCardBalance: {5}",
            CardNumber, ValidDate, CardHolder.LastName, CardCCV, CashBackCardPercent, Balance);
    }

    public override float MakePayment(float amount)
    {
        Balance -= amount;
        Balance += amount * _cashBackCardPercent / 100;
        return Balance;
    }

    public override float TopUp(float amount)
    {
        Balance += amount;
        return Balance;
    }

    public override bool Equals(object? obj)
    {
        if (obj is CashBackCard)
        {
            CashBackCard cashBackCard = (CashBackCard)obj;
            return cashBackCard.CardNumber == CardNumber &&
                   cashBackCard.ValidDate == ValidDate &&
                   cashBackCard.CardHolder == CardHolder &&
                   cashBackCard.CardCCV == CardCCV &&
                   cashBackCard.CashBackCardPercent == CashBackCardPercent &&
                   cashBackCard.Balance == Balance;
        }
        return false;
    }
}
