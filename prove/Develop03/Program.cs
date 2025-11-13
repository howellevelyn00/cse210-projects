using System;

namespace ScriptureMemorizer
{
    class Program
    {
        static void Main(string[] args)
        {
            Reference reference = Reference.Parse("John 3:16");
            string scriptureText =
                "For God so loved the world, that he gave his only begotten Son, " +
                "that whosoever believeth in him should not perish, but have everlasting life.";

            Scripture scripture = new Scripture(reference, scriptureText);

            RunMemorizer(scripture);
        }

        static void RunMemorizer(Scripture scripture)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(scripture.GetReference().ToDisplayString());
                Console.WriteLine();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine();
                Console.WriteLine("Press Enter to hide words, or type 'quit' to exit.");

                string input = Console.ReadLine();

                if (input != null && input.Trim().ToLower() == "quit")
                {
                    Console.WriteLine("Goodbye.");
                    return;
                }

                if (scripture.AllWordsHidden())
                {
                    Console.WriteLine("All words are hidden.");
                    return;
                }

                Random r = new Random();
                int toHide = r.Next(1, 4);

                scripture.HideRandomVisibleWords(toHide);
            }
        }
    }
}