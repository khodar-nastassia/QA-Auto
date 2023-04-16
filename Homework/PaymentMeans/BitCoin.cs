using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.PaymentMeans
{
    internal class BitCoin : IPayment
    {
        public float BitCoinBalance { get; private set; }
        public BitCoin BitCoinHash { get; private set; }
        public BitCoin(float bitCoinBalance)
        {
            BitCoinBalance = bitCoinBalance;
        }
        public bool CheckBalanceSufficiency(float amount)
        {
            if (BitCoinBalance >= amount)
            {
                return true;
            }
            return false;
        }
        public float MakePayment(float amount)
        {
            BitCoinBalance -= amount;
            return BitCoinBalance;
        }
        public float TopUp(float amount)
        {
            BitCoinBalance += amount;
            return BitCoinBalance;
        }
        public float GetBalance()
        {
            return BitCoinBalance;
        }
    }
}
