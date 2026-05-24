using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab4_PKIS
{
    public class Student : Person, IDateAndCopy, IEnumerable
    {
        private Education education;
        private int groupNumber;
        private List<Test> tests;
        private List<Exam> exams;

        public Student(Person person, Education education, int groupNumber)
            : base(person.Name, person.Surname, person.Birthday)
        {
            this.education = education;
            GroupNumber = groupNumber;
            tests = new List<Test>();
            exams = new List<Exam>();
        }

        public Student()
            : base()
        {
            education = Education.Bachelor;
            groupNumber = 101;
            tests = new List<Test>();
            exams = new List<Exam>();
        }

        public Person PersonData
        {
            get { return new Person(name, surname, birthday); }
            set
            {
                name = value.Name;
                surname = value.Surname;
                birthday = value.Birthday;
            }
        }

        public Education Education
        {
            get { return education; }
            set { education = value; }
        }

        public double AverageGrade
        {
            get
            {
                if (exams.Count == 0)
                {
                    return 0;
                }

                double sum = 0;

                foreach (Exam exam in exams)
                {
                    sum += exam.Grade;
                }

                return sum / exams.Count;
            }
        }

        public List<Exam> Exams
        {
            get { return exams; }
            set { exams = value; }
        }

        public List<Test> Tests
        {
            get { return tests; }
            set { tests = value; }
        }

        public int GroupNumber
        {
            get { return groupNumber; }
            set
            {
                if (value <= 100 || value > 699)
                {
                    throw new ArgumentOutOfRangeException("GroupNumber", "Group number must be > 100 and <= 699");
                }

                groupNumber = value;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return new StudentEnumerator(tests, exams);
        }

        public void AddExams(params Exam[] newExams)
        {
            foreach (Exam exam in newExams)
            {
                exams.Add(exam);
            }
        }

        public void AddTests(params Test[] newTests)
        {
            foreach (Test test in newTests)
            {
                tests.Add(test);
            }
        }

        public IEnumerable GetPassed()
        {
            foreach (Test test in tests)
            {
                if (test.IsPassed)
                {
                    yield return test;
                }
            }

            foreach (Exam exam in exams)
            {
                if (exam.Grade > 2)
                {
                    yield return exam;
                }
            }
        }

        public IEnumerable GetPassedTestsWithExams()
        {
            foreach (Test test in tests)
            {
                if (!test.IsPassed)
                {
                    continue;
                }

                foreach (Exam exam in exams)
                {
                    if (exam.Subject == test.Subject && exam.Grade > 2)
                    {
                        yield return test;
                        break;
                    }
                }
            }
        }

        public IEnumerable GetAll()
        {
            foreach (Test test in tests)
            {
                yield return test;
            }

            foreach (Exam exam in exams)
            {
                yield return exam;
            }
        }

        public IEnumerable GetExamsHigherThan(int minGrade)
        {
            foreach (Exam exam in exams)
            {
                if (exam.Grade > minGrade)
                {
                    yield return exam;
                }
            }
        }

        public override string ToString()
        {
            string testInfo = "";
            string examInfo = "";

            foreach (Test test in tests)
            {
                testInfo += test + Environment.NewLine;
            }

            foreach (Exam exam in exams)
            {
                examInfo += exam + Environment.NewLine;
            }

            return string.Format(
                "Student: {0} {1}{2}Birthday: {3}{2}Education: {4}{2}Group: {5}{2}Tests:{2}{6}Exams:{2}{7}",
                name,
                surname,
                Environment.NewLine,
                birthday.ToShortDateString(),
                education,
                groupNumber,
                testInfo,
                examInfo);
        }

        public override string ToShortString()
        {
            return string.Format(
                "Student: {0} {1}, Birthday: {2}, Education: {3}, Group: {4}, Average: {5:F2}, Tests: {6}, Exams: {7}",
                name,
                surname,
                birthday.ToShortDateString(),
                education,
                groupNumber,
                AverageGrade,
                tests.Count,
                exams.Count);
        }

        public override object DeepCopy()
        {
            Student copy = new Student(new Person(name, surname, birthday), education, groupNumber);

            foreach (Test test in tests)
            {
                copy.tests.Add(new Test(test.Subject, test.IsPassed));
            }

            foreach (Exam exam in exams)
            {
                copy.exams.Add((Exam)exam.DeepCopy());
            }

            return copy;
        }
    }
}
