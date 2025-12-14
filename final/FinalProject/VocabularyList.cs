using System.Collections.Generic;

namespace FinalProject
{
    public class VocabularyList
    {
        private List<VocabEntry> entries;

        public VocabularyList()
        {
            entries = new List<VocabEntry>();
        }

        public void AddEntry(VocabEntry entry)
        {
            entries.Add(entry);
        }

        public List<VocabEntry> GetByChapter(string chapter)
        {
            List<VocabEntry> result = new List<VocabEntry>();

            foreach (VocabEntry entry in entries)
            {
                if (entry.Chapter == chapter)
                {
                    result.Add(entry);
                }
            }

            return result;
        }

        public List<VocabEntry> GetAll()
        {
            return new List<VocabEntry>(entries);
        }
    }
}
