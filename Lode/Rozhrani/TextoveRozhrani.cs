using System;

namespace Lode
{
    class TextoveRozhrani : IRozhrani
    {
        public void SmazatObrazovku()
        {
            Console.Clear();
        }
        public bool ZiskatOdpovedAnoNe(string otazka, string chyboveHlaseni, bool defaultniOdpoved)
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
        public byte ZiskatOktet(string vyzva, string chyboveHlaseni)
        {
            byte? ziskanaData = null;
            bool dataBylaZiskana = false;

            do
            {
                Console.Write(vyzva + " ");

                try
                {
                    ziskanaData = Convert.ToByte(Console.ReadLine());
                    dataBylaZiskana = true;
                }
                catch
                {
                    Console.WriteLine(chyboveHlaseni);
                }
            } while (!dataBylaZiskana);

            return (byte)ziskanaData;
        }
        public string ZiskatText(string vyzva, bool ukoncitRadek)
        {
            Console.Write(vyzva);

            if (ukoncitRadek)
                Console.Write("\n");
            else
                Console.Write(" ");

            return Console.ReadLine();
        }
        public void ZobrazitHerniPole(StavPolicka[,] herniPole)
        {
            int l = Console.CursorLeft;
            int t = Console.CursorTop;

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
                Console.CursorLeft = l;
                Console.CursorTop = ++t;
            }
            Console.CursorLeft = l;
            Console.CursorTop = ++t;

            Console.ResetColor();
        }
        public void ZobrazitHlaseni(string hlaseni, bool potvrditPrecteni)
        {
            Console.WriteLine(hlaseni);

            if (potvrditPrecteni)
            {
                Console.CursorVisible = false;
                Console.ReadKey(true);
                Console.CursorVisible = true;
            }
        }
    }
}
