
using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    public class Program
    {
        private static GoalManager gm;

        public static void Main(string[] args)
        {
            gm = new GoalManager();

            // Example seed goals
            gm.AddGoal(new SimpleGoal("Run a marathon", "Complete a marathon", 1000));
            gm.AddGoal(new EternalGoal("Read scriptures", "Daily scripture reading", 100));
            gm.AddGoal(new ChecklistGoal("Temple visits", "Go to the temple", 50, 10, 500));

            Console.WriteLine("Welcome to Eternal Quest!");
            while (true)
            {
                ShowMenu();
                string choice = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(choice)) continue;

                choice = choice.Trim();

                if (choice == "1")
                {
                    CreateNewGoal();
                }
                else if (choice == "2")
                {
                    Console.WriteLine();
                    Console.WriteLine("Your Goals:");
                    gm.DisplayGoals();
                    Console.WriteLine();
                    Console.WriteLine("Score: " + gm.GetScore().ToString() + "  Level: " + gm.GetLevel().ToString());
                    Console.WriteLine();
                }
                else if (choice == "3")
                {
                    gm.SaveToFile();
                }
                else if (choice == "4")
                {
                    gm.LoadFromFile();
                }
                else if (choice == "5")
                {
                    RecordEventMenu();
                }
                else if (choice == "6")
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }
                else
                {
                    Console.WriteLine("Enter 1-6.");
                }
            }
        }

        private static void ShowMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Choice: ");
        }

        private static void CreateNewGoal()
        {
            Console.WriteLine();
            Console.WriteLine("Choose goal type:");
            Console.WriteLine("1. Simple Goal (one-time)");
            Console.WriteLine("2. Eternal Goal (repeatable)");
            Console.WriteLine("3. Checklist Goal (repeat several times for bonus)");
            Console.Write("Choice: ");
            string t = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(t)) return;
            t = t.Trim();

            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            Console.Write("Enter description: ");
            string desc = Console.ReadLine();

            if (t == "1")
            {
                int pts = PromptForInt("Points to award when completed (example 1000): ");
                SimpleGoal sg = new SimpleGoal(name, desc, pts);
                gm.AddGoal(sg);
                Console.WriteLine("Simple goal added.");
            }
            else if (t == "2")
            {
                int pts = PromptForInt("Points to award each time this goal is recorded (example 100): ");
                EternalGoal eg = new EternalGoal(name, desc, pts);
                gm.AddGoal(eg);
                Console.WriteLine("Eternal goal added.");
            }
            else if (t == "3")
            {
                int pts = PromptForInt("Points per recording (example 50): ");
                int target = PromptForInt("Target count to complete (example 10): ");
                int bonus = PromptForInt("Bonus points on completion (example 500): ");
                ChecklistGoal cg = new ChecklistGoal(name, desc, pts, target, bonus);
                gm.AddGoal(cg);
                Console.WriteLine("Checklist goal added.");
            }
            else
            {
                Console.WriteLine("Invalid type.");
            }
        }

        private static int PromptForInt(string prompt)
        {
            int val = 0;
            while (true)
            {
                Console.Write(prompt);
                string s = Console.ReadLine();
                if (int.TryParse(s, out val))
                {
                    return val;
                }
                Console.WriteLine("Please enter a valid integer.");
            }
        }

        private static void RecordEventMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Which goal did you accomplish? (enter number)");
            gm.DisplayGoals();
            if (gm.GetScore() >= 0) { } // no-op to avoid warnings
            Console.Write("Choice: ");
            string s = Console.ReadLine();
            int sel = 0;
            if (!int.TryParse(s, out sel))
            {
                Console.WriteLine("Invalid input.");
                return;
            }

            gm.RecordGoalEvent(sel);
        }
    }
}