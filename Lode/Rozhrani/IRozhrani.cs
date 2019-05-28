namespace Lode
{
    interface IRozhrani
    {
        void SmazatObrazovku();
        TypAkce ZiskatAkci();
        bool ZiskatOdpovedAnoNe(string otazka, string chyboveHlaseni, bool defaultniOdpoved);
        byte ZiskatOktet(string vyzva, string chyboveHlaseni);
        string ZiskatText(string vyzva, bool ukoncitRadek);
        void ZobrazitHerniPole(StavPolicka[,] herniPole);
        void ZobrazitHlaseni(string hlaseni, bool potvrditPrecteni = false);
        void ZobrazitLod(Lod lod, Souradnice rozsahZobrazeni, StavPolicka zpusobZobrazeni);
        void ZobrazitStavHry(StavPolicka[,] vlastniHerniPole, StavPolicka[,] souperovoHerniPole);
        void ZobrazitZamerovac(Souradnice souradnice, Souradnice rozsahZobrazeni, StavPolicka zpusobZobrazeni);
    }
}
