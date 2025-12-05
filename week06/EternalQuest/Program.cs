using System;

namespace EternalQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            var manager = new GoalManager();
            const string saveFile = "goals.txt";

            bool running = true;
            while (running)
            {
                Console.WriteLine("\nEternal Quest - Menu");
                Console.WriteLine("1. Create new goal");
                Console.WriteLine("2. List goals");
                Console.WriteLine("3. Record event (complete goal / mark progress)");
                Console.WriteLine("4. Show score");
                Console.WriteLine("5. Save goals");
                Console.WriteLine("6. Load goals");
                Console.WriteLine("7. Quit");
                Console.Write("Choose an option: ");
                var input = Console.ReadLine();

                switch (input)
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
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        static void CreateGoal(GoalManager manager)
        {
            Console.WriteLine("Choose type: 1) Simple  2) Eternal  3) Checklist");
            var t = Console.ReadLine();

            Console.Write("Title: "); string title = Console.ReadLine();
            Console.Write("Description: "); string desc = Console.ReadLine();
            Console.Write("Points per event: "); int points = int.Parse(Console.ReadLine() ?? "0");

            switch (t)
            {
                case "1":
                    manager.AddGoal(new SimpleGoal(title, desc, points));
                    break;
                case "2":
                    manager.AddGoal(new EternalGoal(title, desc, points));
                    break;
                case "3":
                    Console.Write("Target count: "); int target = int.Parse(Console.ReadLine() ?? "0");
                    Console.Write("Bonus on completion: "); int bonus = int.Parse(Console.ReadLine() ?? "0");
                    manager.AddGoal(new ChecklistGoal(title, desc, points, target, bonus));
                    break;
                default:
                    Console.WriteLine("Unknown type.");
                    break;
            }
            Console.WriteLine("Goal added.");
        }

        static void RecordEvent(GoalManager manager)
        {
            manager.ListGoals();
            Console.Write("Enter goal number to record event (or 0 to cancel): ");
            if (!int.TryParse(Console.ReadLine(), out int choice)) return;
            if (choice == 0) return;
            manager.RecordEvent(choice - 1);
        }
    }
}
