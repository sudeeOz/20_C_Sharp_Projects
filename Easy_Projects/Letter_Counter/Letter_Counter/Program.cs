using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letter_Counter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // This program counts the occurrences of each letter in a given string.
            Console.WriteLine("Enter a string to count the letters:");  
            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("No input provided.");
                return;
            }
            // Create a dictionary to hold letter counts
            Dictionary<char, int> letterCounts = new Dictionary<char, int>();
            // Iterate through each character in the input string
            foreach (char c in input.ToLower())
            {
                // Check if the character is a letter
                if (char.IsLetter(c))
                {
                    // If the letter is already in the dictionary, increment its count
                    if (letterCounts.ContainsKey(c))
                    {
                        letterCounts[c]++;
                    }
                    // Otherwise, add it to the dictionary with a count of 1
                    else
                    {
                        letterCounts[c] = 1;
                    }
                }
            }
            // Display the letter counts
            Console.WriteLine("Letter counts:");
            foreach (var kvp in letterCounts.OrderBy(k => k.Key))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
            Console.WriteLine("Total unique letters: " + letterCounts.Count);
            Console.WriteLine("Total letters counted: " + input.Count(char.IsLetter));
            // Wait for user input before closing the console window
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();

        }
    }
}
