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

        int guess = -1; // starts the loop with invalid guess

        while (guess != magicNumber)
        {
            Console.Write("What is your guess? ");
            string guessInput = Console.ReadLine();
            guess = int.Parse(guessInput);

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
}