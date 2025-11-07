using System;

/// This program helps users keep a daily journal by providing random prompts,
/// saving entries to a file, and loading them later.
/// It demonstrates the principles of abstraction, encapsulation, and class design.
/// Added extra prompts beyond the required five.
/// Added file existence validation and user feedback.
/// Added success messages for user clarity.
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Journal Program!");
        Console.WriteLine("--------------------------------");

        Journal journal = new Journal();
        PromptGenerator generator = new PromptGenerator();

        bool running = true;

        while (running)
        {
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Write a New Entry");
            Console.WriteLine("2. Display Journal");
            Console.WriteLine("3. Save Journal to File");
            Console.WriteLine("4. Load Journal from File");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option (1–5): ");
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    string prompt = generator.PickRandomPrompt();
                    Console.WriteLine($"Prompt: {prompt}");
                    Console.Write("Your response: ");
                    string response = Console.ReadLine();
                    string date = DateTime.Now.ToShortDateString();

                    Entry newEntry = new Entry(date, prompt, response);
                    journal.AddEntry(newEntry);
                    Console.WriteLine("Entry recorded successfully!");
                    break;

                case "2":
                    journal.Display();
                    break;

                case "3":
                    Console.Write("Enter filename to save (e.g. journal.txt): ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    break;

                case "4":
                    Console.Write("Enter filename to load (e.g. journal.txt): ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    break;

                case "5":
                    Console.WriteLine("Thank you for using the Journal Program. Goodbye!");
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid option. Please select 1–5.");
                    break;
            }
        }
    }
}
