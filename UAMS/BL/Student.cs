using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAMS.BL
{
    public class Student
    {
        public string name;
        public int age;
        public int matricMarks;
        public int ecatMarks;
        public int fscMarks;
        public double merit;
        public List<Subject> regSubjects;
        public List<Degree> preferences;
        public Degree regDegree;

        public Student() { }
        public Student(string name, int age, int matricmarks, int ecatMarks, int fscMarks)
        {
            this.name = name;
            this.age = age;
            matricMarks = matricmarks;
            this.ecatMarks = ecatMarks;
            this.fscMarks = fscMarks;
        }
        public void CalculateMerit()
        {
            this.merit = (((fscMarks/1100)*0.45F)+((ecatMarks/400)*0.55F))*100F;
        }
        public int GetCreditHours()
        {
            int creditHours = 0;
            foreach (Subject s in regSubjects)
            {
                creditHours += s.creditHour;
            }
            return creditHours;
        }
        public bool RegStudentSubject(Subject sub)
        {
            int stCH = GetCreditHours();
            if(regDegree != null && regDegree.isSubjectExists(sub) && (stCH+sub.creditHour) <= 9)
            {
                regSubjects.Add(sub);
                return true;
            }
            return false;
        }
        public float CalculateFee()
        {
            float fee = 0;
            if (regDegree != null)
                foreach(Subject s in regSubjects)
                    fee += s.subjectFee;
            return fee;
        }
    }
}
