using System;
using System.Collections.Generic;
using System.Net;

namespace Lode
{
    class PocitacovyHrac : ObecnyHrac
    {
        readonly private static string[] _jmenaAI = new string[] { "Andy", "Boris", "Dora", "Keira", "Victor" };

        public string Jmeno { get; private set; }

        public PocitacovyHrac() : base(new IPAddress(new byte[] { 127, 0, 0, 1 }))
        {
            Jmeno = _jmenaAI[new Random().Next(_jmenaAI.Length)];
        }

        public override Souradnice RozhodnoutVlastniTah()
        {
            Rozhrani.SmazatObrazovku();
            Rozhrani.ZobrazitHlaseni("Hraje počítač");
            Console.CursorTop += 1;

            Rozhrani.ZobrazitHlaseni("Vlastní herní pole:");
            Console.CursorTop += 1;
            Console.CursorLeft = 0;
            Rozhrani.ZobrazitHerniPole(HerniPole);

            Console.CursorTop -= 2;
            Console.CursorLeft = 45;
            Rozhrani.ZobrazitHlaseni("Soupeřovo herní pole:");
            Console.CursorTop += 1;
            Console.CursorLeft = 45;
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
            List<Lod> umisteneLode;

            NatoceniLode natoceni;
            int x, y;

            int iterace;

            NaplnitHerniPoleHodnotou(StavPolicka.Voda);

            do
            {
                umisteneLode = new List<Lod>();

                foreach (Lod lod in Lode)
                {
                    iterace = 0;

                    do
                    {
                        x = _nahoda.Next(0, HerniPole.GetLength(0));
                        y = _nahoda.Next(0, HerniPole.GetLength(1));
                        natoceni = (NatoceniLode)_nahoda.Next(Enum.GetValues(typeof(NatoceniLode)).Length);

                        lod.Premistit(new Souradnice() { X = x, Y = y }, natoceni);

                        if (++iterace > 100)
                            break;

                    } while (!lod.JeUmistenaSpravne(new Souradnice() { X = HerniPole.GetLength(0), Y = HerniPole.GetLength(1) }, umisteneLode));

                    if (iterace > 100)
                        break;
                    else
                        umisteneLode.Add(lod);
                }
            } while (umisteneLode.Count != Lode.Count);

            UmistitLodeDoHernihoPole();
        }
    }
}
