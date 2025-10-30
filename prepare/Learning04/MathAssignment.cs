namespace Learning04
{
    public class MathAssignment : Assignment
    {
        private string _section;
        private string _problems; // e.g. "8-19"

        public MathAssignment(string studentName, string topic, string section, string problems)
            : base(studentName, topic)
        {
            _section = section;
            _problems = problems;
        }

        public string GetHomeworkList()
        {
            return $"Section {_section} Problems {_problems}";
        }
    }
}
