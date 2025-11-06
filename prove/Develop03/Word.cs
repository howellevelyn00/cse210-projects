namespace ScriptureMemorizer
{
    public class Word
    {
        private string _text;
        private bool _hidden;

        public Word(string text)
        {
            _text = text ?? "";
            _hidden = false;
        }

        public bool IsHidden()
        {
            return _hidden;
        }

        public void Hide()
        {
            _hidden = true;
        }

        // Return the display version: letters/digits -> '_' when hidden, otherwise original token
        public string GetDisplayText()
        {
            if (!_hidden) return _text;

            char[] arr = new char[_text.Length];
            for (int i = 0; i < _text.Length; i++)
            {
                char c = _text[i];
                if (char.IsLetterOrDigit(c))
                    arr[i] = '_';
                else
                    arr[i] = c; // keep punctuation
            }
            return new string(arr);
        }

        // Consider a token a "word" only if it has at least one letter or digit
        public bool IsWordToken()
        {
            for (int i = 0; i < _text.Length; i++)
            {
                if (char.IsLetterOrDigit(_text[i]))
                    return true;
            }
            return false;
        }

        public string Original => _text;
    }
}
