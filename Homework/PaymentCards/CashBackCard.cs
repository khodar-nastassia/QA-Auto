using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.PaymentCards
{
    internal class CashBackCard : PaymentCard
    {
        public float CashBackCardPercent { get; private set; }
        public float CashBackCardBalance { get; private set; }

        public CashBackCard(long cardNumber, ValidDate validDate, Customer cardHolder, int cardCCV, float cashBackCardPercent, float cashBackCardBalance):base (cardNumber,validDate,cardHolder,cardCCV) 
        {
            
            CashBackCardBalance = cashBackCardBalance;
            CashBackCardPercent = cashBackCardPercent;
        }


        public override string ToString()
        {
            return "CashBackCardPercent = " + CashBackCardPercent + ", CashBackCardBalance = " + CashBackCardBalance;

        }
        public string GetFullInformation()
        {
            return string.Format("CashBackCardNumber:{0}, CardValidity:{1}, CashBackCardHolder: {2}, CCV: {3}, CashBackCardPercent: {4}, CashBackCardBalance: {5} ", CardNumber, ValidDate, CardHolder, CardCCV, CashBackCardPercent, CashBackCardBalance);
        }

        public override bool CheckBalanceSufficiency(float amount)
        {
            if (CashBackCardBalance >= amount)
            {
                return true;
            }
            return false;
        }
        public override float MakePayment(float amount)
        {
            CashBackCardBalance -= amount;
            CashBackCardBalance += amount * CashBackCardPercent / 100;
            return CashBackCardBalance;
        }

        public override float TopUp(float amount)
        {
            CashBackCardBalance += amount;
            return CashBackCardBalance;

        }
        public override float GetBalance()
        {
            return CashBackCardBalance;
        }
    }
}
