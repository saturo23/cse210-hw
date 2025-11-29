using System;
using System.Threading;

public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    // Public getter for duration
    public int Duration
    {
        get { return _duration; }
    }

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} Activity!\n");
        Console.WriteLine(_description);
        Console.Write("\nEnter the duration in seconds: ");
        _duration = int.Parse(Console.ReadLine());

        Console.WriteLine("\nPrepare to begin...");
        ShowSpinner(3);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("\nGreat job! You have completed the activity.");
        ShowSpinner(2);

        Console.WriteLine($"\nYou completed {_duration} seconds of the {_name} Activity.");
        ShowSpinner(4);
    }

    protected void ShowSpinner(int seconds)
    {
        char[] icons = { '|', '/', '-', '\\' };
        DateTime end = DateTime.Now.AddSeconds(seconds);

        int i = 0;
        while (DateTime.Now < end)
        {
            Console.Write(icons[i]);
            Thread.Sleep(250);
            Console.Write("\b \b");

            i = (i + 1) % icons.Length;
        }
    }

    protected void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        Console.WriteLine();
    }
}
