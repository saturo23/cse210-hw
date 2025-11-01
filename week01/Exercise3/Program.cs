using System;
using System.Net;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise3 Project.");

        Console.Write("What is the magic number? ");
        string magicInput = Console.ReadLine();
        int magicNumber = int.Parse(magicInput);

        Console.Write("What is your guess? ");
        string guessInput = Console.ReadLine();
        int guess = int.Parse(guessInput);

        if (guess < magicNumber)
        {
            Console.WriteLine("Higher");
        }
        else if (guess > magicNumber)
        {
            Console.WriteLine("Lower");
        }
        else
        {
            Console.WriteLine("You guessed it!");
        }
    }
}