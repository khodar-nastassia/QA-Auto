using Homework.Comparer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    internal class Analitics
    {
        public List<IPayment> PaymentMeans { get; set; }
        public List<BankClient> BankClients { get; set; }
        public Analitics(List <BankClient> bankClients)
        {
            BankClients = bankClients;
        }
        public void AnalisysBankClients(string comparer)
        {
            BankClients.Sort(GetComparer(comparer));
        }
        private IComparer<BankClient> GetComparer(string comparer)
        {
            if (comparer == "City")
            {
                return new AdressCityComparer();
            }
            else if (comparer == "Amount of cards")
            {
                return new AmountCardsCompare();
            }
            else if (comparer == "LastName")
            {
                return new LastNameComparer();
            }
            else if (comparer == "MaxBalance")
            {
                return new MaxBalanceComparer();
            }
            else if (comparer == "TotalBalance")
            {
                return new TotalBalanceComparer();
            }
            return new FirstNameComparer();
        }

    }
}
