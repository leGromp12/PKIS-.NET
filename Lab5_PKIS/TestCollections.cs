using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;

namespace Lab5_PKIS
{
    public class TestCollections
    {
        private List<Person> standardPersonList;
        private List<string> standardStringList;
        private Dictionary<Person, Student> standardPersonDictionary;
        private Dictionary<string, Student> standardStringDictionary;
        private ImmutableList<Person> immutablePersonList;
        private ImmutableList<string> immutableStringList;
        private ImmutableDictionary<Person, Student> immutablePersonDictionary;
        private ImmutableDictionary<string, Student> immutableStringDictionary;
        private SortedList<Person, Student> sortedPersonList;
        private SortedList<string, Student> sortedStringList;
        private SortedDictionary<Person, Student> sortedPersonDictionary;
        private SortedDictionary<string, Student> sortedStringDictionary;

        public TestCollections(int count)
        {
            standardPersonList = new List<Person>(count);
            standardStringList = new List<string>(count);
            standardPersonDictionary = new Dictionary<Person, Student>(count);
            standardStringDictionary = new Dictionary<string, Student>(count);
            sortedPersonList = new SortedList<Person, Student>();
            sortedStringList = new SortedList<string, Student>();
            sortedPersonDictionary = new SortedDictionary<Person, Student>();
            sortedStringDictionary = new SortedDictionary<string, Student>();

            ImmutableList<Person>.Builder immutablePersonListBuilder = ImmutableList.CreateBuilder<Person>();
            ImmutableList<string>.Builder immutableStringListBuilder = ImmutableList.CreateBuilder<string>();
            ImmutableDictionary<Person, Student>.Builder immutablePersonDictionaryBuilder = ImmutableDictionary.CreateBuilder<Person, Student>();
            ImmutableDictionary<string, Student>.Builder immutableStringDictionaryBuilder = ImmutableDictionary.CreateBuilder<string, Student>();

            for (int i = 0; i < count; i++)
            {
                Student student = GenerateStudent(i);
                Person key = student.PersonData;
                string stringKey = key.ToString();

                standardPersonList.Add(key);
                standardStringList.Add(stringKey);
                standardPersonDictionary.Add(key, student);
                standardStringDictionary.Add(stringKey, student);
                immutablePersonListBuilder.Add(key);
                immutableStringListBuilder.Add(stringKey);
                immutablePersonDictionaryBuilder.Add(key, student);
                immutableStringDictionaryBuilder.Add(stringKey, student);
                sortedPersonList.Add(key, student);
                sortedStringList.Add(stringKey, student);
                sortedPersonDictionary.Add(key, student);
                sortedStringDictionary.Add(stringKey, student);
            }

            immutablePersonList = immutablePersonListBuilder.ToImmutable();
            immutableStringList = immutableStringListBuilder.ToImmutable();
            immutablePersonDictionary = immutablePersonDictionaryBuilder.ToImmutable();
            immutableStringDictionary = immutableStringDictionaryBuilder.ToImmutable();
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
            int middle = standardPersonList.Count / 2;
            int last = standardPersonList.Count - 1;
            int absent = standardPersonList.Count;

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
            PrintComparison(
                "Person list/key search",
                delegate { return standardPersonList.Contains(key); },
                delegate { return immutablePersonList.Contains(key); },
                delegate { return sortedPersonList.ContainsKey(key); });
            PrintComparison(
                "String list/key search",
                delegate { return standardStringList.Contains(stringKey); },
                delegate { return immutableStringList.Contains(stringKey); },
                delegate { return sortedStringList.ContainsKey(stringKey); });
            PrintComparison(
                "Dictionary<Person, Student>.ContainsKey",
                delegate { return standardPersonDictionary.ContainsKey(key); },
                delegate { return immutablePersonDictionary.ContainsKey(key); },
                delegate { return sortedPersonDictionary.ContainsKey(key); });
            PrintComparison(
                "Dictionary<Person, Student>.ContainsValue",
                delegate { return standardPersonDictionary.ContainsValue(student); },
                delegate { return immutablePersonDictionary.ContainsValue(student); },
                delegate { return sortedPersonDictionary.ContainsValue(student); });
            PrintComparison(
                "Dictionary<string, Student>.ContainsKey",
                delegate { return standardStringDictionary.ContainsKey(stringKey); },
                delegate { return immutableStringDictionary.ContainsKey(stringKey); },
                delegate { return sortedStringDictionary.ContainsKey(stringKey); });
        }

        private void PrintComparison(string operationName, Func<bool> standardSearch, Func<bool> immutableSearch, Func<bool> sortedSearch)
        {
            SearchResult standard = Measure(standardSearch);
            SearchResult immutable = Measure(immutableSearch);
            SearchResult sorted = Measure(sortedSearch);

            Console.WriteLine(operationName);
            Console.WriteLine("  Standard:  знайдено = {0}, час = {1} ticks", standard.Found, standard.Ticks);
            Console.WriteLine("  Immutable: знайдено = {0}, час = {1} ticks", immutable.Found, immutable.Ticks);
            Console.WriteLine("  Sorted:    знайдено = {0}, час = {1} ticks", sorted.Found, sorted.Ticks);
        }

        private SearchResult Measure(Func<bool> search)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            bool found = search();
            stopwatch.Stop();

            return new SearchResult(found, stopwatch.ElapsedTicks);
        }

        private struct SearchResult
        {
            public bool Found { get; private set; }
            public long Ticks { get; private set; }

            public SearchResult(bool found, long ticks)
            {
                Found = found;
                Ticks = ticks;
            }
        }
    }
}
