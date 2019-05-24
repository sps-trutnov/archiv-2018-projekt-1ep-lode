using System;
using System.Collections.Generic;
using System.Net;

namespace Lode
{
    class LidskyHrac : ObecnyHrac
    {
        public LidskyHrac(IPAddress ipAdresa) : base(ipAdresa)
        {

        }

        public override Souradnice RozhodnoutVlastniTah()
        {
            throw new NotImplementedException();
        }
        public override void RozmistitLode()
        {
            List<Lod> rozmisteneLode = new List<Lod>();

            NaplnitHerniPoleVodou();

            foreach (Lod lod in Lode)
            {
                lod.Premistit(HerniPole.GetLength(0) / 2, HerniPole.GetLength(1) / 2, NatoceniLode.Stupnu0);

                while (!rozmisteneLode.Contains(lod))
                {
                    Rozhrani.SmazatObrazovku();
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
        }
    }
}
