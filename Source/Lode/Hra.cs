using System.Net;

namespace Lode
{
    class Hra
    {
        delegate void HerniAlgoritmus(object hrac);

        private IRozhrani Rozhrani { get; set; }
        private IPAddress MistniIP { get; set; }
        private Thread VlaknoProAI { get; set; }

        public ObecnyHrac Hrac { get; set; }
        private ObecnyHrac Souper { get; set; }


        private Souradnice CilTahu { get; set; }
        private StavPolicka VysledekTahu { get; set; }

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

        public bool BudeSeHratProtiPocitaci()
        {
             throw new NotImplementedException();
        }
        public bool HraSkoncila()
        {
            return true;
        }
        public void HratHru(object hrajiciHrac)
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
            if (((TextoveRozhrani)Rozhrani).Menu.HraProtiPocitaci)
            {
                Souper = new PocitacovyHrac();

                Souper.NastavitAdresuSoupere(Hrac);
                Hrac.NastavitAdresuSoupere(Souper);


                Souper.NastavitAdresuSoupere(Hrac);
                Hrac.NastavitAdresuSoupere(Souper);


                VlaknoProAI = OddelitDoSamostatnehoVlakna(HratHru);
                VlaknoProAI.Start(Souper);
            }
            else
            {
                OznamitMistniAdresu();

                Hrac.NastavitAdresuSoupere(ZjistitAdresuLidskehoSoupere());
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
            Rozhrani.ZobrazitHlaseni("(c) Ikonu vytvořil Freepik z webu www.flaticon.com");
            Rozhrani.ZobrazitHlaseni();
            Rozhrani.ZobrazitHlaseni("Pro ukončení stiskni libovolnou klávesu ...", true);

            Environment.Exit(0);
        }
        private IPAddress ZjistitAdresuLidskehoSoupere()
        {
            throw new NotImplementedException();
        }

        public void SpustitHru()
        {
            Rozhrani.ZobrazitMenu(this);

            NastavitHrace();
            HratHru(Hrac);
            SkoncitHru();

            VyhlasitVysledky();
            VypnoutHru();
        }
    }
}
