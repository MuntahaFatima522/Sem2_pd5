using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1.BL;
using Task_1.UI;

namespace Task_1.DL
{
    internal class StudentCRUD
    {
        public static List<Student> studentList= new List<Student>();

        public static void AddStudent(Student NewStudent)
        {
            studentList.Add(NewStudent);
        }
        public static void RegisterStudentInDegrees()
        {
            foreach (Student student in studentList)
            {
                student.registeredDegree();
            }
        }

        public static Student SearchStudentObject(string name)
        {
            foreach (Student student in studentList)
            {
                if (student.name == name)
                {
                    return student;
                }
            }                
            return null;
        }
        public static void readFromFile()
        {
            StreamReader f = new StreamReader("Student.txt");
            string record;

            if (File.Exists("Student.txt"))
            {

                while ((record = f.ReadLine()) != null)
                {
                    string[] splittedRecord = record.Split(',');
                    string name = splittedRecord[0];
                    int age = int.Parse(splittedRecord[1]);
                    double fscMarks = double.Parse(splittedRecord[2]);
                    double ecatMarks = double.Parse(splittedRecord[3]);
                    string[] splittedRecordForPreference = splittedRecord[4].Split(';');
                    List<DegreeProgram> pref = new List<DegreeProgram>();
                    for (int x = 0; x < splittedRecordForPreference.Length; x++)
                    {
                        DegreeProgram d = DegreeCRUD.GetDegreeByName(splittedRecordForPreference[x]);
                        if (d != null)
                        {
                            if (!(pref.Contains(d)))
                                pref.Add(d);
                        }
                    }
                    Student s = new Student(name, age, fscMarks, ecatMarks);
                    s.preferences = pref;
                    studentList.Add(s);
                }
                f.Close();

            }
        }
        public static void writeData(Student s)
        {
            using (StreamWriter f = new StreamWriter("Student.txt", true))
            {
                f.WriteLine();
                f.Write($"{s.name},{s.age},{s.FSCMarks},{s.EcatMarks},");

                for (int x = 0; x < s.preferences.Count; x++)
                {
                    f.Write(s.preferences[x].title);
                    if (x < s.preferences.Count - 1)
                    {
                        f.Write(";");
                    }
                }

            }
        }

    }
}

