using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_2.BL;
using Task_2.DL;

namespace Task_2.UI
{
    internal class CustomerUI
    {
        public static int CustomerMenu()
        {
            Console.WriteLine("CUSTOMER >>");
            Console.WriteLine("Choose one of the following options: ");
            Console.WriteLine("1. View all the products.");
            Console.WriteLine("2. Buy the products.");
            Console.WriteLine("3. Generate invoice.");
            Console.WriteLine("4. View Profile (Username, Password, Email, Address and Contact Number).");
            Console.WriteLine("5. Exit.");
            Console.WriteLine("Your Option: ");
            int op = int.Parse(Console.ReadLine());
            return op;
        }

        public static void successfulLogin()
        {
            Console.WriteLine("Successfully logged in as customer");
        }

        public static void BuyProducts(User user)
        {
            Console.WriteLine("Enter the name of the product you want to buy:");
            string productName = Console.ReadLine();
            Console.WriteLine("Enter the quantity you want to buy:");
            int quantity = int.Parse(Console.ReadLine());
            CustomerCRUD.BuyProduct(productName, quantity, user);
        }
        public static void GenerateInvoice(User user)
        {
            if (user.products.Count == 0)
            {
                Console.WriteLine("No products purchased.");
                return;
            }
            Console.WriteLine("Invoice:");
            Console.WriteLine($"Total Cost: {user.totalCost}");
        }
    }
}
