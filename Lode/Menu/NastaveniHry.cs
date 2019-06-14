using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            seznamBarev.Add(ConsoleColor.Blue);
            seznamBarev.Add(ConsoleColor.DarkBlue);
            seznamBarev.Add(ConsoleColor.DarkCyan);
            seznamBarev.Add(ConsoleColor.DarkGreen);
            seznamBarev.Add(ConsoleColor.DarkRed);
            seznamBarev.Add(ConsoleColor.DarkYellow);

            for (int i = 0; i < seznamBarev.Count; i++)
            {
                Console.WriteLine("Volba" + i + ":" + seznamBarev[i]);
            }
            string odpovedBarvy = Console.ReadLine();

        }
    }
}
