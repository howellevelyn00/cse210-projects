namespace FinalProject
{
    public class VocabEntry
    {
        private string word;
        private string definition;
        private string chapter;

        public VocabEntry(string word, string definition, string chapter)
        {
            this.word = word;
            this.definition = definition;
            this.chapter = chapter;
        }

        public string Word => word;
        public string Definition => definition;
        public string Chapter => chapter;
    }
}
