using System;
using System.Diagnostics;

namespace Develop04
{
    public class BreathingActivity : Activity
    {
        public BreathingActivity()
            : base("Breathing Activity",
                   "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
        {
        }

        protected override void RunActivity()
        {
            int totalSeconds = GetDurationSeconds();
            Stopwatch sw = new Stopwatch();
            sw.Start();

            // Alternate inhale/exhale, 5 seconds each (or remaining seconds if less than 5)
            while (sw.Elapsed.TotalSeconds < totalSeconds)
            {
                // Calculate remaining time
                int elapsed = (int)sw.Elapsed.TotalSeconds;
                int remaining = totalSeconds - elapsed;
                if (remaining <= 0) break;

                // Breathe in
                int inhaleSeconds = remaining >= 5 ? 5 : remaining;
                Console.WriteLine();
                Console.WriteLine("Breathe in...");
                ShowCountdown(inhaleSeconds);

                // Check if time finished during inhale
                elapsed = (int)sw.Elapsed.TotalSeconds;
                remaining = totalSeconds - elapsed;
                if (remaining <= 0) break;

                // Breathe out
                int exhaleSeconds = remaining >= 5 ? 5 : remaining;
                Console.WriteLine();
                Console.WriteLine("Breathe out...");
                ShowCountdown(exhaleSeconds);
            }

            sw.Stop();
        }
    }
}
