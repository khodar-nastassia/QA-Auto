using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.PaymentCards
{
    internal abstract class PaymentCard:IPayment

    {
        public long CardNumber { get; }
        public ValidDate ValidDate { get; }
        public Customer CardHolder { get; }
        public int CardCCV { get; }
        public PaymentCard(long cardNumber, ValidDate validDate, Customer cardHolder, int cardCCV)
        {
            CardNumber = cardNumber;
            ValidDate = validDate;
            CardHolder = cardHolder;
            CardCCV = cardCCV;
        }
        public abstract float MakePayment(float amount);
        public abstract float TopUp(float amount);
        public abstract bool CheckBalanceSufficiency(float amount);
        public abstract float GetBalance();
    }
}
