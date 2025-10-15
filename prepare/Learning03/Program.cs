using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction fraction1 = new Fraction();
        fraction1.SetTop(1);
        Console.WriteLine(fraction1.GetFractionString());
        Fraction fraction2 = new Fraction();
        fraction2.SetTop(5);
        Console.WriteLine(fraction2.GetFractionString());
        Fraction fraction3 = new Fraction();
        fraction3.SetTop(3);
        fraction3.SetBottom(4);
        Console.WriteLine(fraction3.GetFractionString());
        Fraction fraction4 = new Fraction(1);
        Console.WriteLine(fraction4.GetFractionString());
        Fraction fraction5 = new Fraction(1, 3);
        Console.WriteLine(fraction5.GetFractionString());
    }
}
public class Fraction
{
    private int _top;
    private int _bottom;

    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    public Fraction(int wholeNumber)
    {
        _top = wholeNumber;
        _bottom = 1;
    }

    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    public int GetTop()
    {
        return _top;
    }

    public int GetBottom()
    {
        return _bottom;
    }

    public void SetTop(int top)
    {
        _top = top;
    }
    public void SetBottom(int bottom)
    {
        _bottom = bottom;
    }

    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    public double GetDecimalValue()
    {
        return (double)_top / _bottom;
    }
    
}