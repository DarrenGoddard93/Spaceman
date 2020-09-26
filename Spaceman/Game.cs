using System;
using System.Linq;

namespace Spaceman
{
    class Game
    {
        public string CodeWord
        { get; private set; }

        public string CurrentWord
        { get; private set; }

        public int MaxGuesses
        { get; }

        public int WrongGuesses
        { get; private set; }

        private string[] wordBank = new string[] {
      "fifa",
      "manager",
      "defender",
      "player",
      "formation",
      "striker"
    };

        private Ufo spaceship = new Ufo();

        public Game()
        {
            Random r = new Random();
            CodeWord = wordBank[r.Next(wordBank.Length)];
            MaxGuesses = 5;
            WrongGuesses = 0;
            for (int i = 0; i < CodeWord.Length; i++)
            {
                CurrentWord += "_";
            }
        }

        public void Greet()
        {
            Console.WriteLine("=============");
            Console.WriteLine("UFO: The Game");
            Console.WriteLine("=============");
            Console.WriteLine("Instructions: save your friend from alien abduction by guessing the letters in the codeword.");
            Console.WriteLine("The word is related to the aliens favourite game ... football. See if you can guess it.");
            Console.WriteLine("You have up to 5 wrong guesses until your friend is taken by aliens!");
        }

        public void Display()
        {
            Console.WriteLine(spaceship.Stringify());
            Console.WriteLine($"Current word: {CurrentWord}\n");
            Console.WriteLine($"Incorrect guesses: {WrongGuesses}\n");
        }

        public void Ask()
        {
            Console.Write("Guess a letter: ");
            string stringGuess = Console.ReadLine();
            Console.WriteLine();
            if (stringGuess.Trim().Length != 1)
            {
                Console.WriteLine("One letter at a time!");
                return;
            }
            char guess = stringGuess.Trim().ToCharArray()[0];
            if (CodeWord.Contains(guess))
            {
                Console.WriteLine($"'{guess}' is in the word!");
                for (int i = 0; i < CodeWord.Length; i++)
                {
                    if (guess == CodeWord[i])
                    {
                        CurrentWord = CurrentWord.Remove(i, 1).Insert(i, guess.ToString());
                    }
                }
            }
            else
            {
                Console.WriteLine($"'{guess}' isn't in the word! The tractor beam pulls the person in further...");
                WrongGuesses++;
                spaceship.AddPart();
            }
        }

        public bool DidWin()
        {
            if (CodeWord.Equals(CurrentWord))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DidLose()
        {
            if (WrongGuesses >= MaxGuesses)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}