using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab4_PKIS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            StudentCollection students = new StudentCollection();
            students.AddDefaults();

            Console.WriteLine("Початкова колекція");
            Console.WriteLine(students);

            students.SortBySurname();
            Console.WriteLine("Сортування за прізвищем");
            Console.WriteLine(students.ToShortString());

            students.SortByBirthday();
            Console.WriteLine("Сортування за датою народження");
            Console.WriteLine(students.ToShortString());

            students.SortByAverageGrade();
            Console.WriteLine("Сортування за середнім балом");
            Console.WriteLine(students.ToShortString());

            Console.WriteLine("Максимальний середній бал: {0:F2}", students.MaxAverageGrade);

            Console.WriteLine("Студенти з формою навчання Master");
            foreach (Student student in students.MasterStudents)
            {
                Console.WriteLine(student.ToShortString());
            }

            Console.WriteLine("Групування за середнім балом");
            foreach (IGrouping<double, Student> group in students.AverageMarkGroups())
            {
                Console.WriteLine("Середній бал: {0:F2}", group.Key);

                foreach (Student student in students.AverageMarkGroup(group.Key))
                {
                    Console.WriteLine(student.ToShortString());
                }
            }

            int count = ReadCount();
            TestCollections collections = new TestCollections(count);
            collections.MeasureSearchTime();
        }

        private static int ReadCount()
        {
            while (true)
            {
                Console.Write("Введіть кількість елементів колекцій: ");
                int count;

                if (int.TryParse(Console.ReadLine(), out count) && count >= 3)
                {
                    return count;
                }

                Console.WriteLine("Помилка введення. Введіть ціле число не менше 3.");
            }
        }
    }
}
