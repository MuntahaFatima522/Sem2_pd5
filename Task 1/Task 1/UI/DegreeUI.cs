using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1.DL;
using Task_1.BL;

namespace Task_1.UI
{
    internal class DegreeUI
    {
        public static void DisplayAllAvailableDegrees()
        {
            Console.WriteLine("All available degree programs are: ");
            for (int i = 0; i < DegreeCRUD.DegreesList.Count; i++)
            {
                Console.WriteLine(DegreeCRUD.DegreesList[i].title);
            }
        }
        public static DegreeProgram TakeDegreeInput()
        {
            Console.WriteLine("Enter degree name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter degree duration: ");
            int duration = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter seats for degree: ");
            int seats = int.Parse(Console.ReadLine());
            Console.Write("Enter degree merit: ");
            double merit = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter how many subjects to enter: ");
            DegreeProgram deg = new DegreeProgram(name, duration, seats,merit);
            int subjects = int.Parse(Console.ReadLine());
            int totalCH = 0;
            for (int i = 0; i < subjects; i++)
            {
                Console.WriteLine("Enter Subject #" , i + 1);
                Subject sub = SubjectUI.TakeSubjectInput();
                totalCH += sub.creditHours;
                if(totalCH<=20)
                {
                    deg.subjects.Add(sub);
                    SubjectCRUD.writeData(sub);
                }
                else
                {
                    Console.WriteLine("Credit Hours for a degree cannot be more than 20");
                    break;
                }
            }
            return deg;
        }
        public static string SpecificDegreeInput()
        {
            Console.WriteLine("Enter Degree name: ");
            string name = Console.ReadLine();
            return name;
        }
    }
}
