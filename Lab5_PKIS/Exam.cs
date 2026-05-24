using System;

namespace Lab5_PKIS
{
    public class Exam : IDateAndCopy
    {
        public string Subject { get; set; }
        public int Grade { get; set; }
        public DateTime ExamDate { get; set; }

        public Exam(string subject, int grade, DateTime examDate)
        {
            Subject = subject;
            Grade = grade;
            ExamDate = examDate;
        }

        public Exam()
        {
            Subject = "Subject";
            Grade = 5;
            ExamDate = DateTime.Today;
        }

        public DateTime Date
        {
            get { return ExamDate; }
            set { ExamDate = value; }
        }

        public override string ToString()
        {
            return string.Format("Subject: {0}, Grade: {1}, Date: {2}", Subject, Grade, ExamDate.ToShortDateString());
        }

        public object DeepCopy()
        {
            return new Exam(Subject, Grade, ExamDate);
        }
    }
}
