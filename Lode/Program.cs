using System;
using System.Collections.Generic;
using System.Net;

namespace Lode
{
    class Program
    {
        static bool HrajeSeProtiAI()
        {
            Console.WriteLine("Chceš hrát proti počítači?");
            Console.Write("a/N");

            string odpoved = Console.ReadLine();

            return (odpoved == null || odpoved.ToUpper() == "N");
        }

        static IPAddress ZjistitAdresuSoupere()
        {
            Console.WriteLine("Soupeři nahlaš adresu: " + Dns.GetHostEntry(Dns.GetHostName()).AddressList[0]);
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

            Console.Write("Zadali jste adresu: ");
            Console.WriteLine(prvni + "." + druhy + "." + treti + "." + ctvrty);

            Console.WriteLine();
            Console.WriteLine("Pokračujte stiskem klávesy...");
            Console.ReadKey(true);

            return new IPAddress(new byte[] { prvni, druhy, treti, ctvrty });
        }

        static void OhlasitVysledekHry(Hrac hrac)
        {
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
        }

        static void Main(string[] args)
        {
            Souradnice tah;
            StavPolicka vysledek;

            Hrac hrac = new LidskyHrac();

            if (HrajeSeProtiAI())
            {
                PocitacovyHrac protihrac = new PocitacovyHrac();

                hrac.StanovitAdresuSoupere(protihrac.IpPrijem.Address);
                protihrac.StanovitAdresuSoupere(hrac.IpPrijem.Address);

                protihrac.RozmistitLode();
                protihrac.OddelitDoSamostatnehoVlakna();
            }
            else
            {
                hrac.StanovitAdresuSoupere(ZjistitAdresuSoupere());
            }

            hrac.RozmistitLode();

            if (hrac.MaPravoPrvnihoTahu())
            {
                tah = hrac.RozhodnoutVlastniTah();

                vysledek = hrac.ZjistitVysledekTahuOdProtihrace(tah);
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

                vysledek = hrac.ZjistitVysledekTahuOdProtihrace(tah);
                hrac.ProvestVlastniTah(tah, vysledek);
            }

            OhlasitVysledekHry(hrac);

            Console.CursorVisible = false;
            Console.ReadKey(true);
        }
    }
}
