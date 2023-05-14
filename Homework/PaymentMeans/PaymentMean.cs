namespace Homework.PaymentMeans;

public abstract class PaymentMean: IPayment
{
    private float _balance;
    public  float Balance
    {
        get { return _balance; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Balance cannot be negative.");
            }
            _balance = value;
        }
    }
    public PaymentMean(float balance) 
    {
        Balance= balance;
    }

    public abstract float MakePayment(float amount);
    public abstract float TopUp(float amount);
    public bool CheckBalanceSufficiency(float amount) => Balance >= amount;
    public float GetBalance() => Balance;
}
