using System;
using System.Collections.Generic;

namespace FinalProject
{
    public class WordQuestion : QuizQuestion
    {
        private List<string> _choices;
        private string _correctWord;

        public WordQuestion(string definition, string correctWord, List<string> choices)
            : base(definition)
        {
            _choices = choices;
            _correctWord = correctWord;
        }

        public override bool Ask()
        {
            Console.WriteLine("\nDefinition:");
            Console.WriteLine(prompt);

            for (int i = 0; i < _choices.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_choices[i]}");
            }

            Console.Write("Answer: ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int choice))
            {
                return false;
            }

            if (choice < 1 || choice > _choices.Count)
            {
                return false;
            }

            string selectedAnswer = _choices[choice - 1];
            return selectedAnswer == _correctWord;
        }
    }
}
