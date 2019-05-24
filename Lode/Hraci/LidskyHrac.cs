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
            Rozhrani.SmazatObrazovku();
            Rozhrani.ZobrazitHlaseni("Hraje člověk");
            Console.CursorTop += 1;

            Rozhrani.ZobrazitHlaseni("Vlastní herní pole:");
            Console.CursorTop += 1;
            Console.CursorLeft = 0;
            Rozhrani.ZobrazitHerniPole(HerniPole);

            Console.CursorTop -= 2;
            Console.CursorLeft = 45;
            Rozhrani.ZobrazitHlaseni("Soupeřovo herní pole:");
            Console.CursorLeft = 45;
            Console.CursorTop += 1;
            Rozhrani.ZobrazitHerniPole(HerniPoleSoupere);

            Console.CursorTop += 11;
            Console.CursorLeft = 0;

            List<Souradnice> mozneTahy = new List<Souradnice>();

            for (int x = 0; x < HerniPoleSoupere.GetLength(0); x++)
                for (int y = 0; y < HerniPoleSoupere.GetLength(1); y++)
                    if (HerniPoleSoupere[x, y] == StavPolicka.Neznamo)
                        mozneTahy.Add(new Souradnice() { X = x, Y = y });

            Souradnice zvolenyTah = mozneTahy[_nahoda.Next(mozneTahy.Count)];
            Rozhrani.ZobrazitHlaseni("Zvolený tah: [" + zvolenyTah.X + ", " + zvolenyTah.Y + "]", true);
            return zvolenyTah;

            return mozneTahy[_nahoda.Next(mozneTahy.Count)];
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
