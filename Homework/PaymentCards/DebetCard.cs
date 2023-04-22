using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.PaymentCards
{
    internal class DebetCard : PaymentCard 
    {
        public float DebetCardBalance { get; private set; }
        public DebetCard(long cardNumber, ValidDate validDate, Customer cardHolder, int cardCCV, float debetCardBalance):base(cardNumber, validDate, cardHolder, cardCCV)
        {        
            DebetCardBalance = debetCardBalance;
        }
        public override string ToString()
        {
            return "DebetCardNumber = " + CardNumber + ", DebetCardBalance = " + DebetCardBalance;
        }
        public string GetFullInformation()
        {
            return string.Format("DebetCardNumber:{0}, CardValidity:{1}, DebetCardHolder: {2}, CCV: {3}, DebetCardBalance: {4} ", CardNumber, ValidDate, CardHolder, CardCCV, DebetCardBalance);
        }
        public override bool CheckBalanceSufficiency(float amount)
        {
            if (DebetCardBalance >= amount)
            {
                return true;
            }
            return false;
        }
        public override float MakePayment(float amount)
        {
            DebetCardBalance -= amount;
            return DebetCardBalance;
        }
        public override float TopUp(float amount)
        {
            DebetCardBalance += amount;
            return DebetCardBalance;
        }
        public override float GetBalance()
        {
            return DebetCardBalance;
        }
    }
}
