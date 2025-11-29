using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts;

    public ListingActivity()
        : base("Listing Activity",
               "This activity will help you reflect on the good things in your life by listing as many items as you can in a set time.")
    {
        _prompts = new List<string>
        {
            "Who are people you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.Clear();
        Console.WriteLine("Get ready...\n");
        ShowSpinner(2);

        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine($"\n--- {_prompts[new Random().Next(_prompts.Count)]} ---\n");

        Console.WriteLine("You may begin in:");
        ShowCountDown(5);

        List<string> responses = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string item = Console.ReadLine();
            responses.Add(item);
        }

        Console.WriteLine($"\nYou listed {responses.Count} items!");
        ShowSpinner(2);

        DisplayEndingMessage();
    }
}
