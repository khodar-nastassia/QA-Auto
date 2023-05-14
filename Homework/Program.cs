using Homework;
using Homework.Exceptions;
using Homework.PaymentMeans;
using Homework.PaymentMeans.PaymentCards;

try
{
    //Create Valid Date
    var date1 = new ValidDate(01, 25);
    var date2 = new ValidDate(02, 25);
    var date3 = new ValidDate(03, 25);
    var date4 = new ValidDate(04, 25);
    var date5 = new ValidDate(05, 25);
    var date6 = new ValidDate(06, 25);

    //Create Address
    var address1 = new Address("BY", "Minsk", "Voli", 1, 1);
    var address2 = new Address("PL", "Warsaw", "Voli", 2, 2);
    var address3 = new Address("UA", "Kiew", "Voli", 3, 3);
    var address4 = new Address("RU", "Moskow", "Voli", 4, 4);

    //Create Customer
    var customer1 = new Customer("Ivan", "Petrov", address1, 123456789);
    var customer2 = new Customer("Petr", "Sidorov", address2, 223456789);
    var customer3 = new Customer("Jurij", "Ivanov", address3, 323456789);
    var customer4 = new Customer("Oleg", "Voronov", address4, 423456789);

    //Create BitCoin
    var bitCoin1 = new BitCoin(100);
    var bitCoin2 = new BitCoin(200);

    //Create Cash
    var cash1 = new Cash(30);
    var cash2 = new Cash(40);
    var cash3 = new Cash(50);

    //Create CashBackCard
    var cashBackCard1 = new CashBackCard(1123456789000000, date1, customer1, 111, 1F, 60F);
    var cashBackCard2 = new CashBackCard(2123456789000000, date2, customer2, 222, 2F, 70F);

    //Create DebitCard
    var debetCard1 = new DebitCard(3123456789000000, date3, customer3, 333, 80F);
    var debetCard2 = new DebitCard(4123456789000000, date4, customer4, 444, 90F);

    //Create CreditCard
    var creditCard1 = new CreditCard(5123456789000000, date5, customer1, 555, 10F, 110F);
    var creditCard2 = new CreditCard(5123456789000000, date6, customer3, 666, 6F, 110F);

    var paymentMeans1 = new List<PaymentMean>
    {
        bitCoin1,
        cash1,
        debetCard1,
        creditCard1,
        cashBackCard1 };

    var paymentMeans2 = new List<PaymentMean>
    {
        cash2,
        debetCard2,
        creditCard2,
        cashBackCard2 };

    var paymentMeans3 = new List<PaymentMean>
    {
        cash3,
        bitCoin2,
        creditCard1 };

    var paymentMeans4 = new List<PaymentMean> 
    {
        debetCard1,
        cashBackCard2 };

    //Create BankClient
    var client1 = new BankClient(customer1, "individual", paymentMeans1);
    var client2 = new BankClient(customer2, "commercial", paymentMeans2);
    var client3 = new BankClient(customer3, "individual", paymentMeans3);
    var client4 = new BankClient(customer4, "individual", paymentMeans4);

    //Task1. 5.Совершить несколько платежей на различные суммы,
    client1.Pay(100);
    client2.Pay(80);
    client3.Pay(50);
    client4.Pay(10);

    //и после этого вывести остаток по всем платежным средствам клиента.
    foreach (var item in client1.PaymentMeans)
    {
        Console.WriteLine(item.GetBalance());
    }

    //Task2
    //1. Создать и заполнить коллекцию BankClient (List), у каждого клиента должно быть несколько платежных средств

    var bankClients = new List<BankClient> { client1, client2, client3, client4 };

    var analitik1 = new Analitics(bankClients);

    //2.Отсортировать коллекцию несколькими способами с использованием метода Sort и реализаций интерфейса ICompararer
    //2.1.По имени клиента
    analitik1.SortBankClients("LastName");

    //2.2 По адресу клиента
    analitik1.SortBankClients("City");

    //2.3 По количеству пластиковых карточек
    analitik1.SortBankClients("Amount of cards");

    //2.4 По общему количеству имеющихся денег(на всех платежных средствах)
    analitik1.SortBankClients("TotalBalance");

    //2.5 По максимальному количеству денег на одном платежном средстве
    analitik1.SortBankClients("MaxBalance");

    // Make some payment
    client1.Pay(20f);
    client2.Pay(10f);
    client3.Pay(30f);

    //sort after pay
    analitik1.SortBankClients("TotalBalance");

    foreach (BankClient item in bankClients)
    {
        Console.WriteLine(item.Customer.LastName + "=" + item.GetAllMoney());
    }

    //Task3
    //1. Выполнить сортировку, описанную в задаче 2, с использованием LINQ
    // sort by Last name
    var orderedClientName = analitik1.BankClients.OrderBy(x => x.Customer.LastName).ToList();

    //sort by Address
    var orderedClientAddress = analitik1.BankClients.OrderBy(x => x.Customer.Address.City).ToList();

    //sort by amount of cards
    var orderedClientAmountOfCards = analitik1.BankClients.OrderBy(x => x.PaymentMeans.Count).ToList();

    //sort by TotalBalance
    var orderedClientTotalBalance = analitik1.BankClients.OrderBy(x => x.GetAllMoney()).ToList();

    //sort by MaxBalance
    var orderedClientMaxBalance = analitik1.BankClients.OrderBy(x => x.GetMaxBalance()).ToList();

    //2.С использованием LINQ вывести в консоль:
    //2.1.Список всех дебетовых карт для клиента
    foreach (var item in bankClients)
    {
        var debetCards = item.PaymentMeans.Where(x => x is DebitCard).Select(x => x as DebitCard).Select(x => x.CardNumber).ToList();
        Console.WriteLine("Debet Cards " + item.Customer.LastName);
        foreach (var debetCard in debetCards)
        {
            Console.WriteLine(debetCard.ToString());
        }
        //2.2 Сумму всех доступных средств для клиента
        var totalBalances = item.PaymentMeans.Select(x => x.GetBalance()).ToList().Sum();
        Console.WriteLine("TotalBalance " + item.Customer.LastName + "-" + totalBalances);
    }
    //3.Создать несколько клиентов со своими платежными средствами, найти среди них самого состоятельного по совокупности имеющихся у него средств
    var Richest = bankClients.OrderByDescending(x => x.GetAllMoney()).ToList()[0].Customer.LastName;
    Console.WriteLine(Richest);

    //4.Вывести в консоль всех клиентов, имеющих биткойны, отсортированный по убыванию совокупности всех имеющихся у клиентов средств

    var clientsWithBitCoins = bankClients.OrderByDescending(x => x.GetAllMoney()).SelectMany(x => x.PaymentMeans.Where(x => x is BitCoin), (LName, means) => new { LName = LName.Customer.LastName, Means = means }).ToList();
    foreach (var i in clientsWithBitCoins)
    {
        Console.WriteLine(i.LName);
    }
}
catch (WrongDate ex)
{
    Console.WriteLine(ex.Message);
}

catch (WrongPhoneNumber ex)
{
    Console.WriteLine(ex.Message);
}

catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
