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

        }

        public override Souradnice RozhodnoutVlastniTah()
        {

            Random x = new Random();
            int souradniceX = x.Next(0, HerniPoleSoupere.GetLength(0));
            System.Threading.Thread.Sleep(1000);
            Random y = new Random();
            int souradniceY = y.Next(0, HerniPoleSoupere.GetLength(1));

            while (HerniPoleSoupere[souradniceX,souradniceY] != StavPolicka.Neznamo)
            {
                souradniceX = x.Next(0, HerniPoleSoupere.GetLength(0));
                souradniceY = y.Next(0, HerniPoleSoupere.GetLength(1));
            }

            return new Souradnice() { X = souradniceX, Y = souradniceY };

        }
        public override void RozmistitLode()
        {
            throw new NotImplementedException();
        }
    }
}
