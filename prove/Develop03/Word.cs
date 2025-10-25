using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ScriptureMemorizer
{
    public class Word
    {
        private string _original;

        private bool _hidden;

        public Word(string original)
        {
            _original = original;
            _hidden = false;
        }

        // Mark the word hidden (idempotent)
        public void Hide()
        {
            _hidden = true;
        }

        public bool IsHidden => _hidden;

        // Display the word: either original or masked (letters replaced with underscores)
        public string Display()
        {
            if (!_hidden) return _original;

            // Mask only letters and digits; leave punctuation like ',' '.' ':' '-' etc.
            return Regex.Replace(_original, "[A-Za-z0-9]", "_");
        }

        // For checking if this token is a real "word" (contains letters/digits)
        public bool IsWordToken()
        {
            return Regex.IsMatch(_original, "[A-Za-z0-9]");
        }

        // Expose original for any debugging or logic
        public string Original => _original;
    }
}

                // Holds the scripture reference and the list of Word tokens for the text.