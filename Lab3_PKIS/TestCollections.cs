using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Lab3_PKIS
{
    public class TestCollections
    {
        private List<Person> personList;
        private List<string> stringList;
        private Dictionary<Person, Student> personDictionary;
        private Dictionary<string, Student> stringDictionary;

        public TestCollections(int count)
        {
            personList = new List<Person>(count);
            stringList = new List<string>(count);
            personDictionary = new Dictionary<Person, Student>(count);
            stringDictionary = new Dictionary<string, Student>(count);

            for (int i = 0; i < count; i++)
            {
                Student student = GenerateStudent(i);
                Person key = student.PersonData;
                string stringKey = key.ToString();

                personList.Add(key);
                stringList.Add(stringKey);
                personDictionary.Add(key, student);
                stringDictionary.Add(stringKey, student);
            }
        }

        public static Student GenerateStudent(int value)
        {
            Student student = new Student(
                new Person("Name" + value, "Surname" + value, new DateTime(1980 + value % 30, value % 12 + 1, value % 28 + 1)),
                (Education)(value % 3),
                101 + value % 599);

            student.AddTests(
                new Test("Mathematics" + value, value % 2 == 0),
                new Test("Programming" + value, true));

            student.AddExams(
                new Exam("Mathematics" + value, 3 + value % 3, new DateTime(2024, value % 12 + 1, value % 28 + 1)),
                new Exam("Programming" + value, 4 + value % 2, new DateTime(2024, value % 12 + 1, (value + 1) % 28 + 1)));

            return student;
        }

        public void MeasureSearchTime()
        {
            int first = 0;
            int middle = personList.Count / 2;
            int last = personList.Count - 1;
            int absent = personList.Count;

            MeasureElement("Перший", GenerateStudent(first));
            MeasureElement("Центральний", GenerateStudent(middle));
            MeasureElement("Останній", GenerateStudent(last));
            MeasureElement("Відсутній", GenerateStudent(absent));
        }

        private void MeasureElement(string title, Student student)
        {
            Person key = student.PersonData;
            string stringKey = key.ToString();

            Console.WriteLine();
            Console.WriteLine(title + " елемент");
            PrintSearchTime("List<Person>.Contains", delegate { return personList.Contains(key); });
            PrintSearchTime("List<string>.Contains", delegate { return stringList.Contains(stringKey); });
            PrintSearchTime("Dictionary<Person, Student>.ContainsKey", delegate { return personDictionary.ContainsKey(key); });
            PrintSearchTime("Dictionary<Person, Student>.ContainsValue", delegate { return personDictionary.ContainsValue(student); });
            PrintSearchTime("Dictionary<string, Student>.ContainsKey", delegate { return stringDictionary.ContainsKey(stringKey); });
        }

        private void PrintSearchTime(string operationName, Func<bool> search)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            bool found = search();
            stopwatch.Stop();

            Console.WriteLine("{0}: знайдено = {1}, час = {2} ticks", operationName, found, stopwatch.ElapsedTicks);
        }
    }
}
