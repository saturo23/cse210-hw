using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        // Create one of each type
        activities.Add(new Running("03 Nov 2022", 30, 4.8));
        activities.Add(new Cycling("03 Nov 2022", 45, 20));
        activities.Add(new Swimming("03 Nov 2022", 30, 40));

        // Display summaries using polymorphism
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
