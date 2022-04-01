using SalesOrder.Entities.Enums;
using SalesOrder.Entities;
using System.Globalization;

namespace SalesOrder
{

    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Enter cliente data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());
            Client client = new Client(name, email, birthDate);

            Console.WriteLine();
            Console.WriteLine("Enter order data:");
            Console.Write("Status: ");
            OrderStatus orderStatus = Enum.Parse<OrderStatus>(Console.ReadLine());

            Order order = new Order(DateTime.Now, orderStatus, client);

            Console.Write("How many items to this order? ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"Enter #{i} item data:");
                Console.Write("Product name: ");
                string productName = Console.ReadLine();
                Console.Write("Product price: ");
                double productPrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Quantity: ");
                int productQuantity = int.Parse(Console.ReadLine());
                Product product = new Product(productName, productPrice);
                OrderItem orderItem = new OrderItem(productQuantity, product);
                order.AddItem(orderItem);
            }

            Console.WriteLine();
            Console.WriteLine(order);
        }
    }
}