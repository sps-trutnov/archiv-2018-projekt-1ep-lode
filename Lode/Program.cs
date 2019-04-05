using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Lode
{
    class Program
    {
        // popisuje mozne stavy policka na herni plose
        enum StavPolicka
        {
            Voda, Lod, Mimo, Zasah, Potopena
        }

        // popisuje dvourozmernou souradnici
        struct Souradnice
        {
            public int x;
            public int y;
        }

        // popisuje mozne typy lodi
        enum TypLode
        {
            Clun, Torpedovka, Kriznik, Letadlovka
        }

        // popisuje kazdou lod
        struct Lod
        {
            public Souradnice souradnice;
            public List<Souradnice> policka;
        }

        // popisuje mozne typy hracu
        enum TypHrace
        {
            Clovek, Pocitac
        }

        // popisuje parametry hrace
        struct Hrac
        {
            public TypHrace typ;

            public IPAddress ipAdresa;
            public short port;

            public string jmeno;
            public uint skore;

            public List<Lod> lode;
            public StavPolicka[,] stavHernihoPole;
        }

        // jmena pocitacovych protivniku
        static string[] jmenaAI = new string[] { "Andy", "Boris", "Dora", "Keira", "Victor" };

        // generator nahody
        static Random nahoda = new Random();

        // definice hrace
        static Hrac definovatHrace()
        {
            Hrac hrac;

            hrac.typ = TypHrace.Clovek;

            hrac.ipAdresa = zjistitIPAdresuHrace();
            hrac.port = (short)nahoda.Next(1024, short.MaxValue);

            hrac.jmeno = ziskatJmenoHrace();
            hrac.skore = 0;

            hrac.lode = new List<Lod>();
            hrac.stavHernihoPole = new StavPolicka[10, 10];

            return hrac;
        }

        // definice protihrace
        static Hrac definovatProtihrace()
        {
            Hrac protihrac;

            if (zjistitProtiKomuSeHraje() == TypHrace.Pocitac)
            {
                protihrac.typ = TypHrace.Pocitac;

                protihrac.ipAdresa = new IPAddress(new byte[] { 127, 0, 0, 1 });
                protihrac.port = (short)nahoda.Next(1024, short.MaxValue);

                protihrac.jmeno = jmenaAI[nahoda.Next(jmenaAI.Length)];
                protihrac.skore = 0;

                protihrac.lode = new List<Lod>();
                protihrac.stavHernihoPole = new StavPolicka[10, 10];
            }
            else
            {
                protihrac.typ = TypHrace.Clovek;

                protihrac.ipAdresa = zjistitAdresuProtihrace();
                protihrac.port = zjistitPortProtihrace();

                protihrac.jmeno = zjistitJmenoProtihrace();
                protihrac.skore = zjistitSkoreProtihrace();

                protihrac.lode = zjistitStavLodiProtihrace();
                protihrac.stavHernihoPole = zjistitStavHernihoPoleProtihrace();
            }

            return protihrac;
        }

        // VSTUPNI BOD PROGRAMU
        static void Main(string[] args)
        {
            Hrac hrac = definovatHrace();
            Hrac protihrac = definovatProtihrace();

            hrac.lode = rozmistitLodeHrace(hrac.lode, hrac.stavHernihoPole);
            hrac.stavHernihoPole = aktualizovatStavHernihoPole(hrac.lode, hrac.stavHernihoPole);

            protihrac.lode = vymenitSiNavzajemLode(hrac.lode);
            protihrac.stavHernihoPole = vymenitSiNavzajemStavHernihoPole(hrac.stavHernihoPole);

            Console.CursorVisible = false;
            Console.ReadKey(true);
        }

        private static StavPolicka[,] vymenitSiNavzajemStavHernihoPole(StavPolicka[,] stavHernihoPole)
        {
            throw new NotImplementedException();
        }

        private static List<Lod> vymenitSiNavzajemLode(List<Lod> lode)
        {
            throw new NotImplementedException();
        }

        private static StavPolicka[,] aktualizovatStavHernihoPole(List<Lod> lode, StavPolicka[,] stavHernihoPole)
        {
            throw new NotImplementedException();
        }

        private static List<Lod> rozmistitLodeHrace(List<Lod> lode, StavPolicka[,] stavHernihoPole)
        {
            throw new NotImplementedException();
        }

        private static List<Lod> zjistitStavLodiProtihrace()
        {
            throw new NotImplementedException();
        }

        private static StavPolicka[,] zjistitStavHernihoPoleProtihrace()
        {
            throw new NotImplementedException();
        }

        private static short zjistitPortProtihrace()
        {
            throw new NotImplementedException();
        }

        private static IPAddress zjistitIPAdresuHrace()
        {
            throw new NotImplementedException();
        }

        private static uint zjistitSkoreProtihrace()
        {
            throw new NotImplementedException();
        }

        private static string zjistitJmenoProtihrace()
        {
            throw new NotImplementedException();
        }

        private static IPAddress zjistitAdresuProtihrace()
        {
            throw new NotImplementedException();
        }

        private static TypHrace zjistitProtiKomuSeHraje()
        {
            throw new NotImplementedException();
        }

        private static string ziskatJmenoHrace()
        {
            throw new NotImplementedException();
        }
    }
}
