using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace testt
{
    internal class Guest
    {
        private DateTime date = DateTime.Now;
        public bool runMenu = true;
        int tlfNumber;

        public bool TryAgain { get; set; }
        public bool Menu { get; set; }
        public string Correct { get; set; }
        public int Number { get; set; }
        public string FullName { get; set; }
        public string Company { get; set; }
        public string Responsible { get; set; }
        public string Form { get; set; }

        public void CheckIn()
        {
            while (true)
            {
                Console.Clear();
                Console.Write("Full Name: ");
                FullName = Console.ReadLine();

                Console.Write("Phone number: ");
                Number = Convert.ToInt32(Console.ReadLine());

                Console.Write("Company you represent: ");
                Company = Console.ReadLine();

                Console.Write("Responsible for your visit: ");
                Responsible = Console.ReadLine();

                Console.Write("Have you received a form? (YES or NO): ");
                Form = Console.ReadLine();

                Console.Write("\nIs the information above correct? (YES or NO): ");
                Correct = Console.ReadLine();

                if (Correct == "no")
                {
                    continue;
                }
                else if (Correct == "yes")
                {
                    Console.Clear();
                    Console.WriteLine("Thank you {0}. Your arrival at {1} has been registered.", FullName, date.ToString("f"));
                    Console.WriteLine("");

                    StreamWriter sw = new StreamWriter("..\\..\\..\\Save.txt", true);
                    sw.WriteLine(FullName);
                    sw.WriteLine(Number);
                    sw.Close();
                    break;
                }
                else
                {
                    Console.WriteLine("Input invalid. Try again");
                    continue;
                }
                break;
            }
        }
        public void CheckOut()
        {
            while (true)
            {
                Console.WriteLine("Please insert the following");
                Console.Write("Full name: ");
                String answerName = Console.ReadLine();
                Console.Write("Number: ");
                int answerNumber = Convert.ToInt32(Console.ReadLine());

                StreamReader sr = new StreamReader("..\\..\\..\\Save.txt");
                string newDocument = sr.ReadToEnd(); // læser dokumentet
                sr.Close(); // Lukker dokumentet igen

                if (newDocument.Contains(answerName) && newDocument.Contains(answerNumber.ToString())) //hvis indtastet oplysninger stemmer overens
                {
                    StreamWriter sw = new StreamWriter("..\\..\\..\\Save.txt", false);
                    newDocument = newDocument.Replace(answerName, null); // erstatter navn til intet
                    newDocument = newDocument.Replace(answerNumber.ToString(), null); // erstatter nummer til intet
                                                                                      // newDocument = Regex.Replace(newDocument, @"^\s+$[\r\n]*", string.Empty, RegexOptions.Multiline); // sletter tomme linjer
                    sw.Write(newDocument); // opdaterer dokumentet med slettet informationer
                    sw.Close();

                    Console.Clear();
                    Console.WriteLine("Thank you {0}, you have been checked out {1}.", answerName, date.ToString("f"));
                    Console.WriteLine("");
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Sorry, your credientals does not match our records. Please try again.");
                    Console.WriteLine("");
                    continue;
                }
                break;
            }
        }
        public void Exit()
        {
            runMenu = false;
        }
    }
}



