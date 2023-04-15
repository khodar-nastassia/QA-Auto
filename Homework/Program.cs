using Homework.PaymentCards;
using Homework.PaymentMeans;

namespace Homework
{
    internal class Program
    {

        static void Main(string[] args)
        {
            
            
            //Create Valid Date   
            ValidDate date1 = new ValidDate(25, 01);
            ValidDate date2 = new ValidDate(25, 02);
            ValidDate date3 = new ValidDate(25, 03);
            ValidDate date4 = new ValidDate(25, 04);
            ValidDate date5 = new ValidDate(25, 05);
            ValidDate date6 = new ValidDate(25, 06);

            //Create Address
            Address address1 = new Address("BY", "Minsk", "Voli", 1, 1);
            Address address2 = new Address("PL", "Warsaw", "Voli", 2, 2);
            Address address3 = new Address("UA", "Kiew", "Voli", 3, 3);
            Address address4 = new Address("RU", "Moskow", "Voli", 4, 4);
            Address address5 = new Address("LT", "Vilnius", "Voli", 5, 5);
            Address address6 = new Address("US", "Michigan", "Voli", 6, 6);

            //Create Customer
            Customer customer1 = new Customer("Ivan", "Petrov", address1, 123456789);
            Customer customer2 = new Customer("Petr", "Sidorov", address2, 223456789);
            Customer customer3 = new Customer("Jurij", "Ivanov", address3, 323456789);
            Customer customer4 = new Customer("Oleg", "Voronov", address4, 423456789);
            Customer customer5 = new Customer("Artem", "Lebedev", address5, 523456789);
            Customer customer6 = new Customer("Vasya", "Konev", address6, 623456789);

            //Create BitCoin
            BitCoin bitCoin1 = new BitCoin(99);
            BitCoin bitCoin2 = new BitCoin(199);

            //Create Cash
            Cash banknote5 = new Cash(5, 2);
            Cash banknote10 = new Cash(10, 4);
            Cash banknote50 = new Cash(50, 3);

            //Create CashBackCard
            CashBackCard cashBackCard1 = new CashBackCard(1123456789000000, date1, customer1, 111, 1F,1999F);
            CashBackCard cashBackCard2 = new CashBackCard(2123456789000000, date2, customer2, 222, 2F, 2999F);
             
            //Create DebetCard
            DebetCard debetCard1 = new DebetCard(3123456789000000, date3, customer3, 333, 3999F);
            DebetCard debetCard2 = new DebetCard(4123456789000000, date4, customer4, 444, 4999F);

            //Create CreditCard
            CreditCard creditCard1 = new CreditCard(5123456789000000, date5, customer5, 555, 5F, 5999F);
            CreditCard creditCard2 = new CreditCard(5123456789000000, date6, customer6, 666, 6F, 6999F);

            //Create wallets with different payment means
            List<IPayment> wallet1 = new List<IPayment>{ bitCoin1, banknote5, debetCard1, creditCard1,creditCard2, cashBackCard1 };
            //List<IPayment> wallet2 = new List<IPayment> { bitCoin2, banknote10, debetCard2, cashBackCard1, cashBackCard2 };

            //Create BankClient
            BankClient client1 = new BankClient(wallet1);
            //BankClient client2 = new BankClient(wallet2);
            
            client1.Pay(10f);
            client1.Pay(100f);
            client1.Pay(2000f);
        
            
            foreach (IPayment p in wallet1)
            {
                Console.WriteLine(p.GetBalance());
            }


            





        }
    }
}