using System;

public class Fraction
{
    // --- Private attributes ---
    private int _top;
    private int _bottom;

    // --- Constructors ---

    // 1. Default constructor (1/1)
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    // 2. Constructor with one parameter (top only, bottom = 1)
    public Fraction(int top)
    {
        _top = top;
        _bottom = 1;
    }

    // 3. Constructor with two parameters (top and bottom)
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    // --- Getters and Setters ---
    public int GetTop()
    {
        return _top;
    }

    public void SetTop(int top)
    {
        _top = top;
    }

    public int GetBottom()
    {
        return _bottom;
    }

    public void SetBottom(int bottom)
    {
        _bottom = bottom;
    }

    // --- Methods to represent the fraction ---

    // Return the fraction as a string (e.g., "3/4")
    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    // Return the fraction as a decimal value
    public double GetDecimalValue()
    {
        return (double)_top / _bottom;
    }
}
