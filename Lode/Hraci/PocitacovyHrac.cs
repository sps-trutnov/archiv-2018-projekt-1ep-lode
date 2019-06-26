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
            Random nahoda = new Random();

            int souradniceX = nahoda.Next(0, HerniPoleSoupere.GetLength(0));
            int souradniceY = nahoda.Next(0, HerniPoleSoupere.GetLength(1));

            while (HerniPoleSoupere[souradniceX, souradniceY] != StavPolicka.Neznamo)
            {
                //

                if (HerniPoleSoupere[souradniceX, souradniceY] == StavPolicka.Zasah)
                {
                    int moznostiSmeru = nahoda.Next(0, 4);

                    if (moznostiSmeru == 0)
                    {
                        souradniceY = souradniceY + 1;

                        if (HerniPoleSoupere[souradniceX, souradniceY] == StavPolicka.Neznamo)
                            return new Souradnice() { X = souradniceX, Y = souradniceY };
                    }
                    else if (moznostiSmeru == 1)
                    {
                        souradniceX = souradniceX + 1;

                        if (HerniPoleSoupere[souradniceX, souradniceY] == StavPolicka.Neznamo)
                            return new Souradnice() { X = souradniceX, Y = souradniceY };
                    }
                    else if (moznostiSmeru == 2)
                    {
                        souradniceY = souradniceY - 1;

                        if (HerniPoleSoupere[souradniceX, souradniceY] == StavPolicka.Neznamo)
                            return new Souradnice() { X = souradniceX, Y = souradniceY };
                    }
                    else if (moznostiSmeru == 3)
                    {
                        souradniceX = souradniceX - 1;

                        if (HerniPoleSoupere[souradniceX, souradniceY] == StavPolicka.Neznamo)
                            return new Souradnice() { X = souradniceX, Y = souradniceY };
                    }
                }

                souradniceX = nahoda.Next(0, HerniPoleSoupere.GetLength(0));
                souradniceY = nahoda.Next(0, HerniPoleSoupere.GetLength(1));
            }

            return new Souradnice() { X = souradniceX, Y = souradniceY };


        }
        private bool ObsahujeDuplicity(List<Souradnice> policka)
        {
            // TODO
        }

        public override void RozmistitLode()
        {
            Random nahoda = new Random((int)DateTime.Now.Ticks);

            List<Souradnice> polickaVsechLodi;

            do
            {
                polickaVsechLodi = new List<Souradnice>();

                foreach (Lod l in Lode)
                {
                    int x = nahoda.Next(10);
                    int y = nahoda.Next(10);

                    NatoceniLode natoceni = (NatoceniLode)nahoda.Next(4);

                    l.Premistit(new Souradnice(x, y), natoceni);

                    foreach (Souradnice p in l.Policka)
                        polickaVsechLodi.Add(p);
                }

            } while (ObsahujeDuplicity(polickaVsechLodi));

            // umistit lode do herniho pole
            // TODO

            Console.ReadLine();
        }
    }
}
