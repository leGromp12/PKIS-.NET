using System;
using System.Text;

namespace Lab5_PKIS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            StudentCollection firstCollection = new StudentCollection("Перша колекція");
            StudentCollection secondCollection = new StudentCollection("Друга колекція");

            Journal firstJournal = new Journal();
            Journal secondJournal = new Journal();

            firstCollection.StudentCountChanged += firstJournal.StudentCountChanged;
            firstCollection.StudentReferenceChanged += firstJournal.StudentReferenceChanged;

            firstCollection.StudentCountChanged += secondJournal.StudentCountChanged;
            firstCollection.StudentReferenceChanged += secondJournal.StudentReferenceChanged;
            secondCollection.StudentCountChanged += secondJournal.StudentCountChanged;
            secondCollection.StudentReferenceChanged += secondJournal.StudentReferenceChanged;

            firstCollection.AddDefaults();
            secondCollection.AddStudents(
                CreateStudent("Roman", "Tkachenko", new DateTime(2001, 4, 6), Education.Bachelor, 208, 4, 5),
                CreateStudent("Iryna", "Moroz", new DateTime(2000, 7, 15), Education.Master, 312, 5, 5),
                CreateStudent("Nazar", "Lysenko", new DateTime(2002, 12, 2), Education.Specialist, 418, 3, 4));

            firstCollection.Remove(1);
            secondCollection.Remove(0);
            secondCollection.Remove(100);

            firstCollection[0] = CreateStudent("Sofia", "Rudenko", new DateTime(1999, 10, 9), Education.Master, 501, 5, 4);

            Student replacement = CreateStudent("Dmytro", "Savchenko", new DateTime(2001, 1, 19), Education.Bachelor, 219, 4, 4);
            secondCollection[1] = replacement;

            firstCollection[0].GroupNumber = 502;

            Console.WriteLine("Перший журнал");
            Console.WriteLine(firstJournal);

            Console.WriteLine("Другий журнал");
            Console.WriteLine(secondJournal);
        }

        private static Student CreateStudent(string name, string surname, DateTime birthday, Education education, int groupNumber, int firstGrade, int secondGrade)
        {
            Student student = new Student(new Person(name, surname, birthday), education, groupNumber);
            student.AddTests(new Test("Mathematics", firstGrade > 2), new Test("Programming", secondGrade > 2));
            student.AddExams(
                new Exam("Mathematics", firstGrade, new DateTime(2024, 1, 10)),
                new Exam("Programming", secondGrade, new DateTime(2024, 1, 20)));
            return student;
        }
    }
}
