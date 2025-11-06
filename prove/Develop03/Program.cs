using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ScriptureMemorizer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Example scripture. Replace these with any scripture you'd like to test.
            // Demonstrates both constructors: use Reference.Parse or manual constructors.
            Reference reference = Reference.Parse("John 3:16");
            string scriptureText = "For God so loved the world, that he gave his only begotten Son, " +
                                   "that whosoever believeth in him should not perish, but have everlasting life.";

            // If you want a verse range, e.g.:
            // Reference reference = new Reference("Proverbs", 3, 5, 6);
            // string scriptureText = "Trust in the Lord with all thine heart; and lean not unto thine own understanding.";

            var scripture = new Scripture(reference, scriptureText);

            RunMemorizer(scripture);
        }

        static void RunMemorizer(Scripture scripture)
        {
            ConsoleKeyInfo keyInfo;
            while (true)
            {
                Console.Clear();
                Console.WriteLine(scripture.Reference.ToString());
                Console.WriteLine();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine();
                Console.WriteLine("Press Enter to hide a few words, or type 'quit' then Enter to exit.");

                string input = Console.ReadLine();
                if (input != null && input.Trim().ToLower() == "quit")
                {
                    Console.WriteLine("Quitting. Goodbye.");
                    return;
                }

                // If all words are already hidden, end
                if (scripture.AllWordsHidden())
                {
                    Console.WriteLine("All words are hidden. Memorization complete.");
                    return;
                }

                // Hide a few random visible words: choose 1 to 3 each round
                int toHide = new Random().Next(1, 4); // 1,2,or 3
                int hiddenNow = scripture.HideRandomVisibleWords(toHide);

                // If nothing was hidden (shouldn't happen because we checked AllWordsHidden), end
                if (hiddenNow == 0 && scripture.AllWordsHidden())
                {
                    Console.WriteLine("All words are hidden. Memorization complete.");
                    return;
                }

                // Continue loop — console will be cleared and redisplayed at top of loop
             }
        }
    }
}
