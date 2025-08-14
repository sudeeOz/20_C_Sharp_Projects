using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alarm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Should you set the alarm? You are in right place.
            Console.WriteLine("Welcome to the Alarm System!");
            Console.WriteLine("Please enter the time to set the alarm (HH:mm):");
            string inputTime = Console.ReadLine();
            DateTime alarmTime;
            if (DateTime.TryParse(inputTime, out alarmTime))
            {
                Console.WriteLine($"Alarm set for {alarmTime.ToShortTimeString()}");
                while (true)
                {
                    if (DateTime.Now >= alarmTime)
                    {
                        Console.WriteLine("Alarm ringing! Time to wake up!");
                        Console.Beep(); // This will make a beep sound
                        break;
                    }
                    System.Threading.Thread.Sleep(1000); // Check every second
                }
            }
            else
            {
                Console.WriteLine("Invalid time format. Please use HH:mm.");
            }
        }
    }
}
