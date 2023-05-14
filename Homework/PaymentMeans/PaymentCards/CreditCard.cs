namespace Homework.PaymentMeans.PaymentCards;

public class CreditCard : PaymentCard
{
    private float _creditCardPercent;

    public float CreditCardPercent
    {
        get => _creditCardPercent;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("CashBackCardPercent cannot be 0");
            }
            _creditCardPercent = value;
        }
    }

    public CreditCard(long cardNumber, ValidDate validDate, Customer cardHolder, int cardCCV, float creditCardPercent, float balance) :
        base(cardNumber, validDate, cardHolder, cardCCV, balance)
    {
        CreditCardPercent = creditCardPercent;
    }

    public override string ToString() => "CreditCardNumber = " + CardNumber + ", CreditCardPercent = " + CreditCardPercent + ", CreditCardLimit = " + Balance;

    public string GetFullInformation()
    {
        return string.Format("CreditCardNumber: {0}, CardValidity: {1}, CreditCardHolder: {2}, CCV: {3}, CreditCardPercent: {4}, CreditCardLimit: {5}",
            CardNumber, ValidDate, CardHolder.LastName, CardCCV, CreditCardPercent, Balance);
    }

    public override float MakePayment(float amount)
    {
        Balance -= amount;
        Balance -= amount * CreditCardPercent / 100;
        return Balance;
    }

    public override float TopUp(float amount)
    {
        Balance -= amount;
        return Balance;
    }

    public override bool Equals(object? obj)
    {
        if (obj is CreditCard creditCard)
        {
            return creditCard.CardNumber == CardNumber &&
                   creditCard.ValidDate == ValidDate &&
                   creditCard.CardHolder == CardHolder &&
                   creditCard.CardCCV == CardCCV &&
                   creditCard.CreditCardPercent == CreditCardPercent &&
                   creditCard.Balance == Balance;
        }
        return false;
    }

    public new bool CheckBalanceSufficiency(float amount) => Balance >= amount + (amount * CreditCardPercent / 100);
}
