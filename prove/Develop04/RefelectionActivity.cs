using System;
using System.Diagnostics;

namespace Develop04
{
    public class ReflectionActivity : Activity
    {
        private string[] _prompts;
        private string[] _questions;
        private Random _rand;

        public ReflectionActivity()
            : base("Reflection Activity",
                   "This activity will help you reflect on times in your life when you have shown strength and resilience.")
        {
            _rand = new Random();

            _prompts = new string[]
            {
                "Think of a time when you stood up for someone else.",
                "Think of a time when you did something really difficult.",
                "Think of a time when you helped someone in need.",
                "Think of a time when you did something truly selfless."
            };

            _questions = new string[]
            {
                "Why was this experience meaningful to you?",
                "Have you ever done anything like this before?",
                "How did you get started?",
                "How did you feel when it was complete?",
                "What made this time different than other times when you were not as successful?",
                "What is your favorite thing about this experience?",
                "What could you learn from this experience that applies to other situations?",
                "What did you learn about yourself through this experience?",
                "How can you keep this experience in mind in the future?"
            };
        }

        protected override void RunActivity()
        {
            // Total time for this activity
            int totalSeconds = GetDurationSeconds();

            // Pick and show a single random prompt
            int promptIndex = _rand.Next(0, _prompts.Length);
            Console.WriteLine();
            Console.WriteLine("Prompt:");
            Console.WriteLine("--- " + _prompts[promptIndex] + " ---");
            Console.WriteLine();
            Console.WriteLine("When you have an experience in mind, press Enter to begin.");
            Console.ReadLine();
            Console.WriteLine();

            // Start timing and cycle through questions every 5 seconds
            Stopwatch sw = new Stopwatch();
            sw.Start();

            int qIndex = 0;
            while (sw.Elapsed.TotalSeconds < totalSeconds)
            {
                Console.WriteLine("> " + _questions[qIndex]);

                // Wait 5 seconds (or remaining time if less)
                int elapsed = (int)sw.Elapsed.TotalSeconds;
                int remaining = totalSeconds - elapsed;
                int wait = remaining >= 5 ? 5 : Math.Max(0, remaining);
                if (wait > 0)
                {
                    ShowSpinner(wait);
                }

                Console.WriteLine();
                qIndex++;
                if (qIndex >= _questions.Length) qIndex = 0; // wrap around if we run out
            }

            sw.Stop();
        }
    }
}
