using System;
using System.Net;
using System.Threading;

namespace Lode
{
    class Hra
    {
        delegate void HerniAlgoritmus(object hrac);
        Thread VlaknoProAI { get; set; }

        #region Atributy
        #endregion

        #region Vlastnosti
        IPAddress MistniIP { get; set; }

        ObecnyHrac Hrac { get; set; }
        PocitacovyHrac PocitacovySouper { get; set; }

        Souradnice CilTahu { get; set; }
        StavPolicka VysledekTahu { get; set; }
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
            NastavitHrace();
            HratHru(Hrac);

            VyhlasitVysledky();
            VypnoutHru();
        }
        #endregion

        #region Soukrome metody
        private bool BudeSeHratProtiPocitaci()
        {
            Console.CursorVisible = false;
            Console.Write("Chceš hrát proti počítači?");
            Console.Write(" (a / N)");

            string odpoved = Console.ReadLine();
            Console.CursorVisible = true;

            Console.Clear();

            return odpoved != null && odpoved.ToUpper() == "A";
        }
        private bool HraSkoncila()
        {
            return Hrac.JePorazenym() || Hrac.JeVitezem() || Hrac.NemuzeProvestDalsiTah();
        }
        private void HratHru(object hrajiciHrac)
        {
            ObecnyHrac hrac = (ObecnyHrac)hrajiciHrac;

            hrac.NavazatSpojeniSeSouperem();
            hrac.RozmistitLode();

            if (hrac.MaPravoPrvnihoTahu())
            {
                CilTahu = hrac.RozhodnoutVlastniTah();
                VysledekTahu = hrac.ZjistitVysledekTahuOdSoupere(CilTahu);

                hrac.ProvestVlastniTah(CilTahu, VysledekTahu);
            }

            while (!HraSkoncila())
            {
                CilTahu = hrac.ZjistitTahSoupere();
                VysledekTahu = hrac.ProvestTahSoupere(CilTahu);

                hrac.OznamitVysledekTahuSouperi(VysledekTahu);

                if (HraSkoncila())
                    break;

                CilTahu = hrac.RozhodnoutVlastniTah();
                VysledekTahu = hrac.ZjistitVysledekTahuOdSoupere(CilTahu);

                hrac.ProvestVlastniTah(CilTahu, VysledekTahu);
            }
        }
        private void NastavitHrace()
        {
            if (BudeSeHratProtiPocitaci())
            {
                PocitacovySouper = new PocitacovyHrac();

                PocitacovySouper.NastavitAdresuSoupere(Hrac.VlastniAdresa);
                Hrac.NastavitAdresuSoupere(PocitacovySouper.VlastniAdresa);

                VlaknoProAI = OddelitDoSamostatnehoVlakna(HratHru);
                VlaknoProAI.Start(PocitacovySouper);
            }
            else
            {
                OznamitMistniAdresu();

                Hrac.NastavitAdresuSoupere(ZjistitAdresuSoupere());
            }
        }
        private Thread OddelitDoSamostatnehoVlakna(HerniAlgoritmus algoritmus)
        {
            Thread vlaknoProAI = new Thread(new ParameterizedThreadStart(algoritmus));
            vlaknoProAI.IsBackground = true;

            return vlaknoProAI;
        }
        private IPAddress OznamitMistniAdresu()
        {
            Console.WriteLine("Nahlaš soupeři svoji adresu: " + MistniIP);
            Console.WriteLine();

            return MistniIP;
        }
        private void VyhlasitVysledky()
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
        private void VypnoutHru()
        {
            if(VlaknoProAI != null && VlaknoProAI.IsAlive)
                VlaknoProAI.Join();

            Console.Clear();
            Console.WriteLine("Stiskněte klávesu pro ukončení...");

            Console.CursorVisible = false;
            Console.ReadKey(true);

            Environment.Exit(0);
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
