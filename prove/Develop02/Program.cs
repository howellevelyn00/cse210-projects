using System;
using System.Collections.Generic;

namespace SimpleJournal
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var promptGen = new PromptGenerator();
            var journal = new Journal();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine();
                Console.WriteLine("Journal Menu");
                Console.WriteLine("1) Write a new entry");
                Console.WriteLine("2) Display the journal");
                Console.WriteLine("3) Save the journal to a file");
                Console.WriteLine("4) Load the journal from a file");
                Console.WriteLine("5) List prompts");
                Console.WriteLine("6) Add a custom prompt");
                Console.WriteLine("0) Exit");
                Console.Write("Choose an option: ");

                var choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        WriteEntry(promptGen, journal);
                        break;
                    case "2":
                        journal.DisplayAll();
                        break;
                    case "3":
                        Console.Write("Enter filename to save to: ");
                        var saveName = Console.ReadLine();
                        journal.Save(saveName);
                        break;
                    case "4":
                        Console.Write("Enter filename to load from: ");
                        var loadName = Console.ReadLine();
                        journal.Load(loadName);
                        break;
                    case "5":
                        Console.WriteLine("Prompts:");
                        foreach (var p in promptGen.GetAllPrompts())
                        {
                            Console.WriteLine("- " + p);
                        }
                        break;
                    case "6":
                        Console.Write("Enter your new prompt: ");
                        var newPrompt = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(newPrompt))
                        {
                            promptGen.AddPrompt(newPrompt);
                            Console.WriteLine("Prompt added.");
                        }
                        else
                        {
                            Console.WriteLine("Empty prompt not added.");
                        }
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }

            Console.WriteLine("Goodbye.");
        }

        private static void WriteEntry(PromptGenerator promptGen, Journal journal)
        {
            var prompt = promptGen.GetRandomPrompt();
            Console.WriteLine("Prompt:");
            Console.WriteLine(prompt);
            Console.WriteLine();
            Console.WriteLine("Type your response (blank line to finish):");

            var lines = new List<string>();
            while (true)
            {
                var line = Console.ReadLine();
                if (string.IsNullOrEmpty(line)) break;
                lines.Add(line);
            }
            var response = string.Join(Environment.NewLine, lines);

            var date = DateTime.Now.ToString("yyyy-MM-dd");
            var entry = new Entry(prompt, response, date);
            journal.AddEntry(entry);
            Console.WriteLine("Entry saved to journal.");
        }
    }
}