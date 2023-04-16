using Homework.PaymentCards;
using Homework.PaymentMeans;

namespace Homework
{
    internal class Program
    {

        static void Main(string[] args)
        {
            //Task1
            //1.Создать интерфейс IPayment c двумя методами- MakePayment(float amount), и TopUp(float amount) 
            //2.Реализовать интерфейс в классах Cash, DebetCard, CreditCard, CashBackCard, BitCoin (начинка классов и реализация интерфейсов на ваше усмотрение - в зависимости от типа реальной карты(Debet, Credit, CashBack) реализовать MakePayment - снимать деньги с текущего счета, с использованием кредита и т.д)
            //3.Создать класс BankClient, c данными клиента(имя, фамилия, адрес), и списком платежных средств. 
            //4.Для BankClient создать метод bool Pay(float), который реализован следующим образом-для списка платежных средств осуществляется попытка платежа-сначала наличными, если не получилось - картами CashBaсk, далее дебетовыми, кредитными и в крайнем случае биткойнами.Из метода возвращается значение успеха платежа.
            //5.Совершить несколько платежей на различные суммы, и после этого вывести остаток по всем платежным средствам клиента.

            //Task2
            //1. Создать и заполнить коллекцию BankClient (List), у каждого клиента должно быть несколько платежных средств
            //2.Отсортировать коллекцию несколькими способами с использованием метода Sort и реализаций интерфейса  ICompararer
            //2.1.По имени клиента
            //2.2 По адресу клиента
            //2.3 По количеству пластиковых карточек
            //2.4 По общему количеству имеющихся денег(на всех платежных средствах)
            //2.5 По максимальному количеству денег на одном платежном средстве

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

            List<IPayment> paymentMeans1 = new List<IPayment> { bitCoin1, banknote5, debetCard1, creditCard1, creditCard2, cashBackCard1 };
            List<IPayment> paymentMeans2 = new List<IPayment> { bitCoin2, banknote10, debetCard2, creditCard2, cashBackCard2 };
            List<IPayment> paymentMeans3 = new List<IPayment> { banknote50, debetCard1, creditCard1, cashBackCard1 };
            List<IPayment> paymentMeans4 = new List<IPayment> { bitCoin1, debetCard2, cashBackCard2 };

            //Create BankClient
            BankClient client1 = new BankClient(customer1, paymentMeans1);
            BankClient client2 = new BankClient(customer2, paymentMeans2);
            BankClient client3 = new BankClient(customer3, paymentMeans3);
            BankClient client4 = new BankClient(customer4, paymentMeans4);

            List<BankClient> bankClients = new List<BankClient> { client1, client2, client3, client4 };

            // Вывод Customer.LastName and TotalBalance
            foreach (BankClient item in bankClients)
            {
                Console.WriteLine(item.Customer.LastName + "=" +item.GetAllMoney(item));
            }

            Analitics analitik1 = new Analitics(bankClients);
            
            //sort by TotalBalance
            analitik1.AnalisysBankClients("TotalBalance");
            
            // after sort
            foreach (BankClient item in bankClients)
            {
                Console.WriteLine(item.Customer.LastName + "=" + item.GetAllMoney(item));
            }
            
            // Make payment
            client1.Pay(10f);
            client2.Pay(100f);
            client3.Pay(2000f);
            
            //sort after pay
            analitik1.AnalisysBankClients("TotalBalance");
            
            foreach (BankClient item in bankClients)
            {
                Console.WriteLine(item.Customer.LastName + "=" + item.GetAllMoney(item));
            }
        }
    }
}