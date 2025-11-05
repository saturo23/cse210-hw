using System;

// Represents a single job (company, title, start/end years)
public class Job
{
    // Member variables (fields)
    public string _company = "";
    public string _jobTitle = "";
    public int _startYear = 0;
    public int _endYear = 0;

    // Displays the job information in a formatted way
    public void Display()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }
}