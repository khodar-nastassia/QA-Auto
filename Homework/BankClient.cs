using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Homework.PaymentCards;
using Homework.PaymentMeans;

namespace Homework
{
    internal class BankClient
    {
        public string ClientInfo { get; set; }
       
        private List<IPayment> PaymentMeans { get; set; } 
        public BankClient(List<IPayment> paymentMeans)
        {
            PaymentMeans = paymentMeans;           
        }
        public bool AddPaymentMean(IPayment mean)
        {
            PaymentMeans.Add(mean);
            return true;
        }

        public bool Pay(float amount)
        {
            List<IPayment> cash = PaymentMeans.Where(x => x is Cash).ToList();
            
            foreach (IPayment item in cash)
            {
                if (item.CheckBalanceSufficiency(amount) == true)
                {
                    item.MakePayment(amount);
                    float test = item.GetBalance();
                    //Console.WriteLine("pay by cash");
                    return true;

                }
            }
            List<IPayment> cashBackCard = PaymentMeans.Where(x => x is CashBackCard).ToList();

            foreach (IPayment item in cashBackCard)
            {
                if (item.CheckBalanceSufficiency(amount))
                {
                    item.MakePayment(amount);
                    //Console.WriteLine("pay by cashBackCard");
                    return true;
                }
            }

            List<IPayment> debetCard = PaymentMeans.Where(x => x is DebetCard).ToList();
            foreach (IPayment item in debetCard)
            {
                if (item.CheckBalanceSufficiency(amount))
                {
                    item.MakePayment(amount);
                    //Console.WriteLine("pay by debetCard");
                    return true;
                }
            }
            List<IPayment> creditCard = PaymentMeans.Where(x => x is CreditCard).ToList();
            foreach (IPayment item in creditCard)
            {
                if (item.CheckBalanceSufficiency(amount))
                {
                    item.MakePayment(amount);
                    //Console.WriteLine("pay by creditCard");
                    return true;
                }
            }
            List<IPayment> bitCoin = PaymentMeans.Where(x => x is BitCoin).ToList();
            foreach (IPayment item in bitCoin)
            {
                if (item.CheckBalanceSufficiency(amount))
                {
                    item.MakePayment(amount);
                    //Console.WriteLine("pay by bitCoin");
                    return true;
                }
            }
            Console.WriteLine("not enough money ");
            return false;

          
        }
       
    }
}
