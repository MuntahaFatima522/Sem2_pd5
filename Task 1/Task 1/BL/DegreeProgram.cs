using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1.BL
{
    internal class DegreeProgram
    {
        public string title;
        public int duration;
        public int seats;
        public double merit;
        public List<Subject> subjects;
        public DegreeProgram(string title, int duration, int seats, double merit)
        {
            this.title = title;
            this.duration = duration;
            this.seats = seats;
            this.merit = merit;
            subjects = new List<Subject>();
        }

        public Subject GetSubjectbyCode(string code)
        {
            foreach (Subject subject in subjects)
            {
                if (subject.code == code)
                    return subject;
            }
            return null;
        }
        public void AddSubject(Subject subject)
        {
            subjects.Add(subject);
        }
    }
}
