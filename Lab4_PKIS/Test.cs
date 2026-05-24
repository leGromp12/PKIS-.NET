namespace Lab4_PKIS
{
    public class Test
    {
        public string Subject { get; set; }
        public bool IsPassed { get; set; }

        public Test(string subject, bool isPassed)
        {
            Subject = subject;
            IsPassed = isPassed;
        }

        public Test()
        {
            Subject = "Subject";
            IsPassed = true;
        }

        public override string ToString()
        {
            return string.Format("Subject: {0}, Passed: {1}", Subject, IsPassed);
        }
    }
}
