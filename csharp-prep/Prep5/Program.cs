using System;
using System.Net.NetworkInformation;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string name = ProptUserName();
        int number = ProptUserNumber();
        int birthYear = ProptUserBirthYear();
        int squared = SquareNumber(number);
        DisplayResult(name, squared, birthYear);

    }
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }
    static string ProptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }
    static int ProptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        string number = Console.ReadLine();
        return int.Parse(number);
    }
    static int ProptUserBirthYear()
    {
        Console.Write("Please enter your birth year: ");
        string year = Console.ReadLine();
        return int.Parse(year);
    }
    static int SquareNumber(int number)
    {
        int squared = number * number;
        return squared;
    }
    static void DisplayResult(string name, int squared, int birthYear)
    {
        Console.WriteLine($"{name}, the square of your number is {squared}");
        int age = 2025 - birthYear;
        Console.WriteLine($"{name}, You are {age} years old");
    }
}