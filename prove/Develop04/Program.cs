using System;
using System.Threading;
using System.Collections.Generic;
using System.Diagnostics;
namespace Develop04
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Mindfulness Console App");
                Console.WriteLine("-----------------------");
                Console.WriteLine("Please choose an activity:");
                Console.WriteLine("1. Breathing Activity");
                Console.WriteLine("2. Reflection Activity");
                Console.WriteLine("3. Listing Activity");
                Console.WriteLine("4. Quit");
                Console.Write("Choice: ");

                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    BreathingActivity b = new BreathingActivity();
                    b.Start();
                }
                else if (choice == "2")
                {
                    ReflectionActivity r = new ReflectionActivity();
                    r.Start();
                }
                else if (choice == "3")
                {
                    ListingActivity l = new ListingActivity();
                    l.Start();
                }
                else if (choice == "4" || choice.Trim().ToLower() == "quit")
                {
                    Console.WriteLine("Goodbye!");
                    Thread.Sleep(600);
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter 1, 2, 3, or 4.");
                    Thread.Sleep(800);
                }
            }
        }
    }
}
