using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2.UI
{
    internal class SignInUI
    {
        public static string TakeNameInputToSignIn()
        {
            Console.WriteLine("Enter your name: ");
            string name=Console.ReadLine();
            return name;
        }

        public static string TakePasswordInputToSignIn()
        {
            Console.WriteLine("Enter your password: ");
            string pass = Console.ReadLine();
            return pass;
        }

    }
}
