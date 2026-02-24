using Lab1_PKIS;
using System;
using System.Diagnostics;

namespace Lab1_PKIS
{
    class Program
    {
        static void Main()
        {
            Student student = new Student();
            Console.WriteLine("ToShortString()");
            Console.WriteLine(student.ToShortString());

            Console.WriteLine("\nIndexer");
            Console.WriteLine($"Master: {student[Education.Master]}");
            Console.WriteLine($"Bachelor: {student[Education.Bachelor]}");
            Console.WriteLine($"SecondEducation: {student[Education.SecondEducation]}");


            student = new Student(
                new Person("Oleksandr", "Kochala", new DateTime(2005, 10, 17)),
                Education.Bachelor,
                305
            );

            Console.WriteLine("\nToString() after adding");
            Console.WriteLine(student.ToString());

            Exam e1 = new Exam("Math", 95, DateTime.Now);
            Exam e2 = new Exam("Physics", 88, DateTime.Now);
            Exam e3 = new Exam("Programming", 100, DateTime.Now);

            student.AddExams(e1, e2, e3);

            Console.WriteLine("\nafter AddExams()");
            Console.WriteLine(student.ToString());
            
            const int n = 500;
            int total = n * n;

            Stopwatch sw = new Stopwatch();

            Exam[] arr1D = new Exam[total];
            sw.Start();
            for (int i = 0; i < arr1D.Length; i++)
                arr1D[i] = new Exam();
            sw.Stop();
            Console.WriteLine($"\n1D array time: {sw.ElapsedMilliseconds} ms");



            sw.Reset();
            Exam[,] arr2D = new Exam[n, n];
            sw.Start();
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    arr2D[i, j] = new Exam();
            sw.Stop();
            Console.WriteLine($"2D rectangular time: {sw.ElapsedMilliseconds} ms");

            sw.Reset();
            Exam[][] jagged = new Exam[n][];
            for (int i = 0; i < n; i++)
                jagged[i] = new Exam[n];

            sw.Start();
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    jagged[i][j] = new Exam();
            sw.Stop();
            Console.WriteLine($"Jagged array time: {sw.ElapsedMilliseconds} ms");
        }
    }
}
