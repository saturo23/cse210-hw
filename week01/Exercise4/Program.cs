using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise4 Project.");

        // Create a list to store the numbers
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        int userNumber = -1; // Start with a non-zero number so loop begins

        // Keep asking for numbers until user enters 0
        while (userNumber != 0)
        {
            Console.Write("Enter number: ");
            string input = Console.ReadLine();
            userNumber = int.Parse(input);

            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        }

        // Compute the sum
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }

        // Compute the average
        float average = ((float)sum) / numbers.Count;

        // Find the largest number
        int max = numbers[0];
        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }

        // Display results
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");
    }
}
