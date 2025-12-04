using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create shapes
        Square s = new Square("Red", 5);
        Rectangle r = new Rectangle("Blue", 4, 6);
        Circle c = new Circle("Green", 3);

        // Add them to a list of Shapes
        List<Shape> shapes = new List<Shape>();
        shapes.Add(s);
        shapes.Add(r);
        shapes.Add(c);

        // Display areas using polymorphism
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Color: {shape.GetColor()}");
            Console.WriteLine($"Area: {shape.GetArea()}");
            Console.WriteLine("-----------------------");
        }
    }
}
