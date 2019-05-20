using System;

namespace Lode
{
    class TextoveRozhrani : IRozhrani
    {
        public bool PolozitOtazkuAnoNe(string otazka, string chyboveHlaseni, bool defaultniOdpoved)
        {
            bool? obdrzenaOdpoved = null;
            bool viditelnostKurzoru = Console.CursorVisible;

            Console.CursorVisible = false;
            do
            {
                Console.Write(otazka);

                ConsoleKeyInfo? odpoved = Console.ReadKey(true);

                if (odpoved.Value.Key == ConsoleKey.A)
                    obdrzenaOdpoved = true;
                else if (odpoved.Value.Key == ConsoleKey.N)
                    obdrzenaOdpoved = false;
                else if (odpoved.Value.Key == ConsoleKey.Enter)
                    obdrzenaOdpoved = defaultniOdpoved;
                else
                    Console.WriteLine("\n" + chyboveHlaseni);

            } while (!obdrzenaOdpoved.HasValue);
            Console.CursorVisible = viditelnostKurzoru;

            Console.WriteLine();

            return (bool)obdrzenaOdpoved;
        }
        public void VykreslitHerniPole(StavPolicka[,] herniPole)
        {
            for (int y = herniPole.GetLength(1) - 1; y >= 0; y--)
            {
                for (int x = 0; x < herniPole.GetLength(0); x++)
                {
                    if (herniPole[x, y] == StavPolicka.Lod)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write(" # ");
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Cyan;
                        Console.Write("   ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.ResetColor();
        }
        public void VykreslitHlaseni(string hlaseni)
        {
            Console.WriteLine(hlaseni);
        }
    }
}
