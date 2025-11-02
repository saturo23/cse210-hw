using System;

class Program
{
    // Displays a welcome message to the user
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    // Prompts the user for their name and returns it
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }
    // Prompts the user for their favorite number and returns it as an integer
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());
        return number;
    }

    // Squares the given number and returns the result
    static int SquareNumber(int number)
    {
        return number * number;
    }

    // Displays the final result using the user's name and squared number
    static void DisplayResult(string name, int squaredNumber)
    {
        Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
    }

    // Main method — calls all other functions in the correct order
    static void Main(string[] args)
    {
        DisplayWelcome();

        string userName = PromptUserName();
        int userNumber = PromptUserNumber();

        int squaredNumber = SquareNumber(userNumber);

        DisplayResult(userName, squaredNumber);
    }
}
