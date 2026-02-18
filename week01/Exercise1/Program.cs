using System;

class Program
{
    static void Main(string[] args)
    {
        //its a simple program that asks the user for their first and last name and then greets them with a welcome message.
        Console.WriteLine("Hello World! This is the Exercise1 Project.");
        Console.Write("");
        Console.Write("What is your first name? ");
        string name = Console.ReadLine();
        Console.Write("");
        Console.WriteLine("What is your last name? ");
        string Surname = Console.ReadLine();
        Console.WriteLine($"Your name is {Surname}, {name} {Surname}! Welcome to the Exercise 1 Project.");
    }
}