using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1.BL;

namespace Task_1.UI
{
    internal class SubjectUI
    {
        public static Subject TakeSubjectInput()
        {
            Console.WriteLine("Enter subject Code: ");
            string code = Console.ReadLine();
            Console.WriteLine("Enter Subject CreditHours: ");
            int creditHours = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter subject Type: ");
            string type = Console.ReadLine();
            Console.WriteLine("Enter Subject Fees: ");
            int fees = int.Parse(Console.ReadLine());
            return new Subject(code, creditHours, type, fees);
        }
    }
}
