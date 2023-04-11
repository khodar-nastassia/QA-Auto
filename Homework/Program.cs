namespace Homework
{
    internal class Program
    {
        static bool Information(PaymentCard[] cards)
        {
            foreach (PaymentCard card in cards)
            {
                Console.WriteLine(card.GetFullInformation());
            }

            return true;

        }



        static void Main(string[] args)
        {
            ValidDate date1 = new ValidDate(25, 01);
            ValidDate date2 = new ValidDate(25, 02);
            ValidDate date3 = new ValidDate(25, 03);
            ValidDate date4 = new ValidDate(25, 04);
            ValidDate date5 = new ValidDate(25, 05);
            ValidDate date6 = new ValidDate(25, 06);


            Adress adress1 = new Adress("BY", "Minsk", "Voli", 1, 1);
            Adress adress2 = new Adress("PL", "Warsaw", "Voli", 2, 2);
            Adress adress3 = new Adress("UA", "Kiew", "Voli", 3, 3);
            Adress adress4 = new Adress("RU", "Moskow", "Voli", 4, 4);
            Adress adress5 = new Adress("LT", "Vilnius", "Voli", 5, 5);
            Adress adress6 = new Adress("US", "Michigan", "Voli", 6, 6);

            Customer customer1 = new Customer("Ivan", "Petrov", adress1, 123456789);
            Customer customer2 = new Customer("Petr", "Sidorov", adress2, 223456789);
            Customer customer3 = new Customer("Jurij", "Ivanov", adress3, 323456789);
            Customer customer4 = new Customer("Oleg", "Voronov", adress4, 423456789);
            Customer customer5 = new Customer("Artem", "Lebedev", adress5, 523456789);
            Customer customer6 = new Customer("Vasya", "Konev", adress6, 623456789);




            PaymentCard card1 = new PaymentCard(1123456789000000, date1, customer1, 111);
            PaymentCard card2 = new PaymentCard(2123456789000000, date2, customer2, 222);
            DebetCard card3 = new DebetCard(3123456789000000, date3, customer3, 333, 5.1F, 3999F);
            DebetCard card4 = new DebetCard(4123456789000000, date4, customer4, 444, 7F, 4999F);
            CreditCard card5 = new CreditCard(5123456789000000, date5, customer5, 555, 12F, 599F);
            CreditCard card6 = new CreditCard(5123456789000000, date6, customer6, 666, 13F, 699F);


            PaymentCard[] cards = new PaymentCard[] { card1, card2, card3, card4, card5, card6 };
            Information(cards);

            

        }
    }
}