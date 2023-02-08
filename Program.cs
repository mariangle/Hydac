using System.Reflection.Metadata.Ecma335;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.ComponentModel.Design;

namespace testt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Skift af konsolfarve
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;

            Guest newGuest = new Guest();

            while (newGuest.runMenu)
            {

                Console.WriteLine("Welcome to Hydac (Press 1, 2 or 3 and enter to continue)");
                Console.WriteLine("1. Check in\n2. Check out\n3. Exit");
                int answer = Convert.ToInt32(Console.ReadLine());

                if (answer == 1)
                {
                    newGuest.CheckIn();
                }

                else if (answer == 2)
                {
                    Console.Clear();
                    newGuest.CheckOut();
                }
                else if (answer == 3)
                {
                    newGuest.Exit();
                }
                else
                {
                    Console.Clear(); 
                    Console.WriteLine("Invalid input. Please try again.");
                    continue;
                }
            }
        }
    }
}
