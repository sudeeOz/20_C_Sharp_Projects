using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Body_Mass_Index_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Welcome! This program calculates your Body Mass Index (BMI).
            // It takes your weight in kilograms and height in meters as inputs.

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("                       Welcome to the Body Mass Index (BMI) Calculator!\n\n");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Please enter your weight in kilograms (kg):");
            Console.ResetColor();
            int weight =Convert.ToInt32(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Please enter your height in meters (m) (use ',' not '.') :");
            Console.ResetColor();
            double height = Convert.ToDouble(Console.ReadLine());

            Console.ResetColor();
            // Create an instance of the BMI calculator
            double bmi = CalculateBMI(weight, height);

            Message(bmi);
        }

        public static double CalculateBMI(int weight, double height)
        {
            // BMI is calculated as weight (kg) / (height (m) * height (m))

            double bmi = weight / (height * height);
            return bmi;
        }

        public static void Message(double bmi)
        {
            if (bmi < 18.5)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Your BMI is {bmi:F2}. You are underweight.");
            }
            else if (bmi >= 18.5 && bmi < 24.9)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Your BMI is {bmi:F2}. You have a normal weight.");
            }
            else if (bmi >= 25 && bmi < 29.9)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Your BMI is {bmi:F2}. You are overweight.");
            }
            else if (bmi >= 30 && bmi < 34.9)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"Your BMI is {bmi:F2}. You are classified as obese (Class I).");
            }
            else if (bmi >= 35 && bmi < 39.9)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"Your BMI is {bmi:F2}. You are classified as obese (Class II).");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Your BMI is {bmi:F2}. You are obese.");
            }
            Console.ResetColor();
        }
    }
}
