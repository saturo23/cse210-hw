using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise1 Project.");
        Console.Write("");
        Console.Write("What is your first name? ");
        string name = Console.ReadLine();
        Console.Write("");
        Console.WriteLine("What is your last name? ");
        string Surname = Console.ReadLine();
        Console.WriteLine($"Your name is {Surname}, {name} {Surname}! Welcome to the Exercise1 Project.");
    }
}