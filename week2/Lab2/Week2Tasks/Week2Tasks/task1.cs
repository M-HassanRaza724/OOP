using System;

namespace Week2Tasks
{
	public class Student
	{
		public string name;
		public float matricMarks;
		public float fscMarks;
		public float ecatMarks;
		public float aggregate;
		public Student[] students = new Student[10];
		public int lastStudentIdx = 0;

		public Student(string Name,float mMarks,float fMarks,float eMarks)
		{
			name = Name;
			matricMarks = mMarks;
			fscMarks = fMarks;
			ecatMarks = eMarks;
		}
		public float aggCal()
		{
			aggregate = (0.17F * matricMarks / 1100) + (0.5F * fscMarks / 1200) + (0.33F * ecatMarks / 400);

			return aggregate;
		}
	}

}