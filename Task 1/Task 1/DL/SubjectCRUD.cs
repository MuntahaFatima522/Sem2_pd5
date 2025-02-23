using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1.BL;

namespace Task_1.DL
{
    internal class SubjectCRUD
    {
        static List<Subject> subjects = new List<Subject>();

        public static Subject GetSubjectByName(string name)
        {
            for (int i = 0; i < subjects.Count; i++)
            {
                if (name == subjects[i].subjectType) return subjects[i];
            }
            return null;
        }
        public static void readFromFile()
        {
            StreamReader f = new StreamReader("Subject.txt");
            string record;
            if (File.Exists("Subject.txt"))
            {
                while ((record = f.ReadLine()) != null)
                {
                    string[] splittedRecord = record.Split(','); 
                    string code = splittedRecord[0];
                    string type = splittedRecord[1];
                    int creditHours = int.Parse(splittedRecord[2]);
                    int subjectFees = int.Parse(splittedRecord[3]);
                    Subject s = new Subject(code,  creditHours,type, subjectFees);
                    addSubjectIntoList(s);
                }
                f.Close();
            }
        }
        public static void writeData(Subject s)
        {
            using (StreamWriter f = new StreamWriter("Subject.txt", true))
            {
                f.WriteLine();
                f.Write($"{s.code},{s.subjectType},{s.creditHours},{s.subjectFee}");
            }
        }
        public static void addSubjectIntoList(Subject s)
        {
            subjects.Add(s);
        }
    }
}
