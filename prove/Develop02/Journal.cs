using System;
using System.Collections.Generic;
using System.IO;

namespace SimpleJournal
{
    public class Journal
    {
        private List<Entry> entries = new List<Entry>();

        public void AddEntry(Entry e)
        {
            entries.Add(e);
        }

        public void DisplayAll()
        {
            if (entries.Count == 0)
            {
                Console.WriteLine("Journal is empty.");
                return;
            }

            foreach (Entry e in entries)
            {
                e.Display();
            }
        }

        public void Save(string filename)
        {
            try
            {
                using (var sw = new StreamWriter(filename))
                {
                    foreach (Entry e in entries)
                    {
                        sw.WriteLine(e.ToFileLine());
                    }
                }
                Console.WriteLine("Journal saved to " + filename);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving file: " + ex.Message);
            }
        }

        public void Load(string filename)
        {
            try
            {
                if (!File.Exists(filename))
                {
                    Console.WriteLine("File not found.");
                    return;
                }

                string[] lines = File.ReadAllLines(filename);
                var loaded = new List<Entry>();
                foreach (string line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    Entry entry = Entry.FromFileLine(line);
                    loaded.Add(entry);
                }

                entries = loaded;
                Console.WriteLine("Loaded " + entries.Count + " entries from " + filename);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading file: " + ex.Message);
            }
        }
    }
}
