using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    internal class DebetCard: PaymentCard
    { 
        public float DebetPercent { get; set; }
        public float DebetAmount { get; set; }
        public DebetCard(long number, ValidDate validity, Customer name, int ccv, float debetPercent, float debetAmount):base(number, validity, name, ccv)
        {
            DebetPercent = debetPercent;
            DebetAmount = debetAmount;
        }
        public override string ToString()
        {
            return "DebetPercent = " + DebetPercent + ", DebetAmount = " + DebetAmount;
           
        }
        public override string GetFullInformation()
        {
            return string.Format("DebetCardNumber:{0}, CardValidity:{1}, CustomerName: {2}, CCV: {3}, DebetPercent: {4}, DebetAmount: {5} ", CardNumber, CardValidity, CustomerName, CCV, DebetPercent, DebetAmount);
        }

    }
}
