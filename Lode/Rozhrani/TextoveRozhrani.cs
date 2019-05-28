using System;

namespace Lode
{
    class TextoveRozhrani : IRozhrani
    {
        private Souradnice ReferencePoslednihoZobrazenehoHernihoPole { get; set; } = new Souradnice();

        public void SmazatObrazovku()
        {
            Console.Clear();
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
            int l = ReferencePoslednihoZobrazenehoHernihoPole.X = Console.CursorLeft;
            int t = ReferencePoslednihoZobrazenehoHernihoPole.Y = Console.CursorTop;

            for (int y = 0; y < herniPole.GetLength(1); y++)
            {
                for (int x = 0; x < herniPole.GetLength(0); x++)
                {
                    Console.CursorLeft = l + 3 * x;
                    Console.CursorTop = t + herniPole.GetLength(1) - 1 - y;

                    switch (herniPole[x, y])
                    {
                        case StavPolicka.Lod:
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write(" # ");
                            break;
                        case StavPolicka.Zasah:
                            Console.BackgroundColor = ConsoleColor.Magenta;
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.Write(" x ");
                            Console.CursorLeft -= " x ".Length;
                            break;
                        case StavPolicka.Potopena:
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write(" X ");
                            Console.CursorLeft -= " X ".Length;
                            break;
                        case StavPolicka.Voda:
                            Console.BackgroundColor = ConsoleColor.Cyan;
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.Write("   ");
                            break;
                        case StavPolicka.Mimo:
                            Console.BackgroundColor = ConsoleColor.Cyan;
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.Write(" . ");
                            break;
                        case StavPolicka.Neznamo:
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write(" ? ");
                            break;
                    }
                }
            }

            Console.CursorLeft = l;
            Console.CursorTop = t;
            Console.ResetColor();
        }
        public void ZobrazitHlaseni(string hlaseni, bool potvrditPrecteni = false)
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
                            case StavPolicka.Zasah:
                                Console.BackgroundColor = ConsoleColor.Magenta;
                                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                Console.Write(" x ");
                                Console.CursorLeft -= " x ".Length;
                                break;
                            case StavPolicka.Potopena:
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.ForegroundColor = ConsoleColor.DarkRed;
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
        public void ZobrazitStavHry(StavPolicka[,] vlastniHerniPole, StavPolicka[,] souperovoHerniPole)
        {
            ZobrazitHlaseni("Vlastní herní pole:");
            Console.CursorTop += 1;
            Console.CursorLeft = 0;
            ZobrazitHerniPole(vlastniHerniPole);

            Console.CursorTop -= 2;
            Console.CursorLeft = 45;
            ZobrazitHlaseni("Soupeřovo herní pole:");
            Console.CursorLeft = 45;
            Console.CursorTop += 1;
            ZobrazitHerniPole(souperovoHerniPole);

            Console.CursorTop += 11;
            Console.CursorLeft = 0;
        }
        public void ZobrazitZamerovac(Souradnice souradnice, Souradnice rozsahZobrazeni, StavPolicka zpusobZobrazeni)
        {
            int l = Console.CursorLeft;
            int t = Console.CursorTop;

            Console.CursorLeft = ReferencePoslednihoZobrazenehoHernihoPole.X + souradnice.X * 3;
            Console.CursorTop = ReferencePoslednihoZobrazenehoHernihoPole.Y + rozsahZobrazeni.Y - 1 - souradnice.Y;

            switch (zpusobZobrazeni)
            {
                case StavPolicka.StrelbaPovolena:
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write(" X ");
                    break;
                case StavPolicka.StrelbaZakazana:
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write(" X ");
                    break;
            }

            Console.CursorLeft = l;
            Console.CursorTop = t;
            Console.ResetColor();
        }
    }
}
