using System;

namespace Lab1_PKIS
{
    class Program
    {
        static void Main()
        {
            Person p1 = new Person("Ivan", "Petrenko", new DateTime(2000, 1, 1));
            Person p2 = new Person("Ivan", "Petrenko", new DateTime(2000, 1, 1));

            Console.WriteLine("ReferenceEquals: " + ReferenceEquals(p1, p2));
            Console.WriteLine("Equals: " + p1.Equals(p2));
            Console.WriteLine("Hash1: " + p1.GetHashCode());
            Console.WriteLine("Hash2: " + p2.GetHashCode());

            Student st = new Student(p1, Education.Master, 200);

            st.AddExams(
                new Exam("Math", 5, DateTime.Now),
                new Exam("Physics", 3, DateTime.Now),
                new Exam("Programming", 4, DateTime.Now)
            );

            st.Exams.Add(new Exam("English", 2, DateTime.Now));

            st.Tests.Add(new Test("Math", true));
            st.Tests.Add(new Test("Physics", false));

            Console.WriteLine("\n=== Student ===");
            Console.WriteLine(st.ToString());

            Console.WriteLine("\n=== Person from Student ===");
            Console.WriteLine(st.PersonData);

            Student copy = (Student)st.DeepCopy();

            st.AddExams(new Exam("Biology", 2, DateTime.Now));

            Console.WriteLine("\n=== Original ===");
            Console.WriteLine(st.ToString());

            Console.WriteLine("\n=== Copy ===");
            Console.WriteLine(copy.ToString());

            try
            {
                Student bad = new Student(p1, Education.Bachelor, 200) { GroupNumber = 50 };
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nException: " + ex.Message);
            }

            Console.WriteLine("\n=== Exams > 3 ===");
            foreach (Exam e in st.GetExamsHigherThan(3))
            {
                Console.WriteLine(e);
            }

            Console.WriteLine("\n=== Common subjects ===");
            foreach (string s in st)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("\n=== Passed tests and exams ===");
            foreach (var item in st.GetPassed())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\n=== Passed tests with passed exams ===");
            foreach (Test t in st.GetPassedTestsWithExams())
            {
                Console.WriteLine(t);
            }
        }
    }
}
