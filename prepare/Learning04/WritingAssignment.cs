namespace Learning04
{
    public class WritingAssignment : Assignment
    {
        private string _title;
        private int _wordCount;

        public WritingAssignment(string studentName, string topic, string title, int wordCount)
            : base(studentName, topic)
        {
            _title = title;
            _wordCount = wordCount;
        }

        public string GetWritingInformation()
        {
            // Returns a compact line describing the writing task.
            return $"{_title} - {_wordCount} words";
        }
    }
}
