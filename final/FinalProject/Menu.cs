using System;
namespace FinalProject
{
    public class Menu
    {
        private QuizEngine quizEngine = new QuizEngine();

        private VocabularyList vocabList = new VocabularyList();

        public void ShowMenu()
        {
            int choice = -1;

            while (choice != 0)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Add word and definition");
                Console.WriteLine("2. Save");
                Console.WriteLine("3. Load");
                Console.WriteLine("4. Take quiz");
                Console.WriteLine("0. Exit");

                string input = Console.ReadLine();
                int.TryParse(input, out choice);
                HandleInput(choice);
            }
        }

        public void HandleInput(int choice)
        {
            if (choice == 1)
            {
                Console.Write("Enter word: ");
                string word = Console.ReadLine();

                Console.Write("Enter definition: ");
                string definition = Console.ReadLine();
                
                VocabEntry entry = new VocabEntry();
                vocabList.AddEntry(entry);

                Console.WriteLine("Word added!");
            }
            else if (choice == 2)
            {
                Console.WriteLine("Save functionality not implemented yet.");
            }
            else if (choice == 3)
            {
                Console.WriteLine("Save functionality not implemented yet.");
            }
            else if (choice == 4)
            {
                quizEngine.StartQuiz(vocabList);
            }
        }
    }
}