using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Build a list of different shapes
        List<Shape> shapes = new List<Shape>();

        shapes.Add(new Square("Red", 4));
        shapes.Add(new Rectangle("Blue", 5, 3));
        shapes.Add(new Circle("Green", 2));

        // Show color + area for each
        foreach (Shape s in shapes)
        {
            Console.WriteLine("Color: " + s.GetColor());
            Console.WriteLine("Area: " + s.GetArea());
            Console.WriteLine();
        }
    }
}
