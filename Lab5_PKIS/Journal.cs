using System.Collections.Generic;
using System.Text;

namespace Lab5_PKIS
{
    public class Journal
    {
        private List<JournalEntry> entries;

        public Journal()
        {
            entries = new List<JournalEntry>();
        }

        public void StudentCountChanged(object source, StudentListHandlerEventArgs args)
        {
            AddEntry(args);
        }

        public void StudentReferenceChanged(object source, StudentListHandlerEventArgs args)
        {
            AddEntry(args);
        }

        private void AddEntry(StudentListHandlerEventArgs args)
        {
            string studentInfo = args.Student == null ? "" : args.Student.ToShortString();
            entries.Add(new JournalEntry(args.CollectionName, args.ChangeInfo, studentInfo));
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            foreach (JournalEntry entry in entries)
            {
                builder.AppendLine(entry.ToString());
            }

            return builder.ToString();
        }
    }
}
