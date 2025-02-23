using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1.BL;
using Task_1.DL;

namespace Task_1.UI
{
    internal class StudentUI
    {
        public static Student TakeInputToAddStudent()
        {
            Console.WriteLine("Enter Student Name: ");
            string name=Console.ReadLine();
            Console.WriteLine("Enter Student Age: ");
            int age=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Student FSC marks: ");
            double FSCMarks=double.Parse(Console.ReadLine());
            Console.WriteLine("Enter Student Ecat Marks: ");
            double EcatMarks=double.Parse(Console.ReadLine());
            DegreeUI.DisplayAllAvailableDegrees();
            Student stu=new Student(name,age,FSCMarks,EcatMarks);
            Console.WriteLine("Enter number of preferences you want to enter: ");
            int pref=int.Parse(Console.ReadLine());
            for (int i = 0; i < pref; i++)
            {
                Console.WriteLine("Enter preference #" , i+1);
                string preference = Console.ReadLine();
                stu.preferences.Add(DegreeCRUD.checkAvailabilityOfPreferenceDegree(preference));
            }
            return stu;
        }

        public static void DisplayMeritResultOfAllStudents()
        {
            foreach (Student student in StudentCRUD.studentList)
            {
                if (student.isRegistered)
                {
                    Console.WriteLine(student.name + " got admission in " + student.regDegree.title);
                }
                else
                {
                    Console.WriteLine(student.name + " did not get admission");
                }
            }
        }

        public static void DisplayAllRegisteredStudents()
        {
            Console.WriteLine("Name \t FSC \t ECAT \t Age \n \n");
            foreach (Student student in StudentCRUD.studentList)
            {
                if (student.isRegistered)
                {
                    Console.WriteLine(student.name + "\t" + student.FSCMarks + "\t" + student.EcatMarks + "\t" + student.age);
                }
            }                   
        }

        public static void DisplayStudentsOfSpecificDegree(string degree)
        {
            Console.WriteLine("Name \t FSC \t ECAT \t Age \n \n");
            foreach (Student student in StudentCRUD.studentList)
            {
                if (student.regDegree.title == degree)
                {
                    Console.WriteLine(student.name + "\t" + student.FSCMarks + "\t" + student.EcatMarks + "\t" + student.age);
                }
            }
        }

        public static string InputStudentNameToRegisterInSubject()
        {
            Console.Write("Enter your name: ");
            string name=Console.ReadLine();
            return name;
        }

        public static void DisplaySubjectsOfRegisteredDegree(Student s)
        {
            Console.WriteLine("Available Subjects for " + s.name + "'s degree are: \n \n");
            Console.WriteLine("Code \t  Type \t  Credit Hours \t Fees \n");
            for (int i = 0; i < s.regDegree.subjects.Count; i++)
                Console.WriteLine(s.regDegree.subjects[i].code + " \t " + s.regDegree.subjects[i].subjectType + " \t " + s.regDegree.subjects[i].creditHours + " \t " + s.regDegree.subjects[i].subjectFee);
        }
        public static List<Subject> RegisterStudentSubjects(Student stu)
        {
            List<Subject> subjects = new List<Subject>();
            int sum = 0;
            Console.WriteLine("Enter number of subjects you want to register in: ");
            int count=int.Parse(Console.ReadLine());
            for (int i = 0;i<count;i++)
            {
                Console.Write("Enter subject code: ");
                string code = Console.ReadLine();
                Subject sub = stu.regDegree.GetSubjectbyCode(code);
                sum += sub.creditHours;
                if(sum<=9)
                {
                    subjects.Add(sub);
                    continue;
                }
                else
                {
                    Console.WriteLine("Credit hours cannot be more than 9.");
                    break;
                }
            }
            return subjects;
        }
        public static void DisplayFeesOfRegisteredStudents()
        {
            foreach (Student student in StudentCRUD.studentList)
            {
                if (student.isRegistered)
                {
                    Console.WriteLine("Fees for " + student.name + " is: " + student.SubjectsFees());
                }
            }
        }
    }
}
