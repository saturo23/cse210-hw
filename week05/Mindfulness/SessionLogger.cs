using System;
using System.Collections.Generic;

public class SessionLogger
{
    private List<LogEntry> _entries = new List<LogEntry>();

    public void AddEntry(string activityName, int duration)
    {
        _entries.Add(new LogEntry
        {
            ActivityName = activityName,
            Duration = duration,
            Timestamp = DateTime.Now
        });
    }

    public void DisplayLog()
    {
        Console.WriteLine("\nActivity Log:");
        foreach (var entry in _entries)
        {
            Console.WriteLine($"{entry.Timestamp}: {entry.ActivityName} - {entry.Duration} seconds");
        }
    }
}
