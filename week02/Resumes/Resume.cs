using System;
using System.Collections.Generic;

// Represents a person's resume containing a name and a list of jobs
public class Resume
{
    // Person's name
    public string _name = "";

    // List of Job objects. Initialized so it's ready to use.
    public List<Job> _jobs = new List<Job>();

    // Displays the resume: name then each job on its own line
    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");

        // Use each Job's Display() method to print it
        foreach (Job j in _jobs)
        {
            j.Display();
        }
    }
}

