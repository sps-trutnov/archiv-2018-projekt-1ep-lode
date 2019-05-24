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
        public TypAkce ZiskatAkci()
        {
            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Spacebar:
                        return TypAkce.Otoceni;
                    case ConsoleKey.DownArrow:
                        return TypAkce.PosunDolu;
                    case ConsoleKey.UpArrow:
                        return TypAkce.PosunNahoru;
                    case ConsoleKey.LeftArrow:
                        return TypAkce.PosunVlevo;
                    case ConsoleKey.RightArrow:
                        return TypAkce.PosunVpravo;
                    case ConsoleKey.Enter:
                        return TypAkce.Umisteni;
                }
            }
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

            for (int y = 0; y < herniPole.GetLength(1); y++)
            {
                for (int x = 0; x < herniPole.GetLength(0); x++)
                {
                    Console.CursorLeft = l + 3 * x;
                    Console.CursorTop = t + herniPole.GetLength(1) - 1 - y;

                    if (herniPole[x, y] == StavPolicka.Lod)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write(" # ");
                    }
                    else if (herniPole[x, y] == StavPolicka.Voda)
                    {
                        Console.BackgroundColor = ConsoleColor.Cyan;
                        Console.Write("   ");
                    }
                }
            }

            Console.CursorLeft = l;
            Console.CursorTop = t;
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
        public void ZobrazitLod(Lod lod, Souradnice rozsahZobrazeni, StavPolicka zpusobZobrazeni)
        {
            int l = Console.CursorLeft;
            int t = Console.CursorTop;

            for (int y = 0; y < rozsahZobrazeni.Y; y++)
            {
                for (int x = 0; x < rozsahZobrazeni.X; x++)
                {
                    Console.CursorLeft = l + 3 * x;
                    Console.CursorTop = t + rozsahZobrazeni.Y - 1 - y;

                    if (lod.ZasahujeNaPolicko(x, y))
                    {
                        switch (zpusobZobrazeni)
                        {
                            case StavPolicka.Lod:
                                Console.BackgroundColor = ConsoleColor.Gray;
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.Write(" # ");
                                break;
                            case StavPolicka.Potopena:
                                Console.BackgroundColor = ConsoleColor.Magenta;
                                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                Console.Write(" X ");
                                Console.CursorLeft -= " X ".Length;
                                break;
                        }
                    }
                }
            }

            Console.CursorLeft = l;
            Console.CursorTop = t;
            Console.ResetColor();
        }
    }
}
