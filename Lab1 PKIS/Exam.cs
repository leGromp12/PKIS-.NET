using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1_PKIS
{
    public enum Education
    {
        Master,
        Bachelor,
        SecondEducation
    }

    public class Exam
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
            Subject = "Programming";
            Grade = 100;
            ExamDate = DateTime.Now;
        }

        public override string ToString()
        {
            return $"Subject: {Subject}, Grade: {Grade}, Date: {ExamDate.ToShortDateString()}";
        }
    }
}
