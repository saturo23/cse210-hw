using System;

class Program
{
    static void Main(string[] args)
    {
        // Display welcome message
        DisplayWelcome();

        // Get user's name and favorite number
        string userName = PromptUserName();
        int userNumber = PromptUserNumber();

        // Calculate the square of the number
        int squaredNumber = SquareNumber(userNumber);

        // Show the final result
        DisplayResult(userName, squaredNumber);
    }

    // Displays a welcome message
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    // Prompts for and returns the user's name
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }

    // Prompts for and returns the user's favorite number
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());
        return number;
    }

    // Returns the square of the given number
    static int SquareNumber(int number)
    {
        return number * number;
    }

    // Displays the user's name and the squared number
    static void DisplayResult(string name, int squaredNumber)
    {
        Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
    }
}
