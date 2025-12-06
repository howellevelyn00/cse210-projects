using System;
namespace FinalProject
{
public class DefinitionQuestion : QuizQuestion
{
    public DefinitionQuestion(string prompt, string answer) : base(prompt, answer)
    {
    }

    public override bool Ask()
    {
        Console.WriteLine("What is the definition of: " + prompt);
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