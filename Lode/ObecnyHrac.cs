using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace Lode
{
    abstract class ObecnyHrac
    {
        #region Atributy
        protected Random _nahoda;
        #endregion

        #region Vlastnosti
        public IPAddress VlastniAdresa { get; protected set; }
        public IPAddress AdresaSoupere { get; protected set; }

        protected short VysilaciPort { get; set; } = 11011;
        protected short PrijimaciPort { get; set; } = 10001;

        protected Socket VysilaciKomunikacniKanal { get; set; }
        protected Socket PrijimaciKomunikacniKanal { get; set; }

        protected bool ZahajujeKomunikaci;

        protected StavPolicka[,] HerniPole { get; set; }
        protected List<Lod> Lode { get; set; }
        #endregion

        #region Konstruktory
        public ObecnyHrac(IPAddress vlastniAdresa)
        {
            VlastniAdresa = vlastniAdresa;

            _nahoda = new Random((int)DateTime.Now.Ticks);

            HerniPole = new StavPolicka[10, 10];
            Lode = new List<Lod>();
        }
        #endregion

        #region Abstraktni metody
        public abstract Souradnice RozhodnoutVlastniTah();
        public abstract void RozmistitLode();
        #endregion

        #region Verejne metody
        public int GenerovatToken()
        {
            return _nahoda.Next(int.MaxValue);
        }
        public bool JePorazenym()
        {
            throw new NotImplementedException();
        }
        public bool JeVitezem()
        {
            throw new NotImplementedException();
        }
        public bool MaPravoPrvnihoTahu()
        {
            int vlastniToken = GenerovatToken();
            int tokenSoupere = VymenitSiTokenSeSouperem(vlastniToken);

            Console.WriteLine("Vygenerovaný token: " + vlastniToken);
            Console.WriteLine("Obdržený token: " + tokenSoupere);

            return vlastniToken < tokenSoupere;
        }
        public void NastavitAdresuSoupere(IPAddress adresaSoupere)
        {
            AdresaSoupere = adresaSoupere;
        }
        public void NavazatSpojeni(ObecnyHrac souper)
        {
            for (int i = 0; i < VlastniAdresa.GetAddressBytes().Length; i++)
            {
                byte vlastni = VlastniAdresa.GetAddressBytes()[i];
                byte cizi = AdresaSoupere.GetAddressBytes()[i];

                if (vlastni != cizi)
                {
                    ZahajujeKomunikaci = vlastni < cizi;
                    break;
                }
            }

            VysilaciKomunikacniKanal = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            PrijimaciKomunikacniKanal = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            if (ZahajujeKomunikaci)
            {
                Console.WriteLine("Zahajuje komunikaci");

                VysilaciKomunikacniKanal.Connect(AdresaSoupere, PrijimaciPort);

                Console.WriteLine("Čekání na spojení...");
                while (!VysilaciKomunikacniKanal.Connected)
                    Console.Write(".");
                Console.WriteLine("spojeno!");

                PrijimaciKomunikacniKanal.Bind(new IPEndPoint(VlastniAdresa, PrijimaciPort));
                PrijimaciKomunikacniKanal.Listen(10);
            }
            else
            {
                Console.WriteLine("Čeká na komunikaci");

                PrijimaciKomunikacniKanal.Bind(new IPEndPoint(VlastniAdresa, PrijimaciPort));
                PrijimaciKomunikacniKanal.Listen(10);

                VysilaciKomunikacniKanal.Connect(AdresaSoupere, PrijimaciPort);

                Console.WriteLine("Čekání na spojení...");
                while (!VysilaciKomunikacniKanal.Connected)
                    Console.Write(".");
                Console.WriteLine("spojeno!");
            }
        }
        public bool NemuzeProvestDalsiTah()
        {
            throw new NotImplementedException();
        }
        public StavPolicka ProvestTahSoupere(Souradnice tah)
        {
            throw new System.NotImplementedException();
        }
        public void ProvestVlastniTah(Souradnice tah, StavPolicka vysledek)
        {
            throw new NotImplementedException();
        }
        public void OznamitVysledekTahu(ObecnyHrac souper, StavPolicka vysledek)
        {
            throw new NotImplementedException();
        }
        public int VymenitSiTokenSeSouperem(int vlastniToken)
        {
            byte[] data = new byte[1024];

            if(ZahajujeKomunikaci)
            {
                VysilaciKomunikacniKanal.Send(BitConverter.GetBytes(vlastniToken));
                PrijimaciKomunikacniKanal.Receive(data);
            }
            else
            {
                PrijimaciKomunikacniKanal.Receive(data);
                VysilaciKomunikacniKanal.Send(BitConverter.GetBytes(vlastniToken));
            }

            return Convert.ToInt32(data);
        }
        public Souradnice ZjistitTahSoupere()
        {
            throw new System.NotImplementedException();
        }
        public StavPolicka ZjistitVysledekTahu(ObecnyHrac souper, Souradnice tah)
        {
            throw new System.NotImplementedException();
        }
        #endregion

        #region Soukrome metody
        #endregion
    }
}
