namespace Lab5_PKIS
{
    public class JournalEntry
    {
        public string CollectionName { get; set; }
        public string ChangeInfo { get; set; }
        public string StudentInfo { get; set; }

        public JournalEntry(string collectionName, string changeInfo, string studentInfo)
        {
            CollectionName = collectionName;
            ChangeInfo = changeInfo;
            StudentInfo = studentInfo;
        }

        public override string ToString()
        {
            return string.Format("Колекція: {0}, зміна: {1}, студент: {2}", CollectionName, ChangeInfo, StudentInfo);
        }
    }
}
