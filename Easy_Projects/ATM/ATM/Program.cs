using System;
using System.Collections.Generic;
using System.Linq;

namespace ATM
{
    public class Users
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Balance { get; set; } = 0; // Default balance is set to 0

        public Users(int id, string name, string surname, int balance)
        {
            ID = id;
            Name = name;
            Surname = surname;
            Balance = balance;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // This project simulates an ATM system
            // Users can create accounts, log in, and perform banking operations

            var users = new List<Users>();
            int nextID = 1;

            while (true) // Main loop: returns here after logging out
            {
                Users currentUser = null;

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("****************** WELCOME TO THE ATM ******************");
                Console.ResetColor();

                // Account creation or login
                while (currentUser == null)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Do you have an account? [Y/N] (Press ESC to exit ATM)");
                    Console.ResetColor();

                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Key == ConsoleKey.N)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nPlease enter your name:");
                        Console.ResetColor();
                        string name = Console.ReadLine();

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Please enter your surname:");
                        Console.ResetColor();
                        string surname = Console.ReadLine();

                        currentUser = new Users(nextID, name, surname, 0);
                        users.Add(currentUser);

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Your account has been created successfully. Your ID is {nextID}.");
                        Console.ResetColor();
                        nextID++;

                        Console.ReadKey();
                    }
                    else if (key.Key == ConsoleKey.Y)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nPlease enter your ID:");
                        Console.ResetColor();

                        if (int.TryParse(Console.ReadLine(), out int userId))
                        {
                            currentUser = users.FirstOrDefault(u => u.ID == userId);
                            if (currentUser != null)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine($"Welcome back, {currentUser.Name}!");
                                Console.ResetColor();
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("User not found. Please create an account first.");
                                Console.ResetColor();
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid ID format.");
                            Console.ResetColor();
                        }
                    }
                    else if (key.Key == ConsoleKey.Escape)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nExiting the ATM. Goodbye!");
                        Console.ResetColor();
                        return; // Completely exit program
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nInvalid input. Please try again.");
                        Console.ResetColor();
                    }
                }

                // ATM menu loop
                bool logout = false;
                while (!logout)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("****************** ATM MENU ******************");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("1. Check Balance");
                    Console.WriteLine("2. Deposit Money");
                    Console.WriteLine("3. Withdraw Money");
                    Console.WriteLine("4. Logout");
                    Console.ResetColor();

                    if (!int.TryParse(Console.ReadLine(), out int choice))
                    {
                        Console.WriteLine("Invalid choice. Please enter a number.");
                        Console.ReadKey();
                        continue;
                    }

                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine($"Your balance is: {currentUser.Balance}");
                            Console.ReadKey();
                            break;

                        case 2:
                            Console.WriteLine("Enter the amount to deposit:");
                            if (int.TryParse(Console.ReadLine(), out int depositAmount) && depositAmount > 0)
                            {
                                currentUser.Balance += depositAmount;
                                Console.WriteLine($"Successfully deposited {depositAmount}. New balance is {currentUser.Balance}.");
                            }
                            else
                            {
                                Console.WriteLine("Invalid deposit amount.");
                            }
                            Console.ReadKey();
                            break;

                        case 3:
                            Console.WriteLine("Enter the amount to withdraw:");
                            if (int.TryParse(Console.ReadLine(), out int withdrawAmount) && withdrawAmount > 0)
                            {
                                if (withdrawAmount <= currentUser.Balance)
                                {
                                    currentUser.Balance -= withdrawAmount;
                                    Console.WriteLine($"Successfully withdrew {withdrawAmount}. New balance is {currentUser.Balance}.");
                                }
                                else
                                {
                                    Console.WriteLine("Insufficient balance.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid withdrawal amount.");
                            }
                            Console.ReadKey();
                            break;

                        case 4:
                            Console.WriteLine("Logging out...");
                            Console.ReadKey();
                            logout = true; // Exit ATM menu, go back to login screen
                            break;

                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            Console.ReadKey();
                            break;
                    }
                }
            }
        }
    }
}
