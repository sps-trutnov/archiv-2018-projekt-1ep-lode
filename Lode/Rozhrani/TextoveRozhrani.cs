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
        public string ZiskatText(string vyzva, bool ukoncitRadek)
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
            throw new NotImplementedException();
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
