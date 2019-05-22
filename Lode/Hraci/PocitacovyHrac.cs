using System;
using System.Collections.Generic;
using System.Net;

namespace Lode
{
    class PocitacovyHrac : ObecnyHrac
    {
        #region Atributy
        readonly private static string[] _jmenaAI = new string[] { "Andy", "Boris", "Dora", "Keira", "Victor" };
        #endregion

        #region Vlastnosti
        public string Jmeno { get; private set; }
        #endregion

        #region Konstruktory
        public PocitacovyHrac() : base(new IPAddress(new byte[] { 127, 0, 0, 1 }))
        {
            Jmeno = _jmenaAI[new Random().Next(_jmenaAI.Length)];
        }
        #endregion

        #region Verejne metody
        public override Souradnice RozhodnoutVlastniTah()
        {
            throw new NotImplementedException();
        }
        public override void RozmistitLode()
        {
            List<Lod> umisteneLode;
            NatoceniLode natoceni;

            int x, y, iterace;

            for (x = 0; x < HerniPole.GetLength(0); x++)
                for (y = 0; y < HerniPole.GetLength(1); y++)
                    HerniPole[x, y] = StavPolicka.Voda;

            do
            {
                umisteneLode = new List<Lod>();

                foreach (Lod umistovanaLod in Lode)
                {
                    iterace = 0;

                    do
                    {
                        x = _nahoda.Next(0, HerniPole.GetLength(0));
                        y = _nahoda.Next(0, HerniPole.GetLength(1));
                        natoceni = (NatoceniLode)_nahoda.Next(Enum.GetValues(typeof(NatoceniLode)).Length);

                        umistovanaLod.Umistit(new Souradnice() { X = x, Y = y }, natoceni);

                        if (++iterace > 100)
                            break;

                    } while (!umistovanaLod.JeUmistenaSpravne(new Souradnice() { X = HerniPole.GetLength(0), Y = HerniPole.GetLength(1) }, umisteneLode));

                    if (iterace > 100)
                        break;
                    else
                        umisteneLode.Add(umistovanaLod);
                }
            } while (umisteneLode.Count != Lode.Count);

            for (x = 0; x < HerniPole.GetLength(0); x++)
                for (y = 0; y < HerniPole.GetLength(1); y++)
                    foreach (Lod lod in Lode)
                        if (lod.ZasahujeNaPolicko(x, y))
                            HerniPole[x, y] = StavPolicka.Lod;
        }
        #endregion

        #region Soukrome metody
        #endregion
    }
}
