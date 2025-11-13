using System;
using System.Text.RegularExpressions;

namespace ScriptureMemorizer
{
    public class Reference
    {
        private string _book;
        private int _chapter;
        private int _verseStart;
        private int _verseEnd;

        public Reference(string book, int chapter, int verseStart, int verseEnd)
        {
            _book = book;
            _chapter = chapter;
            _verseStart = verseStart;
            _verseEnd = verseEnd;
        }

        public static Reference Parse(string input)
        {
            var match = Regex.Match(input.Trim(),
                @"^([\w\s]+)\s+(\d+):(\d+)(?:-(\d+))?$");

            if (!match.Success)
            {
                throw new FormatException("Invalid scripture reference format.");
            }

            string book = match.Groups[1].Value.Trim();
            int chapter = int.Parse(match.Groups[2].Value);
            int verseStart = int.Parse(match.Groups[3].Value);
            int verseEnd = -1;

            if (match.Groups[4].Success)
            {
                verseEnd = int.Parse(match.Groups[4].Value);
            }

            return new Reference(book, chapter, verseStart, verseEnd);
        }

        // CHANGED BY CHATGPT — removed property, added normal method
        public string ToDisplayString()
        {
            if (_verseEnd != -1 && _verseEnd != _verseStart)
            {
                return _book + " " + _chapter + ":" + _verseStart + "-" + _verseEnd;
            }

            return _book + " " + _chapter + ":" + _verseStart;
        }

        public string GetBook()
        {
            return _book;
        }

        public int GetChapter()
        {
            return _chapter;
        }

        public int GetVerseStart()
        {
            return _verseStart;
        }

        public int GetVerseEnd()
        {
            return _verseEnd;
        }
    }
}
