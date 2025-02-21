using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAMS.BL
{
    public class Degree
    {
        public string degreeName;
        public int degreeDuration;
        public List<Subject> subjects;
        public int seats;

        public Degree() { }
        public Degree(string degreeName, int degreeDuration, int seats)
        {
            this.degreeName = degreeName;
            this.degreeDuration = degreeDuration;
            this.seats = seats;
            subjects = new List<Subject>();
        }
        
        public int CalculateCreditHours()
        {
            int creditHours = 0;
            foreach (Subject s in subjects)
            {
                creditHours += s.creditHour;
            }
            return creditHours;
        }
        public bool AddSubject(Subject subject)
        {
            if (CalculateCreditHours()+subject.creditHour <= 20)
            {
                subjects.Add(subject);
                return true;
            }
            return false;
        }
        public bool isSubjectExists(Subject subject)
        {
            foreach (Subject s in subjects)
            {
                if (s.code == subject.code) return true;
            }
            return false;
        }
    }
}
