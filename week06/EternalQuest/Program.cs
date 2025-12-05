using System;

namespace EternalQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            var manager = new GoalManager();
            const string saveFile = "goals.txt";

            Console.WriteLine("Welcome to Eternal Quest!");
            Console.WriteLine("Track goals, earn points, and have fun.\n");

            bool running = true;
            while (running)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1) Create new goal");
                Console.WriteLine("2) List goals");
                Console.WriteLine("3) Record event (mark progress)");
                Console.WriteLine("4) Show score");
                Console.WriteLine("5) Save goals");
                Console.WriteLine("6) Load goals");
                Console.WriteLine("7) Quit");
                Console.Write("Choose an option: ");

                string input = Console.ReadLine() ?? "";
                Console.WriteLine();

                switch (input.Trim())
                {
                    case "1":
                        CreateGoal(manager);
                        break;
                    case "2":
                        manager.ListGoals();
                        break;
                    case "3":
                        RecordEvent(manager);
                        break;
                    case "4":
                        Console.WriteLine($"Total points: {manager.TotalPoints}");
                        break;
                    case "5":
                        manager.Save(saveFile);
                        break;
                    case "6":
                        manager.Load(saveFile);
                        break;
                    case "7":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Please choose a number from 1 to 7.");
                        break;
                }
            }

            Console.WriteLine("Thanks for playing Eternal Quest! Goodbye.");
        }

        // CreateGoal: ask user for type and details, then add to manager.
        static void CreateGoal(GoalManager manager)
        {
            Console.WriteLine("Select goal type:");
            Console.WriteLine("1) Simple (one-time)");
            Console.WriteLine("2) Eternal (repeatable)");
            Console.WriteLine("3) Checklist (times + bonus)");
            Console.WriteLine("4) Negative (bad habit, lose points)");
            Console.Write("Type number: ");
            string t = Console.ReadLine() ?? "";

            Console.Write("Title: ");
            string title = Console.ReadLine() ?? "";

            Console.Write("Description: ");
            string desc = Console.ReadLine() ?? "";

            // For types that use 'points', we ask for a number.
            int points = 0;
            if (t == "1" || t == "2" || t == "3" || t == "4")
            {
                Console.Write("Points (positive integer): ");
                int.TryParse(Console.ReadLine(), out points);
            }

            switch (t)
            {
                case "1":
                    manager.AddGoal(new SimpleGoal(title, desc, points));
                    Console.WriteLine("Simple goal added.");
                    break;

                case "2":
                    manager.AddGoal(new EternalGoal(title, desc, points));
                    Console.WriteLine("Eternal goal added.");
                    break;

                case "3":
                    Console.Write("Target count (how many times to complete): ");
                    int.TryParse(Console.ReadLine(), out int target);
                    Console.Write("Bonus points on final completion: ");
                    int.TryParse(Console.ReadLine(), out int bonus);
                    manager.AddGoal(new ChecklistGoal(title, desc, points, target, bonus));
                    Console.WriteLine("Checklist goal added.");
                    break;

                case "4":
                    // Negative goal uses 'points' input as penalty
                    manager.AddGoal(new NegativeGoal(title, desc, points));
                    Console.WriteLine("Negative goal added.");
                    break;

                default:
                    Console.WriteLine("Unknown type. Goal not added.");
                    break;
            }
        }

        // RecordEvent: shows list and asks which goal to record.
        static void RecordEvent(GoalManager manager)
        {
            var goals = manager.GetGoals();
            if (goals.Count == 0)
            {
                Console.WriteLine("No goals to record. Add some first.");
                return;
            }

            manager.ListGoals();
            Console.Write("Enter goal number to record event (0 to cancel): ");
            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid input.");
                return;
            }

            if (choice == 0) return;

            manager.RecordEvent(choice - 1);
        }
    }
}

