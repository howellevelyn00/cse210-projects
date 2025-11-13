namespace ScriptureMemorizer
{
    public class Word
    {
        private string _text;
        private bool _hidden;

        public Word(string text)
        {
            _text = text;
            _hidden = false;
        }

        public void Hide()
        {
            _hidden = true;
        }

        public bool IsHidden()
        {
            return _hidden;
        }

        public bool IsWordToken()
        {
            return true;
        }

        public string GetDisplayText()
        {
            if (_hidden)
            {
                string mask = "";
                for (int i = 0; i < _text.Length; i++)
                {
                    mask += "_";
                }
                return mask;
            }

            return _text;
        }

        public string GetOriginal()
        {
            return _text;
        }
    }
}
