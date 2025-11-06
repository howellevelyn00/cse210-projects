using System;
using System.Collections.Generic;

namespace ScriptureMemorizer
{
    public class Scripture
    {
        private Reference _reference;
        private List<Word> _tokens;
        private Random _rand;

        public Reference Reference
        {
            get { return _reference; }
        }

        public Scripture(Reference reference, string text)
        {
            _reference = reference ?? throw new ArgumentNullException(nameof(reference));
            _tokens = new List<Word>();
            _rand = new Random();

            if (text == null) text = "";

            // Simple tokenization: split on spaces but keep punctuation attached to tokens.
            // This keeps things straightforward and easy to display.
            string[] parts = text.Split(' ');
            for (int i = 0; i < parts.Length; i++)
            {
                _tokens.Add(new Word(parts[i]));
            }
        }

        // Build the display text by concatenating token displays with spaces
        public string GetDisplayText()
        {
            if (_tokens.Count == 0) return "";

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < _tokens.Count; i++)
            {
                sb.Append(_tokens[i].GetDisplayText());
                if (i < _tokens.Count - 1)
                    sb.Append(" ");
            }
            return sb.ToString();
        }

        // Return true if every token that is a word is hidden
        public bool AllWordsHidden()
        {
            for (int i = 0; i < _tokens.Count; i++)
            {
                if (_tokens[i].IsWordToken() && !_tokens[i].IsHidden())
                    return false;
            }
            return true;
        }

        // Hide up to 'count' random visible word tokens.
        // Returns the number of tokens actually hidden.
        public int HideRandomVisibleWords(int count)
        {
            if (count <= 0) return 0;

            // Collect indices of visible word tokens
            List<int> visibleIndices = new List<int>();
            for (int i = 0; i < _tokens.Count; i++)
            {
                if (_tokens[i].IsWordToken() && !_tokens[i].IsHidden())
                    visibleIndices.Add(i);
            }

            if (visibleIndices.Count == 0) return 0;

            int toHide = count;
            if (toHide > visibleIndices.Count) toHide = visibleIndices.Count;

            // Shuffle visibleIndices using Fisher-Yates
            for (int i = visibleIndices.Count - 1; i > 0; i--)
            {
                int j = _rand.Next(i + 1);
                int tmp = visibleIndices[i];
                visibleIndices[i] = visibleIndices[j];
                visibleIndices[j] = tmp;
            }

            int hidden = 0;
            for (int k = 0; k < toHide; k++)
            {
                int idx = visibleIndices[k];
                if (!_tokens[idx].IsHidden())
                {
                    _tokens[idx].Hide();
                    hidden++;
                }
            }

            return hidden;
        }

        // Optional: get the original (unmasked) text
        public string GetOriginalText()
        {
            if (_tokens.Count == 0) return "";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < _tokens.Count; i++)
            {
                sb.Append(_tokens[i].Original);
                if (i < _tokens.Count - 1) sb.Append(" ");
            }
            return sb.ToString();
        }
    }
}
