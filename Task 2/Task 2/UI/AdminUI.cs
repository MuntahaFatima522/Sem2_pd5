
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_2.BL;

namespace Task_2.UI
{
    internal class AdminUI
    {
        public static int AdminMenu()
        {
            Console.WriteLine("ADMIN >>");
            Console.WriteLine("Choose one of the following options: ");
            Console.WriteLine("1. Add Product.");
            Console.WriteLine("2. View All Products.");
            Console.WriteLine("3. Find Product with Highest Unit Price.");
            Console.WriteLine("4. View Sales Tax of All Products.");
            Console.WriteLine("5. Products to be Ordered. (less than threshold).");
            Console.WriteLine("6. View Profile (Username, Password).");
            Console.WriteLine("7. Exit.");
            Console.WriteLine("Your Option: ");
            int op=int.Parse(Console.ReadLine());
            return op;
        }

        public static void successfulLogin()
        {
            Console.WriteLine("Successfully logged in as admin");
        }

        
    }
}
