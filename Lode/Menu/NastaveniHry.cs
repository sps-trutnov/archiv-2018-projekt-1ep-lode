using System;
using System.Collections.Generic;

namespace Lode
{
    class NastaveniHry
    {
        public void MenuNastaveni()
        {
            Console.Clear();
            Console.WriteLine("Jakou chcete barvu pozadi?");

            List<ConsoleColor> seznamBarev = new List<ConsoleColor>();

            seznamBarev.Add(ConsoleColor.Black);

            seznamBarev.Add(ConsoleColor.DarkBlue);
         
            seznamBarev.Add(ConsoleColor.DarkCyan);
      
            seznamBarev.Add(ConsoleColor.DarkGreen);

            seznamBarev.Add(ConsoleColor.DarkRed);

            seznamBarev.Add(ConsoleColor.DarkYellow);

            for (int i = 0; i < seznamBarev.Count; i++)
            {
                Console.WriteLine(seznamBarev[i]);
                Console.WriteLine();
            }

            Console.WriteLine("Prosím nebuď chytrej a napiš to jak to vidíš!!!");

            string odpovedBarvy = Console.ReadLine();

            if (odpovedBarvy.ToUpper() == "BLACK")
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (odpovedBarvy.ToUpper() == "DARKBLUE")
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (odpovedBarvy.ToUpper() == "DARKCYAN")
            {
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else if (odpovedBarvy.ToUpper() == "DARKGREEN")
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else if (odpovedBarvy.ToUpper() == "DARKRED")
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (odpovedBarvy.ToUpper() == "DARKYELLOW")
            {
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            Console.Clear();
        }
    }
}
