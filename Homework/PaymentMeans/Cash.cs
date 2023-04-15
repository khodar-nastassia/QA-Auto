using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.PaymentMeans
{
    internal class Cash : IPayment
    {
        public int BanknoteDenomination { get; set; }
        public int BanknoteNumber { get; set; }

        float CashBalance = 0;


        public Cash(int banknoteDenomination, int banknoteNumber)
        {
            BanknoteDenomination = banknoteDenomination;
            BanknoteNumber = banknoteNumber;
        }
        

        public void CountCashBalance()
        {
            CashBalance = BanknoteDenomination * BanknoteNumber;
        }

        public bool CheckBalanceSufficiency(float amount)
        {
            CountCashBalance();
            return CashBalance >= amount;

        }

        public float MakePayment(float amount)
        {
            CashBalance -= amount;
            return CashBalance;
        }

        public float TopUp(float amount)
        {
            CashBalance += amount;
            return CashBalance;

        }
        public float GetBalance()
        {
            return CashBalance;
        }


    }
}
