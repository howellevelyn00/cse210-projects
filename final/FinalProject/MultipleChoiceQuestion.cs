using System;

namespace FinalProject
{
    public class MultipleChoiceQuestion : QuizQuestion
    {
        private string[] choices;
        private int correctIndex;

        public MultipleChoiceQuestion(
            string definition,
            string[] choices,
            int correctIndex
        ) : base(definition)
        {
            this.choices = choices;
            this.correctIndex = correctIndex;
        }

        public override bool Ask()
        {
            Console.WriteLine("\nDefinition:");
            Console.WriteLine(prompt);

            for (int i = 0; i < choices.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {choices[i]}");
            }

            Console.Write("Answer: ");
            int choice = int.Parse(Console.ReadLine()) - 1;

            return choice == correctIndex;
        }
    }
}
