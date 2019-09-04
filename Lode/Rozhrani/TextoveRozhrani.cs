using System;

namespace Lode
{
    class TextoveRozhrani : IRozhrani
    {
        private Souradnice ReferencePoslednihoZobrazenehoHernihoPole { get; set; } = new Souradnice();

        public Meňuňu Menu { get; private set; }

        public TextoveRozhrani()

        {
            Menu = new Meňuňu();
            Console.WindowHeight = 45;
            Console.WindowWidth = 120;
        }

        public void PockatNaUkonceniHry()
        {
            throw new NotImplementedException();
        }
        public void SmazatObrazovku()
        {
            throw new NotImplementedException();
        }

        public TypAkce ZiskatAkci()
        {
            throw new NotImplementedException();
        }
        public bool ZiskatOdpovedAnoNe(string otazka, string chyboveHlaseni, bool defaultniOdpoved)
        {
            throw new NotImplementedException();
        }
        public byte ZiskatOktet(string vyzva, string chyboveHlaseni)
        {
            throw new NotImplementedException();
        }

        public void ZobrazitHerniPole(StavPolicka[,] herniPole)
        {
            throw new NotImplementedException();
        }
        public void ZobrazitHlaseni(string hlaseni, bool potvrditPrecteni = false)
        {
            throw new NotImplementedException();
        }
        public void ZobrazitLod(Lod lod, Souradnice rozsahZobrazeni, StavPolicka zpusobZobrazeni)
        {
            throw new NotImplementedException();
        }
        public void ZobrazitNadpis(string nadpis)
        {
            throw new NotImplementedException();
        }
        public void ZobrazitStavHry(StavPolicka[,] vlastniHerniPole, StavPolicka[,] souperovoHerniPole)
        {
            int sirkaPole = vlastniHerniPole.GetLength(0);
            int vyskaPole = vlastniHerniPole.GetLength(1);

            for (int y = 0; y < vyskaPole; y++)
            {
                for (int x = 0; x < sirkaPole; x++)
                {
                    StavPolicka policko = vlastniHerniPole[x, y];

                    if (policko == StavPolicka.Voda)
                    {
                        Console.Write("~");
                    }
                    else if (policko == StavPolicka.Lod)
                    {
                        Console.Write("#");
                    }
                    else if (policko == StavPolicka.Zasah)
                    {
                        Console.Write("X");
                    }
                    else if (policko == StavPolicka.Potopena)
                    {
                        Console.Write("0");
                    }
                    else if (policko == StavPolicka.Neznamo)
                    {
                        Console.Write(":");
                    }
                    else if (policko == StavPolicka.Mimo)
                    {
                        Console.Write("~");
                    }
                    Console.WriteLine();
                    //Udělej ze sebe řádek prosím :)
                }
            }
        }
        public void ZobrazitZamerovac(Souradnice souradnice, Souradnice rozsahZobrazeni, StavPolicka zpusobZobrazeni)
        {
            throw new NotImplementedException();
        }

        public void ZobrazitMenu(Hra ktereHry)
        {
            Menu.UvodniMenu(ktereHry);
        }
    }
}
