using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number_Guessing_Game
{
    internal class Program
    {
        //Welcome! I'll code a game : Number Guessing Game.
        //This game will ask the user to guess a number between 1 and 100.
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("**************NUMBER GUESSING GAME**************\n\n");
            Console.BackgroundColor = ConsoleColor.Black;

            int numberToGuess = RNumber();
            bool isGuessed = false;

            Console.WriteLine("Keeping a number...\n");
            Console.WriteLine("Try to guess the number between 1 and 100!\n");

            while (!isGuessed)
            {
                Console.Write("Enter your guess: ");
                string userInput = Console.ReadLine();
                int userGuess;
                // Validate input
                if (int.TryParse(userInput, out userGuess))
                {
                    if (userGuess < 1 || userGuess > 100)
                    {
                        Console.WriteLine("Please enter a number between 1 and 100.");
                        continue;
                    }
                    if (userGuess < numberToGuess)
                    {
                        Console.WriteLine("Too low! Try again.");
                    }
                    else if (userGuess > numberToGuess)
                    {
                        Console.WriteLine("Too high! Try again.");
                    }
                    else
                    {
                        Console.WriteLine("Congratulations! You've guessed the number!");
                        isGuessed = true;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }

        }
        public static int RNumber()
        {
            Random random = new Random();
            int number = random.Next(1, 101); // Generates a random number between 1 and 100
            return number;
        }
    }
}
