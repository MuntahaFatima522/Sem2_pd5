using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1.UI;
using Task_1.BL;
using Task_1.DL;

namespace Task_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SubjectCRUD.readFromFile();
            DegreeCRUD.readFromFile();
            StudentCRUD.readFromFile();
            int op;
            while (true)
            { 
                op = ConsoleUtility.MainMenu();
                if (op == 1)
                {
                    Student s = StudentUI.TakeInputToAddStudent();
                    StudentCRUD.AddStudent(s);
                    StudentCRUD.writeData(s);
                }
                else if (op == 2)
                {
                    DegreeProgram d = DegreeUI.TakeDegreeInput();
                    DegreeCRUD.AddDegree(d);
                    DegreeCRUD.writeData(d);
                }
                else if (op == 3)
                {
                    StudentCRUD.RegisterStudentInDegrees();
                    StudentUI.DisplayMeritResultOfAllStudents();
                }
                else if (op == 4)
                {
                    StudentUI.DisplayAllRegisteredStudents();
                }
                else if (op == 5)
                {
                    string degree=DegreeUI.SpecificDegreeInput();
                    StudentUI.DisplayStudentsOfSpecificDegree(degree);
                }
                else if (op == 6)
                {
                    string name=StudentUI.InputStudentNameToRegisterInSubject();
                    Student s=StudentCRUD.SearchStudentObject(name);
                    StudentUI.DisplaySubjectsOfRegisteredDegree(s);
                    s.registerSubjects(StudentUI.RegisterStudentSubjects(s));
                }
                else if (op == 7)
                {
                    StudentUI.DisplayFeesOfRegisteredStudents();
                }
                else if (op == 8)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option.");
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
