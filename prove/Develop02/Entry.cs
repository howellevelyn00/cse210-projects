using System;

namespace SimpleJournal
{
    public class Entry
    {
        public string Prompt { get; private set; }
        public string Response { get; private set; }
        public string Date { get; private set; }

        private const string SEP = " | ";

        public Entry(string prompt, string response, string date)
        {
            Prompt = prompt;
            Response = response;
            Date = date;
        }

        public string ToFileLine()
        {
            return $"{Date}{SEP}{Prompt}{SEP}{Response}";
        }

        public static Entry FromFileLine(string line)
        {
            var parts = line.Split(new string[] { SEP }, StringSplitOptions.None);
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
            Console.WriteLine($"Date: {Date}");
            Console.WriteLine($"Prompt: {Prompt}");
            Console.WriteLine("Response:");
            Console.WriteLine(Response);
            Console.WriteLine("-----");
        }
    }
}
