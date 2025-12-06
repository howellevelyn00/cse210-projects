using System;
namespace FinalProject
{
public abstract class QuizQuestion
{
    protected string prompt;
    protected string answer;

    public QuizQuestion(string prompt, string answer)
    {
        this.prompt = prompt;
        this.answer = answer;
    }

    public abstract bool Ask();

    public string GetPrompt()
    {
        return prompt;
    }

    public string GetAnswer()
    {
        return answer;
    }
}
}