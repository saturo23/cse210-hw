using System;
using System.Net;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(" Welcome to the Guess my Number Game. Exercise3 Project.");

        string playAgain = "yes"; // initialize to enter the loop

        while (playAgain.ToLower() == "yes")
        {


            // create a random generator
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101); // random number between 1 and 100

            int guess = -1; // starts the loop with invalid guess
            int guessCounter = 0; // counts the number of guesses

            Console.Write("l have a magic number between 1 and 100. ");

            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                string guessInput = Console.ReadLine();
                guess = int.Parse(guessInput);
                guessCounter++;


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
                    Console.WriteLine($"You guessed it! congratulations! It took you {guessCounter} guesses to find the magic number {magicNumber}.");
                }

            }

            Console.Write("Thank you for playing! Do you want to play again? (yes/no): ");
            playAgain = Console.ReadLine();

            Console.WriteLine("\n thank you for playing.");
        }

    }
}