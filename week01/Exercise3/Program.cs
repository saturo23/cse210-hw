using System;
using System.Net;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise3 Project.");

        // create a random generator
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101); // random number between 1 and 100

        int guess = -1; // starts the loop with invalid guess

        Console.Write("l have a magic number between 1 and 100. What is your guess? ");

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