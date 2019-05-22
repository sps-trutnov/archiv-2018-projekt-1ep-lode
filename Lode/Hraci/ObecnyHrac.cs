using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public IRozhrani Rozhrani { get; protected set; }

        public IPAddress VlastniAdresa { get; protected set; }
        public IPAddress AdresaSoupere { get; protected set; }

        protected short VysilaciPort { get; set; } = 11011;
        protected short PrijimaciPort { get; set; } = 10001;

        protected Socket VysilaciKomunikacniKanal { get; set; }
        protected Socket PrijimaciKomunikacniKanal { get; set; }

        protected bool ZahajujeKomunikaci;

        public  StavPolicka[,] HerniPole { get; protected set; }
        public List<Lod> Lode { get; protected set; }
        #endregion

        #region Konstruktory
        public ObecnyHrac(IPAddress vlastniAdresa)
        {
            _nahoda = new Random((int)DateTime.Now.Ticks);

            VlastniAdresa = vlastniAdresa;
            HerniPole = new StavPolicka[10, 10];

            Lode = new List<Lod>();

            for (int i = 0; i < 4; i++)
                Lode.Add(new Lod(TypLode.Clun));
            for (int i = 0; i < 3; i++)
                Lode.Add(new Lod(TypLode.Torpedovka));
            for (int i = 0; i < 2; i++)
                Lode.Add(new Lod(TypLode.Letadlovka));
            for (int i = 0; i < 1; i++)
                Lode.Add(new Lod(TypLode.Kriznik));
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

            return vlastniToken < tokenSoupere;
        }
        public void NastavitAdresuSoupere(IPAddress adresaSoupere)
        {
            AdresaSoupere = adresaSoupere;
        }
        public void NavazatSpojeniSeSouperem()
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

            PrijimaciKomunikacniKanal.Bind(new IPEndPoint(VlastniAdresa, PrijimaciPort));
            PrijimaciKomunikacniKanal.Listen(10);

            VysilaciKomunikacniKanal.Connect(AdresaSoupere, PrijimaciPort);
            Debug.Write("Čekání na spojení se soupeřem...");
            PrijimaciKomunikacniKanal = PrijimaciKomunikacniKanal.Accept();
            Debug.WriteLine("spojeno!");
        }
        public bool NemuzeProvestDalsiTah()
        {
            throw new NotImplementedException();
        }
        public void OznamitVysledekTahuSouperi(StavPolicka vysledek)
        {
            throw new NotImplementedException();
        }
        public void PripojitRozhrani(IRozhrani rozhrani)
        {
            Rozhrani = rozhrani;
        }
        public StavPolicka ProvestTahSoupere(Souradnice tah)
        {
            throw new System.NotImplementedException();
        }
        public void ProvestVlastniTah(Souradnice tah, StavPolicka vysledek)
        {
            throw new NotImplementedException();
        }
        public int VymenitSiTokenSeSouperem(int vlastniToken)
        {
            byte[] data = new byte[1024];

            if (ZahajujeKomunikaci)
            {
                VysilaciKomunikacniKanal.Send(BitConverter.GetBytes(vlastniToken));
                PrijimaciKomunikacniKanal.Receive(data);
            }
            else
            {
                PrijimaciKomunikacniKanal.Receive(data);
                VysilaciKomunikacniKanal.Send(BitConverter.GetBytes(vlastniToken));
            }

            return BitConverter.ToInt32(data, 0);
        }
        public Souradnice ZjistitTahSoupere()
        {
            throw new System.NotImplementedException();
        }
        public StavPolicka ZjistitVysledekTahuOdSoupere(Souradnice tah)
        {
            throw new System.NotImplementedException();
        }
        #endregion

        #region Soukrome metody
        #endregion
    }
}
