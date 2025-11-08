using System;
using System.Diagnostics;
using System.Threading;

namespace Develop04
{
    // Must be public so derived classes can be public
    public class Activity
    {
        // private fields (no properties)
        private string _name;
        private string _description;
        private int _durationSeconds;

        public Activity(string name, string description)
        {
            _name = name;
            _description = description;
            _durationSeconds = 0;
        }

        // Public entry point for an activity run
        public void Start()
        {
            Console.Clear();
            DisplayStartingMessage();
            AskAndSetDuration();
            PrepareToBegin();
            // Call the overridden method in derived classes
            RunActivity();
            DisplayEndingMessage();
        }

        protected void DisplayStartingMessage()
        {
            Console.WriteLine("=== " + _name + " ===");
            Console.WriteLine();
            Console.WriteLine(_description);
            Console.WriteLine();
        }

        protected void AskAndSetDuration()
        {
            int seconds = 0;
            while (true)
            {
                Console.Write("Enter duration in seconds: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out seconds) && seconds > 0)
                {
                    _durationSeconds = seconds;
                    break;
                }
                Console.WriteLine("Please enter a valid positive integer.");
            }
        }

        protected void PrepareToBegin()
        {
            Console.WriteLine();
            Console.WriteLine("Get ready...");
            ShowSpinner(3);
            Console.WriteLine();
        }

        protected void DisplayEndingMessage()
        {
            Console.WriteLine();
            Console.WriteLine("Well done!");
            Console.WriteLine("You have completed the activity for " + _durationSeconds + " seconds.");
            ShowSpinner(3);
            Console.WriteLine();
        }

        // Expose duration to derived classes via protected getter
        protected int GetDurationSeconds()
        {
            return _durationSeconds;
        }

        // Spinner utility (uses backspace to animate)
        protected void ShowSpinner(int seconds)
        {
            char[] spinner = new char[] { '|', '/', '-', '\\' };
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int idx = 0;
            while (sw.ElapsedMilliseconds < seconds * 1000)
            {
                Console.Write(spinner[idx % spinner.Length]);
                Thread.Sleep(200);
                Console.Write("\b");
                idx++;
            }
            sw.Stop();
        }

        // Countdown utility
        protected void ShowCountdown(int seconds)
        {
            for (int i = seconds; i >= 1; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }

        // Allow derived classes to override this with their behavior.
        // It's not abstract; base provides a no-op default.
        protected virtual void RunActivity()
        {
            // base does nothing
        }
    }
}
