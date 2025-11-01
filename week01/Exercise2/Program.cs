using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise2 Project.");
        Console.Write("What is your grade percentage? ");
        string input = Console.ReadLine();
        int grade = int.Parse(input);
        if (grade >= 90)
        {
            Console.WriteLine("Your letter grade is A.");
        }
        else if (grade >= 80)
        {
            Console.WriteLine("Your letter grade is B.");
        }
        else if (grade >= 70)
        {
            Console.WriteLine("Your letter grade is C.");
        }
        else if (grade >= 60)
        {
            Console.WriteLine("Your letter grade is D.");
        }
        else
        {
            Console.WriteLine("Your letter grade is F.");
        }
        if (grade >= 70)
        {
            Console.WriteLine("Congratulations! you have passed the course.");
        }
        else
        {
            Console.WriteLine("Unfortunately, you have not passed the course. Try harder next time!");
        }
    }
}