namespace Lode
{
    interface IRozhrani
    {
        void SmazatObrazovku();
        bool ZiskatOdpovedAnoNe(string otazka, string chyboveHlaseni, bool defaultniOdpoved);
        byte ZiskatOktet(string vyzva, string chyboveHlaseni);
        string ZiskatText(string vyzva, bool ukoncitRadek);
        void ZobrazitHerniPole(StavPolicka[,] herniPole);
        void ZobrazitHlaseni(string hlaseni, bool potvrditPrecteni = true);
        void ZobrazitLod(Lod lod, Souradnice rozsahZobrazeni, StavPolicka zpusobZobrazeni);
        TypAkce ZiskatAkci();
    }
}
