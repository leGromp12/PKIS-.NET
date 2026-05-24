using System.Collections;
using System.Collections.Generic;

namespace Lab3_PKIS
{
    public class StudentEnumerator : IEnumerator
    {
        private List<object> items;
        private int position;

        public StudentEnumerator(List<Test> tests, List<Exam> exams)
        {
            items = new List<object>();

            foreach (Test test in tests)
            {
                items.Add(test);
            }

            foreach (Exam exam in exams)
            {
                items.Add(exam);
            }

            position = -1;
        }

        public object Current
        {
            get { return items[position]; }
        }

        public bool MoveNext()
        {
            position++;
            return position < items.Count;
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
