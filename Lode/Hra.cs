using System;
using System.Net;

namespace Lode
{
    class Hra
    {
        #region Atributy
        #endregion

        #region Vlastnosti
        IPAddress MistniIP { get; set; }
        ObecnyHrac Hrac { get; set; }
        ObecnyHrac Souper { get; set; }
        #endregion

        #region Konstruktory
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
        #endregion

        #region Verejne metody
        public void SpustitHru()
        {
            if (HrajeSeProtiAI())
            {
                Souper = new PocitacovyHrac();

                Hrac.NastavitAdresuSoupere(Souper.Prijimac.Address);
                Souper.NastavitAdresuSoupere(Hrac.Prijimac.Address);

                Souper.RozmistitLode();
                ((PocitacovyHrac)Souper).OddelitDoSamostatnehoVlakna();
            }
            else
            {
                OznamitMistniAdresu();

                Hrac.NastavitAdresuSoupere(ZjistitAdresuSoupere());
            }

            Hrac.RozmistitLode();

            if (Hrac.MaPravoPrvnihoTahu())
            {
                Souradnice tah;
                StavPolicka vysledek;

                tah = Hrac.RozhodnoutVlastniTah();
                vysledek = Hrac.ZjistitVysledekTahuOdSoupere(tah);

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

                vysledek = Hrac.ZjistitVysledekTahuOdSoupere(tah);
                Hrac.ProvestVlastniTah(tah, vysledek);
            }

            OhlasitVysledekHry();

            Console.CursorVisible = false;
            Console.ReadKey(true);
        }
        #endregion

        #region Soukrome metody
        private bool HrajeSeProtiAI()
        {
            Console.CursorVisible = false;
            Console.Write("Chceš hrát proti počítači?");
            Console.Write(" (a / N)");

            string odpoved = Console.ReadLine();
            Console.CursorVisible = true;

            Console.Clear();

            return odpoved != null && odpoved.ToUpper() == "A";
        }
        private bool HraKonci()
        {
            return Hrac.JePorazenym() || Hrac.JeVitezem() || Hrac.NemuzeProvestDalsiTah();
        }
        private void OhlasitVysledekHry()
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
        private void OznamitMistniAdresu()
        {
            Console.WriteLine("Nahlaš soupeři svoji adresu: " + MistniIP);
            Console.WriteLine();
        }
        private IPAddress ZjistitAdresuSoupere()
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
        #endregion
    }
}
