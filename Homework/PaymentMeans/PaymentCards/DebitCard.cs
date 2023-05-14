namespace Homework.PaymentMeans.PaymentCards;

public class DebitCard: PaymentCard
{
    public DebitCard(long cardNumber, ValidDate validDate,Customer cardHolder, int cardCCV,float balance) :
                     base(cardNumber, validDate, cardHolder, cardCCV, balance)
    { }

    public override string ToString() => "DebetCardNumber = " + CardNumber + ", DebetCardBalance = " + Balance;

    public string GetFullInformation()
    {
        return string.Format("DebetCardNumber: {0}, CardValidity: {1}, DebetCardHolder: {2}, CCV: {3}, DebetCardBalance: {4}",
            CardNumber, ValidDate, CardHolder.LastName, CardCCV, Balance);
    }

    public override float MakePayment(float amount)
    {
        Balance -= amount;
        return Balance;
    }

    public override float TopUp(float amount)
    {
        Balance += amount;
        return Balance;
    }

    public override bool Equals(object? obj)
    {
        if (obj is DebitCard)
        {
            DebitCard debitCard = (DebitCard)obj;
            return debitCard.CardNumber == CardNumber &&
                   debitCard.ValidDate == ValidDate &&
                   debitCard.CardHolder == CardHolder &&
                   debitCard.CardCCV == CardCCV &&
                   debitCard.Balance == Balance;
        }
        return false;
    }
}
