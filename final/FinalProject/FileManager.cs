using System.IO;
using System.Collections.Generic;

namespace FinalProject
{
    public class FileManager
    {
        public void Save(VocabularyList list, string path)
        {
            // Read existing entries from file (if any) and index by word
            Dictionary<string, VocabEntry> merged = new Dictionary<string, VocabEntry>();

            if (File.Exists(path))
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        if (string.IsNullOrWhiteSpace(line))
                            continue;

                        string[] parts = line.Split('|');
                        if (parts.Length < 3)
                            continue;

                        string w = parts[0];
                        if (!merged.ContainsKey(w))
                        {
                            merged[w] = new VocabEntry(parts[0], parts[1], parts[2]);
                        }
                    }
                }
            }

            // Add/overwrite with entries currently in memory
            foreach (VocabEntry entry in list.GetAll())
            {
                merged[entry.Word] = entry;
            }

            // Write the merged set back to the file (overwriting with combined data)
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                foreach (VocabEntry entry in merged.Values)
                {
                    writer.WriteLine($"{entry.Word}|{entry.Definition}|{entry.Chapter}");
                }
            }
        }

        public VocabularyList Load(string path)
        {
            VocabularyList list = new VocabularyList();

            if (!File.Exists(path))
                return list;

            using (StreamReader reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    string[] parts = reader.ReadLine().Split('|');
                    list.AddEntry(new VocabEntry(parts[0], parts[1], parts[2]));
                }
            }

            return list;
        }
    }
}
