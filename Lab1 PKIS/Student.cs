using Lab1_PKIS;
using System;
using System.Linq;

namespace Lab1_PKIS
{
    public class Student
    {
        private Person person;
        private Education education;
        private int groupNumber;
        private Exam[] exams;

        public Student(Person person, Education education, int groupNumber)
        {
            this.person = person;
            this.education = education;
            this.groupNumber = groupNumber;
            this.exams = new Exam[0];
        }

        public Student()
        {
            person = new Person();
            education = Education.Bachelor;
            groupNumber = 311;
            exams = new Exam[0];
        }

        public Person PersonData
        {
            get { return person; }
            init { person = value; }
        }

        public Education EducationForm
        {
            get { return education; }
            init { education = value; }
        }

        public int GroupNumber
        {
            get { return groupNumber; }
            init { groupNumber = value; }
        }

        public Exam[] Exams
        {
            get { return exams; }
            init { exams = value; }
        }

        public double AverageGrade
        {
            get
            {
                if (exams == null || exams.Length == 0)
                    return 0;

                return exams.Average(e => e.Grade);
            }
        }

        public bool this[Education ed]
        {
            get { return education == ed; }
        }

        public void AddExams(params Exam[] newExams)
        {
            if (newExams == null || newExams.Length == 0)
                return;

            int oldLength = exams.Length;
            Array.Resize(ref exams, oldLength + newExams.Length);

            for (int i = 0; i < newExams.Length; i++)
            {
                exams[oldLength + i] = newExams[i];
            }
        }

        public override string ToString()
        {
            string examInfo = "";

            if (exams.Length == 0)
                examInfo = "No exams";
            else
                foreach (var exam in exams)
                    examInfo += exam.ToString() + "\n";

            return $"Student: {person}\n" +
                   $"Education: {education}\n" +
                   $"Group: {groupNumber}\n" +
                   $"Exams:\n{examInfo}";
        }

        public virtual string ToShortString()
        {
            return $"Student: {person}, " +
                   $"Education: {education}, " +
                   $"Group: {groupNumber}, " +
                   $"Average Grade: {AverageGrade:F2}";
        }
    }
}
