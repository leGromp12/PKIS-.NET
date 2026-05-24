using System;

namespace Lab5_PKIS
{
    public delegate void StudentListHandler(object source, StudentListHandlerEventArgs args);

    public class StudentListHandlerEventArgs : EventArgs
    {
        public string CollectionName { get; set; }
        public string ChangeInfo { get; set; }
        public Student Student { get; set; }

        public StudentListHandlerEventArgs()
        {
            CollectionName = "";
            ChangeInfo = "";
            Student = null;
        }

        public StudentListHandlerEventArgs(string collectionName, string changeInfo, Student student)
        {
            CollectionName = collectionName;
            ChangeInfo = changeInfo;
            Student = student;
        }

        public override string ToString()
        {
            string studentInfo = Student == null ? "" : Student.ToShortString();
            return string.Format("Колекція: {0}, зміна: {1}, студент: {2}", CollectionName, ChangeInfo, studentInfo);
        }
    }
}
