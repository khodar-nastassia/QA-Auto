using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    internal class CreditCard: PaymentCard
    {
        public float CreditPercent { get; set; }
        public float CreditLimit { get; set; }
        public CreditCard(long number, ValidDate validity, Customer name, int ccv, float creditPercent, float creditLimit):base(number, validity, name, ccv)
        {
            CreditPercent = creditPercent;
            CreditLimit = creditLimit;
        }
        public override string ToString()
        {
            return "CreditPercent = " + CreditPercent + ", CreditLimit = " + CreditLimit;
            
        }
        public override string GetFullInformation()
        {
            return string.Format("CreditCardNumber:{0}, CardValidity:{1}, CustomerName: {2}, CCV: {3}, CreditPercent: {4}, CreditLimit: {5} ", CardNumber, CardValidity, CustomerName, CCV, CreditPercent, CreditLimit);
        }

    }
}
