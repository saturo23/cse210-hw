using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        int userNumber = -1;

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

        // Find the smallest positive number
        int smallestPositive = int.MaxValue;
        foreach (int number in numbers)
        {
            if (number > 0 && number < smallestPositive)
            {
                smallestPositive = number;
            }
        }

        // Display the results
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");
        Console.WriteLine($"The smallest positive number is: {smallestPositive}");

        // Sort and display the sorted list
        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}
