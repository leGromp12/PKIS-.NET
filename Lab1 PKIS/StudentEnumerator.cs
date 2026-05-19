using System.Collections;

namespace Lab1_PKIS
{
    public class StudentEnumerator : IEnumerator
    {
        private int position = -1;
        private ArrayList commonSubjects;

        public StudentEnumerator(ArrayList tests, ArrayList exams)
        {
            commonSubjects = new ArrayList();

            foreach (Test t in tests)
            {
                foreach (Exam e in exams)
                {
                    if (t.Subject == e.Subject)
                    {
                        if (!commonSubjects.Contains(t.Subject))
                            commonSubjects.Add(t.Subject);
                    }
                }
            }
        }

        public object Current
        {
            get { return commonSubjects[position]!; }
        }

        public bool MoveNext()
        {
            position++;
            return position < commonSubjects.Count;
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
