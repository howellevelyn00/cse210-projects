using System;

namespace FinalProject
{
    public class Menu
    {
        private VocabularyList vocabList;
        private FileManager fileManager;
        private QuizEngine quizEngine;

        public Menu()
        {
            vocabList = new VocabularyList();
            fileManager = new FileManager();
            quizEngine = new QuizEngine();
        }

        public void Run()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n1. Add word");
                Console.WriteLine("2. Save");
                Console.WriteLine("3. Load");
                Console.WriteLine("4. Take quiz");
                Console.WriteLine("5. Exit");
                Console.Write("Choice: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddWord();
                        break;
                    case "2":
                        fileManager.Save(vocabList, "vocab.txt");
                        break;
                    case "3":
                        vocabList = fileManager.Load("vocab.txt");
                        break;
                    case "4":
                        Console.Write("Enter chapter: ");
                        string chapter = Console.ReadLine();
                        quizEngine.StartQuiz(vocabList, chapter);
                        break;
                    case "5":
                        running = false;
                        break;
                }
            }
        }

        private void AddWord()
        {
            Console.Write("Word: ");
            string word = Console.ReadLine();

            Console.Write("Definition: ");
            string definition = Console.ReadLine();

            Console.Write("Chapter: ");
            string chapter = Console.ReadLine();

            vocabList.AddEntry(new VocabEntry(word, definition, chapter));
        }
    }
}
