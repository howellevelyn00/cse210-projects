using System;

namespace Learning04
{
    class Program
    {
        static void Main(string[] args)
        {
            // Test base Assignment
            Assignment assignment = new Assignment("Samuel Bennett", "Multiplication");
            Console.WriteLine(assignment.GetSummary());
            Console.WriteLine();

            // Test MathAssignment
            MathAssignment math = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19");
            Console.WriteLine(math.GetSummary());
            Console.WriteLine(math.GetHomeworkList());
            Console.WriteLine();

            // Test WritingAssignment
            WritingAssignment writing = new WritingAssignment("Emily Johnson", "Poetry", "Sonnet Analysis", 750);
            Console.WriteLine(writing.GetSummary());
            Console.WriteLine(writing.GetWritingInformation());
        }
    }
}