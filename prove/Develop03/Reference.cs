using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ScriptureMemorizer
{
    public class Reference
    {
        public string Book { get; private set; }
        public int Chapter { get; private set; }
        public int VerseStart { get; private set; }
        public int? VerseEnd { get; private set; } // null if single verse

        // Constructor for single verse (John 3:16)
        public Reference(string book, int chapter, int verse)
        {
            Book = book;
            Chapter = chapter;
            VerseStart = verse;
            VerseEnd = null;
        }

        // Constructor for verse range (Proverbs 3:5-6)
        public Reference(string book, int chapter, int verseStart, int verseEnd)
        {
            Book = book;
            Chapter = chapter;
            VerseStart = verseStart;
            VerseEnd = verseEnd;
        }

        // Parse from a string like "John 3:16" or "Proverbs 3:5-6"
        public static Reference Parse(string refText)
        {
            // Very simple parser; expects "Book chapter:verse" or "Book chapter:verse-verse"
            // e.g. "John 3:16" or "Proverbs 3:5-6"
            var parts = refText.Trim().Split(' ', 2);

            if (parts.Length < 2) throw new ArgumentException("Invalid reference format.");
            string book = parts[0];
            string rest = parts[1];

            var chapVerse = rest.Split(':');
            if (chapVerse.Length != 2) throw new ArgumentException("Invalid reference format.");
            int chapter = int.Parse(chapVerse[0]);
            string versePart = chapVerse[1];
            if (versePart.Contains('-'))
            {
                var v = versePart.Split('-');
                int start = int.Parse(v[0]);
                int end = int.Parse(v[1]);
                return new Reference(book, chapter, start, end);
            }
            else
            {
                int verse = int.Parse(versePart);
                return new Reference(book, chapter, verse);
            }
        }

        public override string ToString()
        {
            if (VerseEnd.HasValue)
                return $"{Book} {Chapter}:{VerseStart}-{VerseEnd.Value}";
            else
                return $"{Book} {Chapter}:{VerseStart}";
        }
    }

}
                // Represents a single word (or token) in the scripture text.
            