using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_1.UI;

namespace Task_1.BL
{
    internal class Student
    {
        public string name;
        public int age;
        public double FSCMarks;
        public double EcatMarks;
        public double merit;
        public bool isRegistered;
        public List<DegreeProgram> preferences;
        public List<Subject> RegSubjects;
        public DegreeProgram regDegree;

        public Student(string name, int age, double FSCMarks, double EcatMarks)
        {
            this.name = name;
            this.age = age;
            this.FSCMarks = FSCMarks;
            this.EcatMarks = EcatMarks;
            merit = ((FSCMarks / 12) * 0.5) + ((EcatMarks / 4) * 0.5);
            isRegistered = false;
            preferences = new List<DegreeProgram>();
            RegSubjects = new List<Subject>();
        }
        public void registeredDegree()
        {
            foreach (DegreeProgram degree in preferences)
            {
                if (merit >= degree.merit)
                {
                    regDegree = degree;
                    isRegistered = true;
                    break;
                }
            }
        }
        public void registerSubjects(List<Subject>  SubList)
        {
            RegSubjects = SubList;
        }
        public double SubjectsFees()
        {
            double sum = 0;
            foreach (Subject subject in RegSubjects)
            {
                sum += subject.subjectFee;
            }
            return sum;
        }
    }
}
