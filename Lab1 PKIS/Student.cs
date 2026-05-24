using System;
using System.Collections;

namespace Lab1_PKIS
{
    public class Student : Person, IDateAndCopy, IEnumerable
    {
        private Education education;
        private int groupNumber;
        private ArrayList tests;
        private ArrayList exams;

        public IEnumerator GetEnumerator()
        {
            return new StudentEnumerator(tests, exams);
        }

        public IEnumerable GetPassed()
        {
            foreach (Test t in tests)
            {
                if (t.IsPassed)
                    yield return t;
            }

            foreach (Exam e in exams)
            {
                if (e.Grade > 2)
                    yield return e;
            }
        }

        public IEnumerable GetPassedTestsWithExams()
        {
            foreach (Test t in tests)
            {
                if (!t.IsPassed) continue;

                foreach (Exam e in exams)
                {
                    if (e.Subject == t.Subject && e.Grade > 2)
                    {
                        yield return t;
                        break;
                    }
                }
            }
        }

        public Student(Person person, Education education, int groupNumber)
            : base(person.Name, person.Surname, person.Birthday)
        {
            this.education = education;
            GroupNumber = groupNumber;
            this.tests = new ArrayList();
            this.exams = new ArrayList();
        }

        public Student()
            : base()
        {
            education = Education.Bachelor;
            groupNumber = 101;
            tests = new ArrayList();
            exams = new ArrayList();
        }

        public Person PersonData
        {
            get { return new Person(name, surname, birthday); }
            init
            {
                name = value.Name;
                surname = value.Surname;
                birthday = value.Birthday;
            }
        }

        public double AverageGrade
        {
            get
            {
                if (exams.Count == 0) return 0;

                double sum = 0;
                foreach (Exam e in exams)
                    sum += e.Grade;

                return sum / exams.Count;
            }
        }

        public ArrayList Exams
        {
            get { return exams; }
            init { exams = value; }
        }

        public ArrayList Tests
        {
            get { return tests; }
            init { tests = value; }
        }

        public void AddExams(params Exam[] newExams)
        {
            foreach (var e in newExams)
                exams.Add(e);
        }

        public int GroupNumber
        {
            get { return groupNumber; }
            init
            {
                if (value <= 100 || value > 699)
                    throw new ArgumentOutOfRangeException(
                        "GroupNumber",
                        "Group number must be > 100 and <= 699"
                    );

                groupNumber = value;
            }
        }

        public override string ToString()
        {
            string examInfo = "";
            foreach (Exam e in exams)
                examInfo += e.ToString() + "\n";

            string testInfo = "";
            foreach (Test t in tests)
                testInfo += t.ToString() + "\n";

            return $"Student: {name} {surname}\n" +
                   $"Birthday: {birthday.ToShortDateString()}\n" +
                   $"Education: {education}\n" +
                   $"Group: {groupNumber}\n" +
                   $"Tests:\n{testInfo}" +
                   $"Exams:\n{examInfo}";
        }

        public override string ToShortString()
        {
            return $"Student: {name} {surname}, " +
                   $"Birthday: {birthday.ToShortDateString()}, " +
                   $"Education: {education}, " +
                   $"Group: {groupNumber}, " +
                   $"Average: {AverageGrade:F2}";
        }

        public override object DeepCopy()
        {
            Student copy = new Student(
                new Person(name, surname, birthday),
                education,
                groupNumber
            );

            foreach (Test t in tests)
                copy.tests.Add(new Test(t.Subject, t.IsPassed));

            foreach (Exam e in exams)
                copy.exams.Add((Exam)e.DeepCopy());

            return copy;
        }

        public IEnumerable GetAll()
        {
            foreach (var t in tests)
                yield return t;

            foreach (var e in exams)
                yield return e;
        }

        public IEnumerable GetExamsHigherThan(int minGrade)
        {
            foreach (Exam e in exams)
            {
                if (e.Grade > minGrade)
                    yield return e;
            }
        }
    }
}
