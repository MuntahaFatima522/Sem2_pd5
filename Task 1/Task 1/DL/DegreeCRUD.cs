using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1.UI;
using Task_1.BL;
using System.IO;

namespace Task_1.DL
{
    internal class DegreeCRUD
    {
        static public List<DegreeProgram> DegreesList=new List<DegreeProgram>();
        public static DegreeProgram checkAvailabilityOfPreferenceDegree(string degreeName)
        {
            foreach (DegreeProgram degree in DegreesList)
            {
                if (degree.title == degreeName)
                {
                    return degree;
                }
            }
            return null;
        }
        public static DegreeProgram GetDegreeByName(string name)
        {
            for (int i = 0; i < DegreesList.Count; i++)
            {
                if (DegreesList[i].title == name)
                {
                    return DegreesList[i];
                }
            }
            return null;
        }

        public static void AddDegree(DegreeProgram NewDegree)
        {
            DegreesList.Add(NewDegree);
        }
        public static void readFromFile()
        {
            StreamReader f = new StreamReader("Degree.txt"); 
            string record;
            if (File.Exists("Degree.txt"))
            {
                while ((record = f.ReadLine()) != null)
                {
                    string[] splittedRecord = record.Split(',');
                    string degreeName = splittedRecord[0];
                    int degreeDuration = int.Parse(splittedRecord[1]);
                    int seats= int.Parse(splittedRecord[2]);
                    double merit = double.Parse(splittedRecord[3]);
                    string[] splittedRecordForSubject = splittedRecord[4].Split(';');
                    DegreeProgram d = new DegreeProgram(degreeName, degreeDuration, seats,merit);
                    for (int x = 0; x < splittedRecordForSubject.Length; x++)
                    {

                        Subject s = SubjectCRUD.GetSubjectByName(splittedRecordForSubject[x]);
                        if (s != null)
                        {
                            d.AddSubject(s);
                        }
                    }
                    DegreesList.Add(d);
                }
                f.Close();
            }
            
        }
        public static void writeData(DegreeProgram d)
        {
            using (StreamWriter f = new StreamWriter("Degree.txt", true))
            {
                f.WriteLine();
                f.Write($"{d.title},{d.duration},{d.seats},{d.merit},");

                for (int x = 0; x < d.subjects.Count; x++)
                {
                    f.Write(d.subjects[x].subjectType);
                    if (x < d.subjects.Count - 1)
                    {
                        f.Write(";");
                    }
                }

            }
        }
    }
}
