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
            throw new NotImplementedException();
        }
        private bool HraSkoncila()
        {
            throw new NotImplementedException();
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
        private void OznamitMistniAdresu()
        {
            Rozhrani.ZobrazitHlaseni("Nahlaš soupeři svoji adresu: " + MistniIP + "\n", true);
        }
        private void SkoncitHru()
        {
            if (VlaknoProAI != null && VlaknoProAI.IsAlive)
                VlaknoProAI.Join();
        }
        private void VyhlasitVysledky()
        {
            throw new NotImplementedException();
        }
        private void VypnoutHru()
        {
            Rozhrani.SmazatObrazovku();
            Rozhrani.ZobrazitHlaseni("(C) Ikonu vytvořil Freepik z webu www.flaticon.com");
            Rozhrani.ZobrazitHlaseni();
            Rozhrani.ZobrazitHlaseni("Pro ukončení stiskni libovolnou klávesu ...", true);

            Environment.Exit(0);
        }
        private IPAddress ZjistitAdresuSoupere()
        {
            throw new NotImplementedException();
        }
    }
}
