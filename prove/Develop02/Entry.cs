namespace SimpleJournal
{
    public class Entry
    {
        private string _prompt;
        private string _response;
        private string _date;

        private const string SEP = " | ";

        public Entry(string prompt, string response, string date)
        {
            _prompt = prompt;
            _response = response;
            _date = date;
        }

        public string ToFileLine()
        {
            return _date + SEP + _prompt + SEP + _response;
        }

        public static Entry FromFileLine(string line)
        {
            string[] parts = line.Split(new string[] { SEP }, StringSplitOptions.None);
            if (parts.Length < 3)
            {
                throw new FormatException("Invalid entry line format.");
            }

            string date = parts[0];
            string prompt = parts[1];
            string response = string.Join(SEP, parts, 2, parts.Length - 2);

            return new Entry(prompt, response, date);
        }

        public void Display()
        {
            Console.WriteLine("-----");
            Console.WriteLine("Date: " + _date);
            Console.WriteLine("Prompt: " + _prompt);
            Console.WriteLine("Response:");
            Console.WriteLine(_response);
            Console.WriteLine("-----");
        }

        public string GetPrompt()
        {
            return _prompt;
        }

        public string GetResponse()
        {
            return _response;
        }

        public string GetDate()
        {
            return _date;
        }
    }
}
