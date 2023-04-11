using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    internal class PaymentCard
    {
        public long CardNumber { get; set; }
        public ValidDate CardValidity { get; set; }
        public Customer CustomerName { get; set; }
        public int CCV { get; set; }

        public PaymentCard(long number, ValidDate validity, Customer name, int ccv)
        {
            CardNumber = number;
            CardValidity = validity;
            CustomerName = name;
            CCV = ccv; 
        }

        public virtual string GetFullInformation()
        {
            return string.Format("CardNumber:{0}, CardValidity:{1}, CustomerName: {2}, CCV: {3}", CardNumber, CardValidity, CustomerName, CCV);
        }
        public override string ToString()
        {
            return "CardNumber: " + CardNumber + ", CardValidity: " + CardValidity + ", CustomerName: " + CustomerName + "CCV: " + CCV;

        }


    }
}
