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
            int i = 0;

            foreach (Souradnice p in policka)
            {
                foreach (Souradnice o in policka)
                    if (o.X == p.X && o.Y == p.Y)
                    {
                        i = i + 1;


                    }
            }

            if (i > policka.Count)
            {
                return true;
            }


            return false;
        }

        public override void RozmistitLode()
        {



            Random nahoda = new Random((int)DateTime.Now.Ticks);

            List<Souradnice> polickaVsechLodi;

            int jeti = 1;


            polickaVsechLodi = new List<Souradnice>();

            foreach (Lod l in Lode)
            {

                List<Souradnice> testovanaPolicka = new List<Souradnice>();

                do
                {
                    testovanaPolicka.Clear();
                    testovanaPolicka.AddRange(polickaVsechLodi);

                    int x = nahoda.Next(10);
                    int y = nahoda.Next(10);

                    NatoceniLode natoceni = (NatoceniLode)nahoda.Next(4);

                    l.Premistit(new Souradnice(x, y), natoceni);

                    foreach (Souradnice p in l.Policka)
                        testovanaPolicka.Add(p);


                    //Console.WriteLine(testovanaPolicka.Count + " policek...");
                } while (ObsahujeDuplicity(testovanaPolicka));

                foreach (Souradnice p in l.Policka)
                    polickaVsechLodi.Add(p);

                Console.WriteLine("Loď umístěna!");
                //Console.ReadLine();
            }

            Console.WriteLine("Úspěch!");

            //foreach (Souradnice p in polickaVsechLodi)
            //    Console.WriteLine(p.X + " " + p.Y);

            // umistit lode do herniho pole
            // TODO


            Console.WriteLine("Hotovo");
            Console.ReadLine();
        }
    }
}
