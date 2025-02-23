using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2.UI
{
    internal class ConsoleUtility
    {
        public static int MainMenu()
        {
            int op;
            Console.WriteLine("*******************************************************");
            Console.WriteLine("         Departmental Store Management System          ");
            Console.WriteLine("*******************************************************");
            Console.WriteLine("Choose one of the following options: ");
            Console.WriteLine("1. Sign In.");
            Console.WriteLine("2. Sign Up.");
            Console.WriteLine("3. Exit");
            Console.WriteLine("Your option: ");
            op=int.Parse(Console.ReadLine());
            return op;
        }
    }
}
