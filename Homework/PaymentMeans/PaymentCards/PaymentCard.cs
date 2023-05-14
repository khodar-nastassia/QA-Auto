namespace Homework.PaymentMeans.PaymentCards;

public abstract class PaymentCard: PaymentMean

{
    private long _cardNumber;

    public long CardNumber {
        get => _cardNumber;
        set
        {
            if (value <=0)
            {
                throw new Exception("CardNumber cannot be <0");
            }
            _cardNumber = value;
        }
    }

    public ValidDate ValidDate { get; }
    public Customer CardHolder { get; }
    public int CardCCV { get; }
    public PaymentCard(long cardNumber, ValidDate validDate, Customer cardHolder, int cardCCV, float balance): base(balance)
    {
        CardNumber = cardNumber;
        ValidDate = validDate;
        CardHolder = cardHolder;
        CardCCV = cardCCV;
    }
}
