namespace Lab1_PKIS
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
            Subject = "Default Subject";
            IsPassed = false;
        }

        public override string ToString()
        {
            return $"Subject: {Subject}, Passed: {IsPassed}";
        }
    }
}
