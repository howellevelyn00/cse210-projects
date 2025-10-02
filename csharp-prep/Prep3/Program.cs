using System;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        int secretNumber = random.Next(1, 101);
        int guess = -1;
        int count = 0;
        string playAgain = "yes";


        while (playAgain == "yes")
        {
            while (guess != secretNumber)
            {
                Console.WriteLine("What is your guess for the Secert Number?");
                string guessInput = Console.ReadLine();
                guess = int.Parse(guessInput);
                count = count + 1;

                if (guess < secretNumber)
                {
                    Console.WriteLine("Higher");

                }
                else if (guess > secretNumber)
                {
                    Console.WriteLine("Lower");

                }
                else
                {
                    Console.WriteLine("You guessed it!");
                    Console.WriteLine($"It took you {count} guesses to get the number {secretNumber}");
                    Console.WriteLine("Would you like to play again? (yes/no)");
                    playAgain = Console.ReadLine();
                }
            }
        }
    }
}