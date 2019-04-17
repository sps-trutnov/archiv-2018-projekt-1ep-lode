using System;
using System.Collections.Generic;
using System.Net;

namespace Lode
{
    class Program
    {
        static bool hrajeSeProtiAI()
        {
            Console.WriteLine("Chceš hrát proti počítači?");
            Console.Write("A/n");

            string odpoved = Console.ReadLine();

            return (odpoved == null || odpoved.ToUpper() == "A");
        }

        static IPAddress zjistitAdresuSoupere()
        {
            Console.WriteLine("Jakou IP adresu má soupeř?");

            byte prvni, druhy, treti, ctvrty;

            Console.Write("Zadej první oktet: ");
            prvni = Convert.ToByte(Console.ReadLine());
            Console.Write("Zadej druhý oktet: ");
            druhy = Convert.ToByte(Console.ReadLine());
            Console.Write("Zadej třetí oktet: ");
            treti = Convert.ToByte(Console.ReadLine());
            Console.Write("Zadej čtvrtý oktet: ");
            ctvrty = Convert.ToByte(Console.ReadLine());

            return new IPAddress(new byte[] { prvni, druhy, treti, ctvrty });
        }

        static void Main(string[] args)
        {
            Souradnice tah;
            StavPolicka vysledek;

            Hrac hrac = new LidskyHrac();

            if (hrajeSeProtiAI())
            {
                PocitacovyHrac protihrac = new PocitacovyHrac();

                hrac.StanovitAdresuSoupere(protihrac.VlastniPrijem.Address);
                protihrac.StanovitAdresuSoupere(hrac.VlastniPrijem.Address);

                protihrac.RozmistitLode();
                protihrac.OddelitDoSamostatnehoVlakna();
            }
            else
            {
                hrac.StanovitAdresuSoupere(zjistitAdresuSoupere());
            }

            hrac.RozmistitLode();

            if (hrac.VyhravaPrvniTah())
            {
                tah = hrac.RozhodnoutVlastniTah();
                vysledek = hrac.VykomunikovatVlastniTah(tah);
                hrac.ProvestVlastniTah(tah, vysledek);
            }

            while (!(hrac.JePorazenym() || hrac.JeVitezem() || hrac.NemuzeHrat()))
            {
                tah = hrac.ZjistitTahSoupere();
                vysledek = hrac.ProvestTahSoupere(tah);
                hrac.VykomunikovatTahSoupere(tah, vysledek);

                if (hrac.JePorazenym() || hrac.JeVitezem() || hrac.NemuzeHrat())
                    break;

                tah = hrac.RozhodnoutVlastniTah();
                vysledek = hrac.VykomunikovatVlastniTah(tah);
                hrac.ProvestVlastniTah(tah, vysledek);
            }

            if (hrac.JeVitezem())
            {
                Console.WriteLine("Vítězství!");
            }
            else if (hrac.JePorazenym())
            {
                Console.WriteLine("Porážka...");
            }
            else if (hrac.NemuzeHrat())
            {
                Console.WriteLine("Remíza.");
            }

            Console.CursorVisible = false;
            Console.ReadKey(true);
        }
    }
}
