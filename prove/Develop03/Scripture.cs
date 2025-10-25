using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ScriptureMemorizer
{
    public class Scripture
    {
        private Reference _reference;
        private List<Word> _tokens;
        private Random _rand = new Random();

        // Public read-only accessors
        public Reference Reference => _reference;

        // Constructor takes Reference and the scripture text
        public Scripture(Reference reference, string text)
        {
            _reference = reference ?? throw new ArgumentNullException(nameof(reference));
            _tokens = Tokenize(text);
        }

        // Tokenize the input text into Word tokens. We want to preserve punctuation as separate tokens.
        private List<Word> Tokenize(string text)
        {
            // This regex will split into tokens keeping words, punctuation, and spaces.
            // We'll use a simpler approach: capture runs of alphanumeric/apostrophes as tokens, and other single chars separately.
            var tokens = new List<Word>();
            var pattern = @"[A-Za-z0-9']+|[^\sA-Za-z0-9']"; // words (with apostrophes) or single non-space punctuation
            foreach (Match m in Regex.Matches(text, pattern))
            {
                tokens.Add(new Word(m.Value));
            }

            return tokens;
        }

        // Returns full display string (with masked words)
        public string GetDisplayText()
        {
            // Rebuild text by concatenating tokens with no extra spacing — original punctuation tokens already present.
            return string.Concat(_tokens.Select(t => t.Display()));
        }

        // Returns true when every token that is a "word" is hidden
        public bool AllWordsHidden()
        {
            return _tokens.Where(t => t.IsWordToken()).All(t => t.IsHidden);
        }

        // Hide up to 'count' random visible word tokens. If fewer visible words remain, hide those.
        // Returns number actually hidden.
        public int HideRandomVisibleWords(int count)
        {
            var visibleWordIndices = _tokens
                .Select((token, idx) => new { token, idx })
                .Where(x => x.token.IsWordToken() && !x.token.IsHidden)
                .Select(x => x.idx)
                .ToList();

            if (visibleWordIndices.Count == 0) return 0;

            int numToHide = Math.Min(count, visibleWordIndices.Count);

            // Shuffle visible indices and pick first numToHide
            for (int i = visibleWordIndices.Count - 1; i > 0; i--)
            {
                int j = _rand.Next(i + 1);
                int tmp = visibleWordIndices[i];
                visibleWordIndices[i] = visibleWordIndices[j];
                visibleWordIndices[j] = tmp;
            }

            var selected = visibleWordIndices.Take(numToHide);
            foreach (var idx in selected)
            {
                _tokens[idx].Hide();
            }

            return numToHide;
        }

        // Convenience to get original text (unmasked) for debugging/display if needed
        public string GetOriginalText()
        {
            return string.Concat(_tokens.Select(t => t.Original));
        }
    }
}