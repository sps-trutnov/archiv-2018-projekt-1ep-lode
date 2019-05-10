using System;
using System.Net;

namespace Lode
{
    class Hra
    {
        IPAddress MistniIP { get; set; }
        Hrac Hrac { get; set; }

        public Hra()
        {
            foreach (IPAddress adr in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                if (adr.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    MistniIP = adr;
                    break;
                }
            }

            Hrac = new LidskyHrac(MistniIP);
        }

        bool HrajeSeProtiAI()
        {
            Console.CursorVisible = false;
            Console.Write("Chceš hrát proti počítači?");
            Console.Write(" (a / N)");

            string odpoved = Console.ReadLine();
            Console.CursorVisible = true;

            Console.Clear();

            return odpoved == null || odpoved.ToUpper() == "N";
        }

        void OznamitMistniAdresu()
        {
            Console.WriteLine("Nahlaš soupeři svoji adresu: " + MistniIP);
            Console.WriteLine();
        }

        IPAddress ZjistitAdresuSoupere()
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

            Console.WriteLine();
            Console.Write("Zadal jsi adresu: ");
            Console.WriteLine(prvni + "." + druhy + "." + treti + "." + ctvrty);

            Console.WriteLine();
            Console.WriteLine("Pokračuj stiskem klávesy...");

            Console.CursorVisible = false;
            Console.ReadKey(true);
            Console.CursorVisible = true;

            return new IPAddress(new byte[] { prvni, druhy, treti, ctvrty });
        }

        bool HraKonci()
        {
            return Hrac.JePorazenym() || Hrac.JeVitezem() || Hrac.NemuzeProvestDalsiTah();
        }

        void OhlasitVysledekHry()
        {
            if (Hrac.JeVitezem())
            {
                Console.WriteLine("Vítězství!");
            }
            else if (Hrac.JePorazenym())
            {
                Console.WriteLine("Porážka...");
            }
            else if (Hrac.NemuzeProvestDalsiTah())
            {
                Console.WriteLine("Remíza.");
            }
        }

        public void SpustitHru()
        {
            if (HrajeSeProtiAI())
            {
                throw new NotImplementedException("Tato část dosud není vyřešena.");

                /*
                PocitacovyHrac protihrac = new PocitacovyHrac();

                Hrac.StanovitAdresuSoupere(protihrac.IpPrijem.Address);
                protihrac.StanovitAdresuSoupere(Hrac.IpPrijem.Address);

                protihrac.RozmistitLode();
                protihrac.OddelitDoSamostatnehoVlakna();
                */
            }
            else
            {
                OznamitMistniAdresu();

                Hrac.NastavitAdresuSoupere(this.ZjistitAdresuSoupere());
            }

            Hrac.RozmistitLode();

            if (Hrac.MaPravoPrvnihoTahu())
            {
                Souradnice tah;
                StavPolicka vysledek;

                tah = Hrac.RozhodnoutVlastniTah();
                vysledek = Hrac.ZjistitVysledekTahuOdProtihrace(tah);

                Hrac.ProvestVlastniTah(tah, vysledek);
            }

            while (!HraKonci())
            {
                Souradnice tah;
                StavPolicka vysledek;

                tah = Hrac.ZjistitTahSoupere();

                vysledek = Hrac.ProvestTahSoupere(tah);
                Hrac.VykomunikovatTahSoupere(tah, vysledek);

                if (Hrac.JePorazenym() || Hrac.JeVitezem() || Hrac.NemuzeProvestDalsiTah())
                    break;

                tah = Hrac.RozhodnoutVlastniTah();

                vysledek = Hrac.ZjistitVysledekTahuOdProtihrace(tah);
                Hrac.ProvestVlastniTah(tah, vysledek);
            }

            this.OhlasitVysledekHry();

            Console.CursorVisible = false;
            Console.ReadKey(true);
        }
    }
}
