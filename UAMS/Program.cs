using System.Data.SqlTypes;
using System.Numerics;
using UAMS.BL;

namespace UAMS
{
    class Program
    {
        public static List<Student> studentlist = new List<Student>();
        static void Main(string[] args) 
        {
            Console.WriteLine();
        }


        static Student StudentPresent(string name)
        {
            foreach(Student stu in studentlist)
                if (name == stu.name)
                    return stu;
            return null;
        }

        static void CalculateFeeForAll()
        {
            foreach (Student s in studentlist)
            {
                Console.WriteLine($"{s.name} has {s.CalculateFee()} fees");
            }
        }

        static void RegSubjects(Student stu)
        {
            Console.Write("How many subjects do you want to register: ");
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Enter subject code: ");
                string code = Console.ReadLine();
                bool flag = 
                foreach(Subject sub in stu.regDegree.subjects)
                {
                    if(sub.code == code && !stu.regSubjects.Contains(sub))
                    {
                        stu.RegStudentSubject(sub);
                        Fla

                    }
                }
            }
        }
    }
}