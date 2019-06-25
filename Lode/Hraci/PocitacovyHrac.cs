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
        public override void RozmistitLode()
        {
            this.HerniPole = new StavPolicka[10, 10];

            Random x = new Random();
            int souradniceX = x.Next(1, 10);
            System.Threading.Thread.Sleep(1000);
            Random y = new Random();
            int souradniceY = y.Next(1, 10);

            TypLode MojeLod = TypLode.Torpedovka;
            NatoceniLode Nulovy_Stupen = NatoceniLode.Stupnu0;
            Souradnice centrum = new Souradnice() { X = souradniceX, Y = souradniceY };

            if ((MojeLod == TypLode.Torpedovka) && (Nulovy_Stupen == NatoceniLode.Stupnu0))
            {
                Souradnice vlevoOdCentra = new Souradnice() { X = souradniceX - 1, Y = souradniceY };
                Souradnice nahoreOdCentra = new Souradnice() { X = souradniceX, Y = souradniceY + 1 };
                Souradnice vpravoOdCentra = new Souradnice() { X = souradniceX + 1, Y = souradniceY };

                Console.WriteLine(vlevoOdCentra);
                Console.WriteLine(nahoreOdCentra);
                Console.WriteLine(vpravoOdCentra);



            }
            Console.ReadLine();
        }
    }
}
