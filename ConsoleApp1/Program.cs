using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("Läs in en text på svenska eller danska");

            string defaultText = "Lars Løkke Rasmussen är Danmarks tidigare premiärminister";
            string swedishCharacters = "åäöÅÄÖ";
            string danishCharacters = "æÆøØåÅ";

            string input = ConsoleReadLineWithDefault(defaultText);

            int swedishSum = 0; 
            int danishSum = 0;

            char[] swedishChars = swedishCharacters.ToCharArray();
            char[] danishChars = danishCharacters.ToCharArray();

            foreach (var item in input)
            {
                foreach (var charItem in swedishChars)
                {
                    if (charItem.Equals(item))
                        swedishSum++;
                }
                foreach (var charItem in danishChars)
                {
                    if (charItem.Equals(item))
                        danishSum++;
                }
            }

            // om några specialtecken finns i text så är den antingen svensk eller dansk
            if (swedishSum > 0 || danishSum > 0)
            {
                //om svenska tecken är fler eller lika är den svensk
                if (swedishSum > danishSum || swedishSum == danishSum)
                    Console.WriteLine("Texten är på svenska.");
                else
                    Console.WriteLine("Texten är på danska.");
            }
            else
            {
                Console.WriteLine("Det går inte att avgöra om texten är på svenska eller danska");
            }

            Console.WriteLine("Antal svenska tecken är: " + swedishSum);
            Console.WriteLine("Antal danska tecken är: " + danishSum);

            Console.ReadLine();
        }

        public static string ConsoleReadLineWithDefault(string defaultValue)
        {
            SendKeys.SendWait(defaultValue);
            return Console.ReadLine();
        }
    }
}
