using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, Type 0 when finished.");
        List<int> numbers = new List<int>();

        int number = -1;
        int sum = 0;
        int count = 0;
        while (number != 0)
        {
            string input = Console.ReadLine();
            number = int.Parse(input);


            if (number != 0)
            {
                numbers.Add(number);
            }
        }
        foreach (int num in numbers)
        {
            sum += num;
            count = numbers.Count;

        }
        float average = sum / count;
        Console.WriteLine($"The sum is {sum}");
        Console.WriteLine($"The average is {average}");
        Console.WriteLine($"The largest number is {numbers.Max()}");
        Console.WriteLine($"The smallest number is {numbers.Min()}");
        List<int> sortednumbers = new List<int>();
        sortednumbers = numbers;
        sortednumbers.Sort();
        Console.Write("The sorted numbers are: ");
        foreach (int num in sortednumbers)
        {
            Console.Write($"{num} ");
        }

    }
}