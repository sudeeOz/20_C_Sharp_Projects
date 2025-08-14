using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace which_day_you_were_born
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Hello, his is a simple program to find out which day of the week you were born on.
            Console.WriteLine("Enter your date of birth (dd/mm/yyyy):");
            string input = Console.ReadLine();
            DateTime dateOfBirth;
            // Try to parse the input date
            if (DateTime.TryParse(input, out dateOfBirth))
            {
                // Get the day of the week
                DayOfWeek dayOfWeek = dateOfBirth.DayOfWeek;
                // Output the result
                Console.WriteLine($"You were born on a {dayOfWeek}.");
            }
            else
            {
                // If parsing fails, inform the user
                Console.WriteLine("Invalid date format. Please enter the date in dd/mm/yyyy format.");
            }
        }
    }
}
