namespace Homework.PaymentMeans;

public class Cash : PaymentMean
{
    public Cash(float cashBalance) : base(cashBalance)
    {
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

    public override string ToString() => "Cash balance is " + Balance;

    public override bool Equals(object? obj)
    {
        if (obj is Cash cash)
        {
            return cash.Balance == Balance;
        }
        return false;
    }
}