using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Develop04
{
    public class ListingActivity : Activity
    {
        private string[] _prompts;
        private Random _rand;

        public ListingActivity()
            : base("Listing Activity",
                   "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
        {
            _rand = new Random();
            _prompts = new string[]
            {
                "Who are people that you appreciate?",
                "What are personal strengths of yours?",
                "Who are people that you have helped this week?",
                "When have you felt the Holy Ghost this month?",
                "Who are some of your personal heroes?"
            };
        }

        protected override void RunActivity()
        {
            int totalSeconds = GetDurationSeconds();

            // Pick a random prompt and show it
            int promptIndex = _rand.Next(0, _prompts.Length);
            Console.WriteLine();
            Console.WriteLine("Prompt:");
            Console.WriteLine("--- " + _prompts[promptIndex] + " ---");
            Console.WriteLine();

            // Short prep countdown
            Console.Write("You will have a few seconds to think: ");
            ShowCountdown(5);
            Console.WriteLine();
            Console.WriteLine("Start listing! Press Enter after each item.");

            List<string> items = new List<string>();
            Stopwatch sw = new Stopwatch();
            sw.Start();

            // Loop until time is up, using a ReadLine with timeout to avoid blocking past the deadline
            while (sw.Elapsed.TotalSeconds < totalSeconds)
            {
                int msRemaining = (int)((totalSeconds * 1000) - sw.ElapsedMilliseconds);
                if (msRemaining <= 0) break;

                Console.Write("> ");

                // Run Console.ReadLine on a background task and wait up to the remaining milliseconds.
                Task<string> readTask = Task.Run(() => Console.ReadLine());
                bool completedInTime = readTask.Wait(msRemaining);

                if (completedInTime)
                {
                    string entry = readTask.Result;
                    if (!string.IsNullOrWhiteSpace(entry))
                    {
                        items.Add(entry.Trim());
                    }
                    // Continue loop if time remains
                }
                else
                {
                    // Time expired while user was typing — abandon partial input and stop collecting.
                    Console.WriteLine();
                    Console.WriteLine("Time's up!");
                    break;
                }
            }

            sw.Stop();

            Console.WriteLine();
            Console.WriteLine("You listed " + items.Count + " item(s). Great work!");
        }
    }
}
