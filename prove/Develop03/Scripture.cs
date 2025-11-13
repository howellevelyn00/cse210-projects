using System;
using System.Collections.Generic;

namespace ScriptureMemorizer
{
    public class Scripture
    {
        private Reference _reference;
        private List<Word> _tokens;
        private Random _rand;

        public Scripture(Reference reference, string text)
        {
            _reference = reference;
            _rand = new Random();
            _tokens = new List<Word>();

            if (text == null)
            {
                text = "";
            }

            string[] parts = text.Split(' ');
            for (int i = 0; i < parts.Length; i++)
            {
                _tokens.Add(new Word(parts[i]));
            }
        }

        public Reference GetReference()
        {
            return _reference;
        }

        public string GetDisplayText()
        {
            string output = "";

            for (int i = 0; i < _tokens.Count; i++)
            {
                output += _tokens[i].GetDisplayText();

                if (i < _tokens.Count - 1)
                {
                    output += " ";
                }
            }

            return output;
        }

        public bool AllWordsHidden()
        {
            for (int i = 0; i < _tokens.Count; i++)
            {
                if (_tokens[i].IsWordToken() && !_tokens[i].IsHidden())
                {
                    return false;
                }
            }

            return true;
        }

        public int HideRandomVisibleWords(int count)
        {
            List<int> visible = new List<int>();

            for (int i = 0; i < _tokens.Count; i++)
            {
                if (_tokens[i].IsWordToken() && !_tokens[i].IsHidden())
                {
                    visible.Add(i);
                }
            }

            if (visible.Count == 0)
            {
                return 0;
            }

            if (count > visible.Count)
            {
                count = visible.Count;
            }

            for (int i = visible.Count - 1; i > 0; i--)
            {
                int j = _rand.Next(i + 1);
                int temp = visible[i];
                visible[i] = visible[j];
                visible[j] = temp;
            }

            int hidden = 0;

            for (int i = 0; i < count; i++)
            {
                int index = visible[i];

                if (!_tokens[index].IsHidden())
                {
                    _tokens[index].Hide();
                    hidden++;
                }
            }

            return hidden;
        }

        public string GetOriginalText()
        {
            string output = "";

            for (int i = 0; i < _tokens.Count; i++)
            {
                output += _tokens[i].GetOriginal();

                if (i < _tokens.Count - 1)
                {
                    output += " ";
                }
            }

            return output;
        }
    }
}
