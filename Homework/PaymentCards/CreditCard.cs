using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Homework.PaymentCards
{
    internal class CreditCard : PaymentCard
    {
        public float CreditCardPercent { get; private set; }
        public float CreditCardLimit { get; private set; }

        public CreditCard(long cardNumber, ValidDate validDate, Customer cardHolder, int cardCCV, float creditCardPercent, float creditCardLimit):base(cardNumber, validDate, cardHolder, cardCCV)
        {            
            CreditCardPercent = creditCardPercent;
            CreditCardLimit = creditCardLimit;
        }
        public override string ToString()
        {
            return "CreditCardNumber = " + CardNumber + ", CreditCardPercent = " + CreditCardPercent + ", CreditCarDLimit = " + CreditCardLimit;
        }
        public string GetFullInformation()
        {
            return string.Format("CreditCardNumber:{0}, CardValidity:{1}, CreditCardHolder: {2}, CCV: {3}, CreditCardPercent: {4}, CreditCardLimit: {5}", CardNumber, ValidDate, CardHolder, CardCCV, CreditCardPercent, CreditCardLimit);
        }
        public override bool CheckBalanceSufficiency(float amount)
        {
            if (CreditCardLimit >= amount)
            {
                return true;
            }
            return false;
        }
        public override float MakePayment(float amount)
        {
            CreditCardLimit -= amount;
            CreditCardLimit -= amount * CreditCardPercent / 100;
            return CreditCardLimit;
        }
        public override float TopUp(float amount)
        {
            CreditCardLimit -= amount;
            return CreditCardLimit;
        }
        public override float GetBalance()
        {
            return CreditCardLimit;
        }
    }
}
