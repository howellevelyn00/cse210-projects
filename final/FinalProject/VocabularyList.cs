using System;
using System.Collections.Generic;

namespace FinalProject
{
    public class VocabularyList
    {
        private List<VocabEntry> entries = new List<VocabEntry>();

           public void AddEntry(VocabEntry entry)
    {
        entries.Add(entry);
    }

    public List<VocabEntry> GetAll()
    {
        return entries;
    }

    public int Count()
    {
        return entries.Count;
    }
    }

}