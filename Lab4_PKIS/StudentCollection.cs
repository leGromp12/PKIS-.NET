using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab4_PKIS
{
    public class StudentCollection
    {
        private List<Student> students;

        public StudentCollection()
        {
            students = new List<Student>();
        }

        public double MaxAverageGrade
        {
            get
            {
                if (students.Count == 0)
                {
                    return 0;
                }

                return students.Max(AverageGradeSelector);
            }
        }

        public IEnumerable<Student> MasterStudents
        {
            get { return students.Where(MasterSelector); }
        }

        public static double AverageGradeSelector(Student student)
        {
            return student.AverageGrade;
        }

        public static bool MasterSelector(Student student)
        {
            return student.Education == Education.Master;
        }

        public void AddDefaults()
        {
            Student first = new Student(new Person("Ivan", "Shevchenko", new DateTime(2001, 5, 12)), Education.Bachelor, 101);
            first.AddTests(new Test("Mathematics", true), new Test("Programming", true));
            first.AddExams(new Exam("Mathematics", 5, new DateTime(2024, 1, 12)), new Exam("Programming", 4, new DateTime(2024, 1, 18)));

            Student second = new Student(new Person("Olena", "Bondarenko", new DateTime(1999, 9, 3)), Education.Master, 204);
            second.AddTests(new Test("Databases", true), new Test("Algorithms", true));
            second.AddExams(new Exam("Databases", 5, new DateTime(2024, 1, 14)), new Exam("Algorithms", 5, new DateTime(2024, 1, 20)));

            Student third = new Student(new Person("Andrii", "Koval", new DateTime(2002, 2, 25)), Education.Master, 305);
            third.AddTests(new Test("Physics", true), new Test("English", false));
            third.AddExams(new Exam("Physics", 3, new DateTime(2024, 1, 10)), new Exam("English", 4, new DateTime(2024, 1, 22)));

            Student fourth = new Student(new Person("Marta", "Melnyk", new DateTime(2000, 11, 8)), Education.Specialist, 407);
            fourth.AddTests(new Test("Economics", true), new Test("Statistics", true));
            fourth.AddExams(new Exam("Economics", 4, new DateTime(2024, 1, 15)), new Exam("Statistics", 5, new DateTime(2024, 1, 24)));

            AddStudents(first, second, third, fourth);
        }

        public void AddStudents(params Student[] newStudents)
        {
            students.AddRange(newStudents);
        }

        public void SortBySurname()
        {
            students.Sort();
        }

        public void SortByBirthday()
        {
            students.Sort(new Person());
        }

        public void SortByAverageGrade()
        {
            students.Sort(new StudentAverageGradeComparer());
        }

        public List<Student> AverageMarkGroup(double value)
        {
            return students
                .GroupBy(AverageGradeSelector)
                .Where(group => group.Key == value)
                .SelectMany(group => group)
                .ToList();
        }

        public IEnumerable<IGrouping<double, Student>> AverageMarkGroups()
        {
            return students.GroupBy(AverageGradeSelector);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            foreach (Student student in students)
            {
                builder.AppendLine(student.ToString());
            }

            return builder.ToString();
        }

        public string ToShortString()
        {
            StringBuilder builder = new StringBuilder();

            foreach (Student student in students)
            {
                builder.AppendLine(student.ToShortString());
            }

            return builder.ToString();
        }
    }
}
