using System;
using System.Collections.Generic;

namespace FinalProject
{
    public class QuizEngine
    {
        private static readonly Random _rng = new Random();

        public void StartQuiz(VocabularyList list, string chapter)
        {
            List<VocabEntry> entries = list.GetByChapter(chapter);

            if (entries.Count < 4)
            {
                Console.WriteLine("Not enough words for this chapter.");
                return;
            }

            int score = 0;

            foreach (VocabEntry entry in entries)
            {
                MultipleChoiceQuestion question =
                    BuildQuestion(entry, entries);

                if (question.Ask())
                {
                    score++;
                }
            }

            Console.WriteLine($"\nScore: {score}/{entries.Count}");
        }

        private MultipleChoiceQuestion BuildQuestion(
            VocabEntry correct,
            List<VocabEntry> pool
        )
        {
            List<string> choices = new List<string>();
            choices.Add(correct.Word);

            foreach (VocabEntry entry in pool)
            {
                if (choices.Count == 4)
                    break;

                if (entry.Word != correct.Word)
                {
                    choices.Add(entry.Word);
                }
            }

            // Shuffle choices so the correct answer isn't always first
            for (int i = choices.Count - 1; i > 0; i--)
            {
                int j = _rng.Next(i + 1);
                string temp = choices[i];
                choices[i] = choices[j];
                choices[j] = temp;
            }

            int correctIndex = choices.IndexOf(correct.Word);

            return new MultipleChoiceQuestion(
                correct.Definition,
                choices.ToArray(),
                correctIndex
            );
        }
    }
}
