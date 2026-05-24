using System.Collections.Generic;

namespace Lab5_PKIS
{
    public class StudentAverageGradeComparer : Comparer<Student>
    {
        public override int Compare(Student x, Student y)
        {
            if (ReferenceEquals(x, y))
            {
                return 0;
            }

            if (ReferenceEquals(x, null))
            {
                return -1;
            }

            if (ReferenceEquals(y, null))
            {
                return 1;
            }

            return x.AverageGrade.CompareTo(y.AverageGrade);
        }
    }
}
