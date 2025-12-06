using System;
namespace FinalProject
{
public class WordQuestion : QuizQuestion
{
    public WordQuestion(string prompt, string answer) : base(prompt, answer)
    {
    }

    public override bool Ask()
    {
        Console.WriteLine("Which word matches this definition: " + prompt);
        string input = Console.ReadLine();

        if (input.ToLower() == answer.ToLower())
        {
            Console.WriteLine("Correct!");
            return true;
        }

        Console.WriteLine("Wrong. Correct answer: " + answer);
        return false;
    }
}
}
