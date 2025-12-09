using System;

public abstract class Activity
{
    private string _date;
    private int _length; // minutes

    public Activity(string date, int length)
    {
        _date = date;
        _length = length;
    }

    public string GetDate()
    {
        return _date;
    }

    public int GetLength()
    {
        return _length;
    }

    // ABSTRACT METHODS — MUST be overridden
    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    // BASE SUMMARY — calls virtual methods
    public virtual string GetSummary()
    {
        return $"{_date} {GetType().Name} ({_length} min): " +
               $"Distance {GetDistance():0.0} km, " +
               $"Speed {GetSpeed():0.0} kph, " +
               $"Pace: {GetPace():0.0} min per km";
    }
}
