namespace Homework.PaymentMeans;

public class BitCoin: PaymentMean
{
    public long BitCoinHash {get; private set; }

    public BitCoin(float bitCoinBalance): base(bitCoinBalance)
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

    public override string ToString() => "BitCoin balance is " + Balance;

    public override bool Equals(object? obj)
    {
        if (obj is BitCoin bitCoin)
        {
            return bitCoin.Balance == Balance;
        }
        return false;
    }
}
