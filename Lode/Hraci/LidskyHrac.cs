using System.Collections.Generic;
using System.Net;

namespace Lode
{
    class LidskyHrac : ObecnyHrac
    {
        private Souradnice PoziceZamerovace { get; set; }

        public LidskyHrac(IPAddress ipAdresa) : base(ipAdresa)
        {

        }

        public override Souradnice RozhodnoutVlastniTah()
        {
            if (PoziceZamerovace == null)
                PoziceZamerovace = new Souradnice() { X = HerniPoleSoupere.GetLength(0) / 2, Y = HerniPoleSoupere.GetLength(1) / 2 };

            bool strelbaPotvrzena = false;

            do
            {
                Rozhrani.SmazatObrazovku();
                Rozhrani.ZobrazitNadpis("Potop nepřátelskou flotilu!");
                Rozhrani.ZobrazitHlaseni("\n(šipky - míření, Enter / mezerník - střelba)\n");

                Rozhrani.ZobrazitStavHry(HerniPole, HerniPoleSoupere);
                Rozhrani.ZobrazitZamerovac(PoziceZamerovace, new Souradnice() { X = HerniPoleSoupere.GetLength(0), Y = HerniPoleSoupere.GetLength(1) }, StavPolicka.StrelbaPovolena);

                switch (Rozhrani.ZiskatAkci())
                {
                    case TypAkce.PosunDolu:
                        if (PoziceZamerovace.Y - 1 >= 0)
                            PoziceZamerovace.Y -= 1;
                        break;
                    case TypAkce.PosunNahoru:
                        if (PoziceZamerovace.Y + 1 < HerniPoleSoupere.GetLength(1))
                            PoziceZamerovace.Y += 1;
                        break;
                    case TypAkce.PosunVlevo:
                        if (PoziceZamerovace.X - 1 >= 0)
                            PoziceZamerovace.X -= 1;
                        break;
                    case TypAkce.PosunVpravo:
                        if (PoziceZamerovace.X + 1 < HerniPoleSoupere.GetLength(0))
                            PoziceZamerovace.X += 1;
                        break;
                    case TypAkce.Umisteni:
                    case TypAkce.Otoceni:
                        if (HerniPoleSoupere[PoziceZamerovace.X, PoziceZamerovace.Y] == StavPolicka.Neznamo)
                            strelbaPotvrzena = true;
                        break;
                }
            } while (!strelbaPotvrzena);

            return PoziceZamerovace;
        }
        public override void RozmistitLode()
        {
            List<Lod> rozmisteneLode = new List<Lod>();

            NaplnitHerniPoleHodnotou(StavPolicka.Voda);

            foreach (Lod lod in Lode)
            {
                lod.Premistit(HerniPole.GetLength(0) / 2, HerniPole.GetLength(1) / 2, NatoceniLode.Stupnu0);

                while (!rozmisteneLode.Contains(lod))
                {
                    Rozhrani.SmazatObrazovku();
                    Rozhrani.ZobrazitNadpis("Rozmísti svou flotilu!");
                    Rozhrani.ZobrazitHlaseni("\n(šipky - posouvání, mezerník - otáčení, Enter - umístění)\n");

                    Rozhrani.ZobrazitHerniPole(HerniPole);

                    foreach (Lod rozmistenaLod in rozmisteneLode)
                        Rozhrani.ZobrazitLod(rozmistenaLod, new Souradnice() { X = HerniPole.GetLength(0), Y = HerniPole.GetLength(1) }, StavPolicka.Lod);

                    if (lod.JeUmistenaSpravne(new Souradnice() { X = HerniPole.GetLength(0), Y = HerniPole.GetLength(1) }, rozmisteneLode))
                        Rozhrani.ZobrazitLod(lod, new Souradnice() { X = HerniPole.GetLength(0), Y = HerniPole.GetLength(1) }, StavPolicka.Lod);
                    else
                        Rozhrani.ZobrazitLod(lod, new Souradnice() { X = HerniPole.GetLength(0), Y = HerniPole.GetLength(1) }, StavPolicka.Potopena);

                    switch (Rozhrani.ZiskatAkci())
                    {
                        case TypAkce.Otoceni:
                            lod.Otocit(NatoceniLode.Stupnu90);
                            break;
                        case TypAkce.PosunDolu:
                            lod.Posunout(0, -1, new Souradnice() { X = HerniPole.GetLength(0), Y = HerniPole.GetLength(1) });
                            break;
                        case TypAkce.PosunNahoru:
                            lod.Posunout(0, +1, new Souradnice() { X = HerniPole.GetLength(0), Y = HerniPole.GetLength(1) });
                            break;
                        case TypAkce.PosunVlevo:
                            lod.Posunout(-1, 0, new Souradnice() { X = HerniPole.GetLength(0), Y = HerniPole.GetLength(1) });
                            break;
                        case TypAkce.PosunVpravo:
                            lod.Posunout(+1, 0, new Souradnice() { X = HerniPole.GetLength(0), Y = HerniPole.GetLength(1) });
                            break;
                        case TypAkce.Umisteni:
                            if (lod.JeUmistenaSpravne(new Souradnice() { X = HerniPole.GetLength(0), Y = HerniPole.GetLength(1) }, rozmisteneLode))
                                rozmisteneLode.Add(lod);
                            break;
                    }
                }
            }

            UmistitLodeDoHernihoPole();
        }
    }
}
