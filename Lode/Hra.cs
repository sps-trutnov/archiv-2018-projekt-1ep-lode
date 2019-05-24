using System;
using System.Net;
using System.Threading;

namespace Lode
{
    class Hra
    {
        delegate void HerniAlgoritmus(object hrac);

        IRozhrani Rozhrani { get; set; }
        IPAddress MistniIP { get; set; }
        Thread VlaknoProAI { get; set; }

        ObecnyHrac Hrac { get; set; }
        ObecnyHrac Souper { get; set; }

        Souradnice CilTahu { get; set; }
        StavPolicka VysledekTahu { get; set; }

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

        public void SpustitHru()
        {
            NastavitHrace();
            HratHru(Hrac);
            SkoncitHru();

            VyhlasitVysledky();
            VypnoutHru();
        }

        private bool BudeSeHratProtiPocitaci()
        {
            return Rozhrani.ZiskatOdpovedAnoNe("Chceš hrát proti počítači? (A / n)", "To nebyla platná odpověď!", true);
        }
        private bool HraSkoncila()
        {
            return Hrac.JePorazenym() || Hrac.NemuzeProvestDalsiTah() || Souper.JePorazenym() || Souper.NemuzeProvestDalsiTah();
        }
        private void HratHru(object hrajiciHrac)
        {
            ObecnyHrac hrac = (ObecnyHrac)hrajiciHrac;

            hrac.PripojitRozhrani(Rozhrani);
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
            Rozhrani.ZobrazitHlaseni("Nahlaš soupeři svoji adresu: " + MistniIP + "\n", true);

            return MistniIP;
        }
        private void SkoncitHru()
        {
            if (VlaknoProAI != null && VlaknoProAI.IsAlive)
                VlaknoProAI.Join();
        }
        private void VyhlasitVysledky()
        {
            if (Hrac.JePorazenym() && !Souper.JePorazenym())
            {
                Rozhrani.ZobrazitHlaseni("Porážka...", true);
            }
            else if (Souper.JePorazenym() && !Hrac.JePorazenym())
            {
                Rozhrani.ZobrazitHlaseni("Vítězství!", true);
            }
            else
            {
                Rozhrani.ZobrazitHlaseni("Remíza.", true);
            }
        }
        private void VypnoutHru()
        {
            Rozhrani.SmazatObrazovku();
            Rozhrani.ZobrazitHlaseni("Stiskněte klávesu pro ukončení...", true);

            Environment.Exit(0);
        }
        private IPAddress ZjistitAdresuSoupere()
        {
            Rozhrani.ZobrazitHlaseni("Jakou IP adresu má soupeř?");

            byte prvni, druhy, treti, ctvrty;

            prvni = Rozhrani.ZiskatOktet("Zadej první oktet:", "Hodnota musí být celé číslo v rozsahu 0-255!");
            druhy = Rozhrani.ZiskatOktet("Zadej druhý oktet:", "Hodnota musí být celé číslo v rozsahu 0-255!");
            treti = Rozhrani.ZiskatOktet("Zadej třetí oktet:", "Hodnota musí být celé číslo v rozsahu 0-255!");
            ctvrty = Rozhrani.ZiskatOktet("Zadej čtvrtý oktet:", "Hodnota musí být celé číslo v rozsahu 0-255!");

            Rozhrani.ZobrazitHlaseni("\n" + "Zadal jsi adresu: " + prvni + "." + druhy + "." + treti + "." + ctvrty);
            Rozhrani.ZobrazitHlaseni("\n" + "Pokračuj stiskem klávesy...", true);

            return new IPAddress(new byte[] { prvni, druhy, treti, ctvrty });
        }
    }
}
