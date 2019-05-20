using System;
using System.Net;
using System.Threading;

namespace Lode
{
    class Hra
    {
        delegate void HerniAlgoritmus(object hrac);

        #region Atributy
        #endregion

        #region Vlastnosti
        IRozhrani Rozhrani { get; set; }
        IPAddress MistniIP { get; set; }
        Thread VlaknoProAI { get; set; }

        ObecnyHrac Hrac { get; set; }
        ObecnyHrac Souper { get; set; }

        Souradnice CilTahu { get; set; }
        StavPolicka VysledekTahu { get; set; }
        #endregion

        #region Konstruktory
        public Hra(IRozhrani rozhrani)
        {
            Rozhrani = rozhrani;

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
            return Rozhrani.PolozitOtazkuAnoNe("Chceš hrát proti počítači? (A / n)", "To nebyla platná odpověď!", true);
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

            Rozhrani.VykreslitHlaseni("Počítačový hráč má rozmístěné lodě!");
            Rozhrani.VykreslitHerniPole(hrac.HerniPole);

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
                Souper = new PocitacovyHrac();

                Souper.NastavitAdresuSoupere(Hrac.VlastniAdresa);
                Hrac.NastavitAdresuSoupere(Souper.VlastniAdresa);

                VlaknoProAI = OddelitDoSamostatnehoVlakna(HratHru);
                VlaknoProAI.Start(Souper);
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
