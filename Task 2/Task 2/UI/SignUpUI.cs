using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_2.BL;

namespace Task_2.UI
{
    internal class SignUpUI
    {
        public static User TakeSignUpInput()
        {
            Console.WriteLine("Choose your name: ");
            string name=Console.ReadLine();
            Console.WriteLine("Choose your password: ");
            string pass=Console.ReadLine();
            Console.WriteLine("Choose your role: ");
            string role=Console.ReadLine();
            Console.WriteLine("Choose your email: ");
            string email=Console.ReadLine();
            Console.WriteLine("Enter your address: ");
            string address=Console.ReadLine();
            Console.WriteLine("Enter your contact number: ");
            string contact=Console.ReadLine();
            return new User(name, pass, role,email,address,contact);
        }
    }
}
